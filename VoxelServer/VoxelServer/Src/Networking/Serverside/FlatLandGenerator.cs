using System.Threading;

namespace Voxels.Networking.Serverside {
	public sealed class FlatLandGenerator : BaseLandGenerator {
		const int GROUND_HEIGHT = 12;

		public override bool IsRunning => _routineRunning;

		bool _routineRunning = false;
		bool _isRandomInited = false;

		System.Random _random;

		Thread _genThread = null;

		byte[] _heightmap = null;

		public override void Init(int seed) {
			base.Init(seed);
			var size = (Chunk.CHUNK_SIZE_X * Chunk.CHUNK_SIZE_Z);
			_heightmap = new byte[size];
			for ( int i = 0; i < size; i++ ) {
				_heightmap[i] = GROUND_HEIGHT;
			}
		}

		public override void RunGenRoutine() {
			if ( IsRunning ) {
				return;
			}
			_routineRunning = true;
			RunGenerator();
		}

		void RunGenerator() {
			if ( _genThread != null &&_genThread.ThreadState == ThreadState.Running ) {
				return;
			}
			
			_genThread = new Thread(GenThread);		
			
			_routineRunning = true;
			_genThread.Start();
			
		}

		void GenThread() {
			if ( !_isRandomInited ) {
				_isRandomInited = true;
				_random = new System.Random(_seed);
			}
			while ( _chunkGenQueue.Count > 0 ) {
				if ( !_chunkGenQueue.TryDequeue(out var chunkPos) ) {
					break;
				}
				var x = chunkPos.X;
				var z = chunkPos.Z;

				const int blockCount = (Chunk.CHUNK_SIZE_X * Chunk.CHUNK_SIZE_Z) * (Chunk.CHUNK_SIZE_Y);
				var blocks = new BlockData[blockCount];
				for ( int i = 0; i < blockCount; i++ ) {
					Execute(i, blocks);
				}

				var readyChunk = new GeneratedChunkData(new Int3(x * Chunk.CHUNK_SIZE_X, 0, z * Chunk.CHUNK_SIZE_Z), blocks, _heightmap, GROUND_HEIGHT + 1, 0);
				_readyChunks.Enqueue(readyChunk);
				Thread.Sleep(1);
			}
			_routineRunning = false;
		}

		public void Execute(int index, BlockData[] Blocks) {
			var SizeH = Chunk.CHUNK_SIZE_X;
			var dh = Chunk.CHUNK_SIZE_X * Chunk.CHUNK_SIZE_X;
			var y = index / dh;
			var h = index % dh;
			var x = h % Chunk.CHUNK_SIZE_X;
			var z = h / Chunk.CHUNK_SIZE_X;
			var height = GROUND_HEIGHT;
			var stoneHeight = (int)(height * 0.7f);

			var rnd8pct = _random.Next(0, 12) < 1 ? true : false;
			var rnd3pct = _random.Next(0, 30) < 1 ? true : false;

			if ( y == 0 ) {
				Blocks[y * dh + z * SizeH + x] = new BlockData(BlockType.Bedrock, 0);
				return;
			}
			if ( y < stoneHeight ) {
				Blocks[y * dh + z * SizeH + x] = new BlockData(BlockType.Stone, 0);
			} else if ( y < height ) {
				Blocks[y * dh + z * SizeH + x] = new BlockData(BlockType.Dirt, 0);
				return;
			} else if ( y == height ) {
				Blocks[y * dh + z * SizeH + x] = new BlockData(BlockType.Grass, 0);
			} else if ( y == height + 1 && rnd8pct ) {
				Blocks[y * dh + z * SizeH + x] = new BlockData() {
					Type = BlockType.Weed,
					SunLevel = 255,
					AddColor = 65535,
				};
			} else if ( y == height + 1 && rnd3pct ) {
				Blocks[y * dh + z * SizeH + x] = new BlockData() {
					Type = BlockType.Shrub,
					Subtype = (byte)_random.Next(0, 3),
					SunLevel = 255,
					AddColor = 65535,
				};
			} else if ( y > height || (!rnd8pct && y > height) ) {
				Blocks[y * dh + z * SizeH + x] = new BlockData() {
					SunLevel = 255
				};
			}
		}
	}
}
