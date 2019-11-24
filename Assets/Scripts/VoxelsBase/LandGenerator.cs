using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Unity.Jobs;

using SMGCore;

namespace Voxels {
	public sealed class LandGenerator : ManualSingleton<LandGenerator> {
		Queue<Int3>  _chunkGenQueue = new Queue<Int3>(16);

		Unity.Mathematics.Random _random;

		private void Start() {
			Resources.UnloadUnusedAssets();
			System.GC.Collect();

			Random.InitState(-26564);
			_random.InitState(26564);
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
					var waterLevel = 35;
					var blockCount = Chunk.CHUNK_SIZE_X * Chunk.CHUNK_SIZE_Y * Chunk.CHUNK_SIZE_Z;
					var fillJob = new ChunkGenJob() {
						SizeH   = Chunk.CHUNK_SIZE_X,
						SizeY   = Chunk.CHUNK_SIZE_Y,
						Random  = _random,
						SeaLevel = waterLevel,
						HeightMap = heightmapJob.Height,
						Blocks = new Unity.Collections.NativeArray<BlockData>(blockCount, Unity.Collections.Allocator.Persistent)
					};

					var fillHandler = fillJob.Schedule(blockCount, 512);
					var height = heightmapJob.Height.ToArray();
					var maxY = waterLevel;
					for ( int i = 0; i < height.Length; i++ ) {
						if ( height[i] > maxY ) {
							maxY = height[i];
						}
					}
					yield return new WaitForEndOfFrame();
					fillHandler.Complete();

					var chunk = cm.GetOrInitChunkInCoords(x * Chunk.CHUNK_SIZE_X, 0, z * Chunk.CHUNK_SIZE_Z);
					if ( chunk != null ) {
						chunk.SetAllBlocks(fillJob.Blocks.ToArray(), maxY + 1);
						PostProcessGeneration(chunk, heightmapJob.Height, waterLevel);
						chunk.SetDirtyAll();
						chunk.MarkAsLoaded();
					}
					heightmapJob.Height.Dispose();
					fillJob.Blocks.Dispose();
				}
				yield return new WaitForEndOfFrame();
			}
		}

		void OnDestroy() {
			StopAllCoroutines();
		}

		void PostProcessGeneration(Chunk chunk, Unity.Collections.NativeArray<byte> heightMap, int waterLevel) {
			var maxTreeSpawnAttempts = Random.Range(3,6);
			for ( int i = 0; i < maxTreeSpawnAttempts; i++ ) {
				var x = Random.Range(2, Chunk.CHUNK_SIZE_X - 3); // TODO: fix to support placing blocks in neighbor chunks
				var z = Random.Range(2, Chunk.CHUNK_SIZE_Z - 3);

				var pointer = x * Chunk.CHUNK_SIZE_X + z;
				var h = heightMap[pointer] + 1;
				if ( h > waterLevel ) {
					SpawnTree(chunk, new Int3(x, h, z));
				}
			}
		}

		void SpawnTree(Chunk chunk, Int3 startPos) {
			var x = startPos.X;
			var y = startPos.Y;
			var z = startPos.Z;

			var cm = ChunkManager.Instance;
			var trunkHeight = Random.Range(1, 5);
			for ( int i = 0; i < trunkHeight; i++ ) {
				chunk.PutBlock(x, y + i, z, new BlockData(BlockType.Log, 0));
			}
			chunk.PutBlock(x, y + trunkHeight, z, new BlockData(BlockType.Log, 0));
			chunk.PutBlock(x, y + trunkHeight +1, z, new BlockData(BlockType.Log, 0));
			chunk.PutBlock(x, y + trunkHeight +2, z, new BlockData(BlockType.Log, 0));
			chunk.PutBlock(x, y + trunkHeight +3, z, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x, y + trunkHeight +4, z, new BlockData(BlockType.Leaves, 0));


			chunk.PutBlock(x + 1, y + trunkHeight + 1, z, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x + 1, y + trunkHeight + 1, z + 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x + 1, y + trunkHeight + 1, z - 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x - 1, y + trunkHeight + 1, z, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x - 1, y + trunkHeight + 1, z + 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x - 1, y + trunkHeight + 1, z - 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x, y + trunkHeight + 1, z + 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x, y + trunkHeight + 1, z - 1, new BlockData(BlockType.Leaves, 0));

			chunk.PutBlock(x + 1, y + trunkHeight + 2, z, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x + 1, y + trunkHeight + 2, z + 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x + 1, y + trunkHeight + 2, z - 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x - 1, y + trunkHeight + 2, z, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x - 1, y + trunkHeight + 2, z + 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x - 1, y + trunkHeight + 2, z - 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x, y + trunkHeight + 2, z + 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x, y + trunkHeight + 2, z - 1, new BlockData(BlockType.Leaves, 0));

			chunk.PutBlock(x + 1, y + trunkHeight + 3, z, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x + 1, y + trunkHeight + 3, z + 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x + 1, y + trunkHeight + 3, z - 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x - 1, y + trunkHeight + 3, z, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x - 1, y + trunkHeight + 3, z + 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x - 1, y + trunkHeight + 3, z - 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x, y + trunkHeight + 3, z + 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x, y + trunkHeight + 3, z - 1, new BlockData(BlockType.Leaves, 0));
		}
		/*
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
		*/
	}
}

