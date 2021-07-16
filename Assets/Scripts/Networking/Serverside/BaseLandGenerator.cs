using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Voxels.Networking.Serverside {
	public abstract class BaseLandGenerator {
		protected int _seed = 0;
		protected ConcurrentQueue<Int3>               _chunkGenQueue = new ConcurrentQueue<Int3>();
		protected ConcurrentQueue<GeneratedChunkData> _readyChunks   = new ConcurrentQueue<GeneratedChunkData>();
		public abstract bool IsRunning { get; }

		public bool ImmediateMode { get; set; }
		public int QueueCount => _chunkGenQueue.Count;

		public virtual void Init(int seed) {
			_seed = seed;
		}

		public GeneratedChunkData TryGetGeneratedChunk() {
			if ( _readyChunks.TryDequeue(out var readyChunk) ) {
				return readyChunk;
			}
			return null;
		}

		public virtual void ClearQueue() {
			while ( _chunkGenQueue.TryDequeue(out var c) ) {
				continue;
			}
		}

		public virtual void AddToQueue(Int3 newChunk, bool run) {
			_chunkGenQueue.Enqueue(newChunk);
			if ( run ) {
				RunGenRoutine();
			}
		}

		public void RefreshQueue(List<Int3> newChunks) {
			ClearQueue();
			foreach ( var item in newChunks ) {
				_chunkGenQueue.Enqueue(item);
			}
			RunGenRoutine();
		}

		public abstract void RunGenRoutine();
	}
}
