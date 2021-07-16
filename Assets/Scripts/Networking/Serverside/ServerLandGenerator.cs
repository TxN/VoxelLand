using SMGCore.EventSys;

using System.Collections.Generic;

using Voxels.Networking.Events;

namespace Voxels.Networking.Serverside {
	public sealed class ServerLandGenerator : ServerSideController<ServerLandGenerator> {
		const int MAX_CHUNK_PER_TICK = 2; //сколько максимум чанков можно отдать из генератора за один тик

		static System.Random RandomGenerator;

		BaseLandGenerator _landGenerator = null;

		public ServerLandGenerator(ServerGameManager owner) : base(owner) {
			_landGenerator = new UnityLandGenerator();
		}		

		//If true, gen coroutine runs without skipping a frame on heightmap generation (if applicable)
		public bool ImmediateMode {
			get => _landGenerator.ImmediateMode;
			set => _landGenerator.ImmediateMode = value;
		}

		public int QueueCount => _landGenerator.QueueCount;

		public int Seed { get; private set; }

		public override void Load() {
			Seed = Utils.WorldOptions.Seed;
			RandomGenerator = new System.Random(Seed);
			_landGenerator.Init(Seed);
			base.Load();
		}

		public override void Update() {
			base.Update();

			var receivedChunks = 0;
			while ( receivedChunks < MAX_CHUNK_PER_TICK ) {
				var c = _landGenerator.TryGetGeneratedChunk();
				if ( c == null ) {
					break;
				}
				receivedChunks++;
				EventManager.Fire(new OnServerChunkGenerated {ChunkData = c});
			}
			if ( receivedChunks > 0 && _landGenerator.QueueCount == 0 && !_landGenerator.IsRunning ) {
				//если мы забрали последний чанк из генерированной очереди и генератор больше неактивен, бросаем ивент завершения генерации
				//Здесь возможна потенциальная гонка, но ее вероятность должна быть очень скромной
				EventManager.Fire(new OnServerChunkGenQueueEmpty());
			}
		}

		public void TryStartGeneration() {
			_landGenerator.RunGenRoutine();
		}

		public void ClearQueue() {
			_landGenerator?.ClearQueue();		
		}

		public void AddToQueue(Int3 newChunk, bool run) {
			_landGenerator.AddToQueue(newChunk, run);	
		}

		public void RefreshQueue(List<Int3> newChunks) {
			_landGenerator.RefreshQueue(newChunks);
		}	

		//Need to be called after set all blocks function call
		public static void PostProcessGeneration(Chunk chunk, byte[] heightMap, int waterLevel) {
			var maxTreeSpawnAttempts = RandomGenerator.Next(3,7);
			for ( int i = 0; i < maxTreeSpawnAttempts; i++ ) {
				var x = RandomGenerator.Next(2, Chunk.CHUNK_SIZE_X - 2); // TODO: fix to support placing blocks in neighbor chunks
				var z = RandomGenerator.Next(2, Chunk.CHUNK_SIZE_Z - 2);

				var pointer = x * Chunk.CHUNK_SIZE_X + z;
				var h = heightMap[pointer] + 1;
				if ( h > waterLevel ) {
					SpawnTree(chunk, new Int3(x, h, z));
				}
			}
			chunk.SetDirtyAll();
		}

		static void SpawnTree(Chunk chunk, Int3 startPos) {
			var x = startPos.X;
			var y = startPos.Y;
			var z = startPos.Z;

			var trunkHeight = RandomGenerator.Next(1, 5);
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
