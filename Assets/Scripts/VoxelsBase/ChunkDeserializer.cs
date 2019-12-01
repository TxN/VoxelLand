using System.Threading.Tasks;

using Voxels.Networking;

namespace Voxels {
	public class ChunkDeserializer {
		public bool Busy  { get; private set; }
		public bool Ready { get; private set; }

		Task               _currentTask  = null;
		S_InitChunkMessage _data         = null;
		Chunk              _result       = null;

		public void StartDeserialize(S_InitChunkMessage data) {
			if ( Busy || Ready ) {
				return;
			}
			Busy = true;
			_data = data;
			_currentTask = Task.Factory.StartNew(StartJob);
		}

		public Chunk GetResult() {
			if ( !Ready || Busy || _result == null ) {
				return null;
			}
			var tmp = _result;
			_result = null;
			_data = null;
			Ready = false;
			return tmp;
		}

		void StartJob() {
			var stopwatch = System.Diagnostics.Stopwatch.StartNew();
			Ready = false;
			if ( _data != null ) {
				var blocks = ChunkHelper.FromByteArray(_data.Blocks, _data.BlockCount);
				var desc = new ChunkData {
					Blocks = new BlockDataHolder(Chunk.CHUNK_SIZE_X, Chunk.CHUNK_SIZE_Y, Chunk.CHUNK_SIZE_Z, blocks),
					Height = _data.Height,
					IndexX = _data.IndexX,
					IndexY = _data.IndexY,
					IndexZ = _data.IndexZ,
					Origin = _data.Origin
				};
				_result = new Chunk(desc);
			}
			Ready = true;
			Busy  = false;
			stopwatch.Stop();
			//UnityEngine.Debug.Log(stopwatch.Elapsed.TotalMilliseconds);
		}
	}
}
