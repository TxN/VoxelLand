using System.Threading;

namespace Voxels {
	public class ChunkDeserializer {
		public bool Busy  { get; private set; }
		public bool Ready { get; private set; }

		Thread    _curentThread = null;
		ChunkData _data         = null;
		Chunk     _result       = null;

		public void StartDeserialize(ChunkData data) {
			if ( _curentThread != null && _curentThread.IsAlive ) {
				_curentThread.Abort();
			}
			Busy = true;
			_data = data;
			_curentThread = new Thread(StartJob) {
				Name = "Deserialize Job"
			};
			_curentThread.Start();
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
			Ready = false;
			if ( _data != null ) {
				_result = new Chunk(_data);
			}
			Ready = true;
			Busy  = false;
		}
	}
}
