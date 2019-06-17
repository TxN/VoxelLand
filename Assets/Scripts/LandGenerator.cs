using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;

namespace Voxels {
	public sealed class LandGenerator : MonoSingleton<LandGenerator> {
		Queue<Int3>  _chunkGenQueue = new Queue<Int3>(16);
		Queue<Chunk> _visRegenQueue = new Queue<Chunk>(16);

		private void Start() {
			Resources.UnloadUnusedAssets();
			System.GC.Collect();

			Random.InitState(-26564);
			if ( !ChunkManager.Instance ) {
				Debug.Log("Chunk manager isn't present");
				return;
			}
			StartCoroutine(ParallelGenRoutine());
		}

		private void Update() {
			if ( Input.GetKeyDown(KeyCode.U) ) {
				StopAllCoroutines();
			}
		}

		public void RefreshQueue(List<Int3> newChunks) {
			_chunkGenQueue.Clear();
			foreach ( var item in newChunks ) {
				_chunkGenQueue.Enqueue(item);
			}
		}

		IEnumerator ParallelGenRoutine() {
			var cm = ChunkManager.Instance;

			while (true) {
				if ( _chunkGenQueue.Count > 0 ) {
					var chunkPos = _chunkGenQueue.Dequeue();
					var x = chunkPos.X;
					var z = chunkPos.Z;
					var heightmapJob = new HeightGenJob() {
						BaseScale = 20,
						Seed = 143,
						SizeX = Chunk.CHUNK_SIZE_X,
						SizeY = Chunk.CHUNK_SIZE_Z,
						OffsetX = Chunk.CHUNK_SIZE_X * x,
						OffsetY = Chunk.CHUNK_SIZE_Z * z,
						Height = new Unity.Collections.NativeArray<byte>(Chunk.CHUNK_SIZE_X * Chunk.CHUNK_SIZE_Z, Unity.Collections.Allocator.Persistent)
					};
					var hHandle = heightmapJob.Schedule(256, 128);
					hHandle.Complete();

					var blockCount = Chunk.CHUNK_SIZE_X * Chunk.CHUNK_SIZE_Y * Chunk.CHUNK_SIZE_Z;
					var fillJob = new ChunkGenJob() {
						SizeH = Chunk.CHUNK_SIZE_X,
						SizeY = Chunk.CHUNK_SIZE_Y,
						Seed = 143,
						HeightMap = heightmapJob.Height,
						Blocks = new Unity.Collections.NativeArray<BlockData>(blockCount, Unity.Collections.Allocator.Persistent)
					};

					var fillHandler = fillJob.Schedule(blockCount, 512);
					var height = heightmapJob.Height.ToArray();
					var maxY = 0;
					for ( int i = 0; i < height.Length; i++ ) {
						if ( height[i] > maxY ) {
							maxY = height[i];
						}
					}
					yield return new WaitForEndOfFrame();
					fillHandler.Complete();

					var chunk = cm.GetChunkInCoords(x * Chunk.CHUNK_SIZE_X, 0, z * Chunk.CHUNK_SIZE_Z);
					if ( chunk != null ) {
						chunk.SetAllBlocks(fillJob.Blocks.ToArray(), maxY + 1);
						chunk.SetDirtyAll();
					}
					heightmapJob.Height.Dispose();
					fillJob.Blocks.Dispose();
					_visRegenQueue.Enqueue(chunk);
				} else if ( _visRegenQueue.Count > 0 ) {
					var regenChunk = _visRegenQueue.Dequeue();
					if ( regenChunk != null ) {
						regenChunk.ForceUpdateChunk();
					}
				}

				yield return new WaitForEndOfFrame();
			}
		}

		void OnDestroy() {
			StopAllCoroutines();
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

