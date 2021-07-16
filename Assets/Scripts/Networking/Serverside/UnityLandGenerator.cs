using System.Collections;

using Unity.Jobs;
using UnityEngine;
using UnityEngine.Profiling;

namespace Voxels.Networking.Serverside {
	public sealed class UnityLandGenerator : BaseLandGenerator {
		Unity.Mathematics.Random _random;

		public override bool IsRunning => _routineRuuning;

		bool _routineRuuning = false;

		public override void Init(int seed) {
			base.Init(seed);
			Random.InitState(seed);
			_random.InitState((uint)seed);
		}

		public override void RunGenRoutine() {
			if ( IsRunning ) {
				return;
			}
			_routineRuuning = true;
			GameManager.Instance.StartCoroutine(ParallelGenRoutine());
		}

		IEnumerator ParallelGenRoutine() {
			while ( _chunkGenQueue.Count > 0 ) {
				Profiler.BeginSample("Chunk procgen");

				if ( !_chunkGenQueue.TryDequeue(out var chunkPos) ) {
					break;
				}
				var x = chunkPos.X;
				var z = chunkPos.Z;
				var heightmapJob = new HeightGenJob() {
					BaseScale = 20,
					Seed = _seed,
					SizeX = Chunk.CHUNK_SIZE_X,
					SizeY = Chunk.CHUNK_SIZE_Z,
					OffsetX = Chunk.CHUNK_SIZE_X * x,
					OffsetY = Chunk.CHUNK_SIZE_Z * z,
					Height = new Unity.Collections.NativeArray<byte>(Chunk.CHUNK_SIZE_X * Chunk.CHUNK_SIZE_Z, Unity.Collections.Allocator.Persistent)
				};
				var hHandle = heightmapJob.Schedule(256, 128);
				hHandle.Complete();
				var waterLevel = Utils.WorldOptions.WaterLevel;
				var blockCount = Chunk.CHUNK_SIZE_X * Chunk.CHUNK_SIZE_Y * Chunk.CHUNK_SIZE_Z;
				var fillJob = new ChunkGenJob() {
					SizeH = Chunk.CHUNK_SIZE_X,
					SizeY = Chunk.CHUNK_SIZE_Y,
					Random = _random,
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
				Profiler.EndSample();
				if ( !ImmediateMode ) {
					yield return new WaitForEndOfFrame();
				}
				fillHandler.Complete();

				var readyChunk = new GeneratedChunkData(new Int3(x * Chunk.CHUNK_SIZE_X, 0, z * Chunk.CHUNK_SIZE_Z), fillJob.Blocks.ToArray(), heightmapJob.Height.ToArray(), maxY + 1, waterLevel);
				_readyChunks.Enqueue(readyChunk);

				heightmapJob.Height.Dispose();
				fillJob.Blocks.Dispose();
			}
			_routineRuuning = false;
			yield break;
		}
	}
}
