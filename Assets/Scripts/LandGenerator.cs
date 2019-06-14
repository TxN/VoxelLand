using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;

namespace Voxels {
	public sealed class LandGenerator : MonoBehaviour {
		HeightGenJob _heigtmapGenData;
		JobHandle    _heightGenJobHandle;
		bool         _isGeneratingHeightmap = false;
		byte[]       _heightmap;

		private void Start() {
			Resources.UnloadUnusedAssets();
			System.GC.Collect();

			Random.InitState(-26564);
			if ( !ChunkManager.Instance ) {
				Debug.Log("Chunk manager isn't present");
				return;
			}
			var cm = ChunkManager.Instance;

			var size = 256;
			_isGeneratingHeightmap = true;
			_heigtmapGenData = new HeightGenJob();
			_heigtmapGenData.BaseScale = 20;
			_heigtmapGenData.Seed = 143;
			_heigtmapGenData.SizeX = size;
			_heigtmapGenData.SizeY = size;
			_heigtmapGenData.Height = new Unity.Collections.NativeArray<byte>(size * size, Unity.Collections.Allocator.Persistent);
			_heightGenJobHandle = _heigtmapGenData.Schedule(_heigtmapGenData.Height.Length, 128);
		}

		private void Update() {
			if ( _isGeneratingHeightmap && _heightGenJobHandle.IsCompleted ) {
				_isGeneratingHeightmap = false;
				_heightGenJobHandle.Complete();
				_heightmap = _heigtmapGenData.Height.ToArray();
				_heigtmapGenData.Height.Dispose();
				StartCoroutine(ByChunkGenRoutine(16,16));
			}

			if ( Input.GetKeyDown(KeyCode.U) ) {
				StopAllCoroutines();
			}
		}

		void GenSegment(int x, int z) {
			var cm = ChunkManager.Instance;
			var chunk = cm.GetChunkInCoords(x,0,z);
			if ( chunk == null ) {
				return;
			}

			for ( int lx = 0; lx < Chunk.CHUNK_SIZE_X; lx++ ) {
				for ( int lz = 0; lz < Chunk.CHUNK_SIZE_Z; lz++ ) {
					var height = _heightmap[(x + lx) * 256 + z + lz];
					var stoneHeight = Mathf.RoundToInt( height * 0.8f);
					chunk.PutBlock(lx, 0, lz, new BlockData(BlockType.Bedrock, 0));
					for ( int y = 1; y < height; y++ ) {
						if ( y < stoneHeight ) {
							chunk.PutBlock(lx, y, lz, new BlockData(BlockType.Stone, 0));
						} else {
							chunk.PutBlock(lx, y, lz, new BlockData(BlockType.Dirt, 0));
						}
						chunk.PutBlock(lx, height, lz, new BlockData(BlockType.Grass, 0));
					}
				}
			}
			chunk.InitSunlight();
		}

		IEnumerator ByChunkGenRoutine(int sizeX, int sizeZ) {
			for ( int x = 0; x < sizeX; x++ ) {
				for ( int z = 0; z < sizeZ; z++ ) {
					GenSegment(x * Chunk.CHUNK_SIZE_X, z * Chunk.CHUNK_SIZE_Z);
					yield return new WaitForEndOfFrame();
				}
			}
			var cm = ChunkManager.Instance;
			var chunks = cm.GetAllChunks;
			foreach ( var chunk in chunks ) {
				chunk.ForceUpdateChunk();
				yield return new WaitForEndOfFrame();
			}
			yield return null;
		}

		private void OnDestroy() {
			if ( _isGeneratingHeightmap ) {
				_heigtmapGenData.Height.Dispose();
			}
		}

		IEnumerator GenRoutine() {
			var sizeX = 256;
			var sizeZ = 256;

			var cm = ChunkManager.Instance;
			var counter = 0;
			for ( int x = 0; x < sizeX; x++ ) {
				for ( int z = 0; z < sizeZ; z++ ) {
					
					cm.PutBlock(x, 0, z, new BlockData(BlockType.Bedrock, 0));

					var height =  Mathf.RoundToInt(GetHeight(x,z));
					var stoneHeight = Mathf.RoundToInt( height * 0.8f);
					for ( int y = 1; y < height; y++ ) {
						if ( y < stoneHeight ) {
							cm.PutBlock(x, y, z, new BlockData(BlockType.Stone, 0));
						} else {
							cm.PutBlock(x, y, z, new BlockData(BlockType.Dirt, 0));
						}
						cm.PutBlock(x, height, z, new BlockData(BlockType.Grass, 0));
					}
				}
				if ( counter % 1 == 0 ) {
					yield return new WaitForEndOfFrame();
				}
				counter++;
				
			}
			yield return new WaitForEndOfFrame();

			var weed     = new BlockData(BlockType.Weed,0);
			var shrooms1 = new BlockData(BlockType.Mushroom,0);
			var shrooms2 = new BlockData(BlockType.Mushroom,1);
			for ( int i = 0; i < 50; i++ ) {
				PlaceBlockFromTop(weed, Random.Range(0, sizeX), Random.Range(0, sizeZ), BlockType.Grass, BlockType.Dirt);
				PlaceBlockFromTop(shrooms1, Random.Range(0, sizeX), Random.Range(0, sizeZ), BlockType.Grass, BlockType.Dirt);
				PlaceBlockFromTop(shrooms2, Random.Range(0, sizeX), Random.Range(0, sizeZ), BlockType.Grass, BlockType.Dirt);
			}
			var chunks = cm.GetAllChunks;

			foreach ( var chunk in chunks ) {
				chunk.ForceUpdateChunk();
				yield return new WaitForEndOfFrame();
			}
			yield return null;
		}

		float GetHeight(int x, int z) {
			var noizeScale = 20;
			var noise =  Mathf.PerlinNoise(x / (float) 32 + 32, z / (float) 32 + 32) * noizeScale * 0.5f;
			noise += Mathf.PerlinNoise(x / (float)64 + 1, z / (float)64 + 1) * noizeScale;
			noise += Mathf.PerlinNoise(x / (float)128 + 5, z / (float)128 + 5) * noizeScale * 2;
			noise += Mathf.PerlinNoise(x / (float)16 + 4, z / (float)16 + 6) * noizeScale * 0.25f;
			return noise;
		}

		void PlaceBlockFromTop(BlockData blockToPlace, int x, int z, params BlockType[]   allowedTypes) {
			var cm = ChunkManager.Instance;
			var height = cm.GetWorldHeight;
			for ( int y = height; y > 0; y-- ) {
				var blockAt = cm.GetBlockIn(x, y, z);
				if ( !blockAt.IsEmpty() ) {
					for ( int i = 0; i < allowedTypes.Length; i++ ) {
						if( blockAt.Info.Type == allowedTypes[i] ) {
							cm.PutBlock(x, y + 1, z, blockToPlace);
						}
					}
					return;
				}
			}
		}

		void PlaceBlockFromTop(BlockData blockToPlace, int x, int z) {
			var cm = ChunkManager.Instance;
			var height = cm.GetWorldHeight;
			for ( int y = height; y > 0; y-- ) {
				var blockAt = cm.GetBlockIn(x, y, z);
				if ( !blockAt.IsEmpty() ) {
					cm.PutBlock(x, y + 1, z, blockToPlace);
					return;
				}
			}
		}
	}
}

