using System.Threading;

using Voxels.Networking;

namespace Voxels {
	public class ServerThreadRunner {
		CancellationTokenSource _cancellationTokenSource;

		public void Run(ServerGameManager server, int tickTime, int rareTickTime, CancellationTokenSource cancellationTokenSource) {
			_cancellationTokenSource = cancellationTokenSource;

			server.Create(tickTime /(float)1000);
			server.Init();
			server.PostInit();
			server.Load();
			Thread.Sleep(tickTime);
			server.PostLoad();

			var rareTickCount = rareTickTime / tickTime;
			Thread.Sleep(tickTime);
			int counter = 0;
			while (!_cancellationTokenSource.Token.IsCancellationRequested) {
				server.UpdateControllers();
				server.LateUpdateControllers();
				
				Thread.Sleep(tickTime);
				counter++;
				if ( counter >= rareTickCount ) {
					counter = 0;
					server.RareUpdateControllers();
				}
			}

			server.Save();
			server.Reset();
		}

		public void Cancel() {
			_cancellationTokenSource.Cancel();
		}
	}
}
