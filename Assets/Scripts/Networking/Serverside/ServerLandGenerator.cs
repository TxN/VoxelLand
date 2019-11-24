using System.Collections;
using System.Collections.Generic;

using Unity.Jobs;
using UnityEngine;

using SMGCore.EventSys;
using Voxels.Networking.Events;

namespace Voxels.Networking.Serverside {
	public sealed class ServerLandGenerator : ServerSideController<ServerLandGenerator> {
		public ServerLandGenerator(ServerGameManager owner) : base(owner) { }

		Unity.Mathematics.Random _random;
		Queue<Int3> _chunkGenQueue  = new Queue<Int3>(16);
		bool        _routineRuuning = false;

		//If true, gen coroutine runs without skipping a frame on heightmap generation
		public bool ImmediateMode {
			get; set;
		}

		public int Seed { get; private set; }

		public override void Load() {
			Seed = Utils.WorldOptions.Seed;
			Random.InitState(Seed);
			_random.InitState((uint)Seed);
			base.Load();
		}

		public override void PostLoad() {
			base.PostLoad();
		}

		public void AddToQueue(Int3 newChunk) {
			_chunkGenQueue.Enqueue(newChunk);
			RunGenRoutine();
		}

		public void RefreshQueue(List<Int3> newChunks) {
			_chunkGenQueue.Clear();
			foreach ( var item in newChunks ) {
				_chunkGenQueue.Enqueue(item);
			}
			RunGenRoutine();
		}

		void RunGenRoutine() {
			if ( _routineRuuning ) {
				return;
			}
			_routineRuuning = true;
			GameManager.Instance.StartCoroutine(ParallelGenRoutine());
		}

		IEnumerator ParallelGenRoutine() {
			while ( _chunkGenQueue.Count > 0 ) {
				var chunkPos = _chunkGenQueue.Dequeue();
				var x = chunkPos.X;
				var z = chunkPos.Z;
				var heightmapJob = new HeightGenJob() {
					BaseScale = 20,
					Seed      = this.Seed,
					SizeX     = Chunk.CHUNK_SIZE_X,
					SizeY     = Chunk.CHUNK_SIZE_Z,
					OffsetX   = Chunk.CHUNK_SIZE_X * x,
					OffsetY   = Chunk.CHUNK_SIZE_Z * z,
					Height    = new Unity.Collections.NativeArray<byte>(Chunk.CHUNK_SIZE_X * Chunk.CHUNK_SIZE_Z, Unity.Collections.Allocator.Persistent)
				};
				var hHandle = heightmapJob.Schedule(256, 128);
				hHandle.Complete();
				var waterLevel = Utils.WorldOptions.WaterLevel;
				var blockCount = Chunk.CHUNK_SIZE_X * Chunk.CHUNK_SIZE_Y * Chunk.CHUNK_SIZE_Z;
				var fillJob    = new ChunkGenJob() {
					SizeH      = Chunk.CHUNK_SIZE_X,
					SizeY      = Chunk.CHUNK_SIZE_Y,
					Random     = _random,
					SeaLevel   = waterLevel,
					HeightMap  = heightmapJob.Height,
					Blocks     = new Unity.Collections.NativeArray<BlockData>(blockCount, Unity.Collections.Allocator.Persistent)
				};

				var fillHandler = fillJob.Schedule(blockCount, 512);
				var height      = heightmapJob.Height.ToArray();
				var maxY        = waterLevel;
				for ( int i = 0; i < height.Length; i++ ) {
					if ( height[i] > maxY ) {
						maxY = height[i];
					}
				}
				if ( !ImmediateMode ) {
					yield return new WaitForEndOfFrame();
				}
				fillHandler.Complete();

				EventManager.Fire(new OnServerChunkGenerated {
					Blocks      = fillJob.Blocks.ToArray(),
					Heightmap   = heightmapJob.Height.ToArray(),
					MaxHeight   = maxY + 1,
					WorldCoords = new Int3(x * Chunk.CHUNK_SIZE_X, 0, z * Chunk.CHUNK_SIZE_Z),
					WaterLevel  = waterLevel
				});
				heightmapJob.Height.Dispose();
				fillJob.Blocks.Dispose();
			}
			_routineRuuning = false;
			EventManager.Fire(new OnServerChunkGenQueueEmpty());
			yield break;
		}

		//Need to be called after set all blocks function call
		public void PostProcessGeneration(Chunk chunk, byte[] heightMap, int waterLevel) {
			var maxTreeSpawnAttempts = Random.Range(3, 6);
			for ( int i = 0; i < maxTreeSpawnAttempts; i++ ) {
				var x = Random.Range(2, Chunk.CHUNK_SIZE_X - 3); // TODO: fix to support placing blocks in neighbor chunks
				var z = Random.Range(2, Chunk.CHUNK_SIZE_Z - 3);

				var pointer = x * Chunk.CHUNK_SIZE_X + z;
				var h = heightMap[pointer] + 1;
				if ( h > waterLevel ) {
					SpawnTree(chunk, new Int3(x, h, z));
				}
			}
			chunk.SetDirtyAll();
			chunk.MarkAsLoaded();
		}

		void SpawnTree(Chunk chunk, Int3 startPos) {
			var x = startPos.X;
			var y = startPos.Y;
			var z = startPos.Z;

			var trunkHeight = Random.Range(1, 5);
			for ( int i = 0; i < trunkHeight; i++ ) {
				chunk.PutBlock(x, y + i, z, new BlockData(BlockType.Log, 0));
			}
			chunk.PutBlock(x, y + trunkHeight, z,     new BlockData(BlockType.Log, 0));
			chunk.PutBlock(x, y + trunkHeight + 1, z, new BlockData(BlockType.Log, 0));
			chunk.PutBlock(x, y + trunkHeight + 2, z, new BlockData(BlockType.Log, 0));
			chunk.PutBlock(x, y + trunkHeight + 3, z, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x, y + trunkHeight + 4, z, new BlockData(BlockType.Leaves, 0));


			chunk.PutBlock(x + 1, y + trunkHeight + 1, z,     new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x + 1, y + trunkHeight + 1, z + 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x + 1, y + trunkHeight + 1, z - 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x - 1, y + trunkHeight + 1, z,     new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x - 1, y + trunkHeight + 1, z + 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x - 1, y + trunkHeight + 1, z - 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x, y + trunkHeight + 1, z + 1,     new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x, y + trunkHeight + 1, z - 1,     new BlockData(BlockType.Leaves, 0));

			chunk.PutBlock(x + 1, y + trunkHeight + 2, z,     new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x + 1, y + trunkHeight + 2, z + 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x + 1, y + trunkHeight + 2, z - 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x - 1, y + trunkHeight + 2, z,     new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x - 1, y + trunkHeight + 2, z + 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x - 1, y + trunkHeight + 2, z - 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x, y + trunkHeight + 2, z + 1,     new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x, y + trunkHeight + 2, z - 1,     new BlockData(BlockType.Leaves, 0));

			chunk.PutBlock(x + 1, y + trunkHeight + 3, z,     new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x + 1, y + trunkHeight + 3, z + 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x + 1, y + trunkHeight + 3, z - 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x - 1, y + trunkHeight + 3, z,     new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x - 1, y + trunkHeight + 3, z + 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x - 1, y + trunkHeight + 3, z - 1, new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x, y + trunkHeight + 3, z + 1,     new BlockData(BlockType.Leaves, 0));
			chunk.PutBlock(x, y + trunkHeight + 3, z - 1,     new BlockData(BlockType.Leaves, 0));
		}
	}
}
