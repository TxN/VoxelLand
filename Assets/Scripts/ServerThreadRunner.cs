using System.Threading;

using Voxels.Networking;

namespace Voxels {
	public class ServerThreadRunner {
		CancellationTokenSource _cancellationTokenSource;

		public void Run(ServerGameManager server, int tickTime, int rareTickTime, CancellationTokenSource cancellationTokenSource) {
			_cancellationTokenSource = cancellationTokenSource;
			var sw = new System.Diagnostics.Stopwatch();
			sw.Start();
			server.Create(tickTime /(float)1000);
			server.Init();
			server.PostInit();
			server.Load();
			Thread.Sleep(tickTime);
			server.PostLoad();

			var rareTickCount = rareTickTime / tickTime;
			sw.Stop();
			DebugOutput.Log($"Server initialization time: {sw.ElapsedMilliseconds} ms");
			Thread.Sleep(tickTime);
			int counter = 0;
			
			while (!_cancellationTokenSource.Token.IsCancellationRequested) {
				sw.Restart();
				server.UpdateControllers();
				server.LateUpdateControllers();
				counter++;
				if ( counter >= rareTickCount ) {
					counter = 0;
					server.RareUpdateControllers();
				}
				sw.Stop();
				var waitTime = tickTime - sw.ElapsedMilliseconds;
				if ( waitTime < 0 ) {
					waitTime = 0;
				}
				Thread.Sleep((int)waitTime);				
			}

			server.Save();
			server.Reset();
		}

		public void Cancel() {
			_cancellationTokenSource.Cancel();
		}
	}
}
