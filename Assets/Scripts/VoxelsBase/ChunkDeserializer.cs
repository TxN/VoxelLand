using System.Threading.Tasks;

namespace Voxels {
	public class ChunkDeserializer {
		public bool Busy  { get; private set; }
		public bool Ready { get; private set; }

		Task      _currentTask  = null;
		ChunkData _data         = null;
		Chunk     _result       = null;

		public void StartDeserialize(ChunkData data) {
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
				_result = new Chunk(_data);
			}
			Ready = true;
			Busy  = false;
			stopwatch.Stop();
			//UnityEngine.Debug.Log(stopwatch.Elapsed.TotalMilliseconds);
		}
	}
}
