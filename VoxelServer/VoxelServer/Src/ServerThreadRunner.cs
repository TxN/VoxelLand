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
			sw.Stop();
			DebugOutput.Log($"Server initialized. Took: {sw.ElapsedMilliseconds} ms");
			var rareTickCount = rareTickTime / tickTime;
			Thread.Sleep(tickTime);
			int counter = 0;
			while (!_cancellationTokenSource.Token.IsCancellationRequested) {
				sw.Reset();
				sw.Start();
				server.UpdateControllers();
				server.LateUpdateControllers();

				counter++;
				if ( counter >= rareTickCount ) {
					counter = 0;
					server.RareUpdateControllers();
				}
				//DebugOutput.Log($"Tick: {sw.Elapsed.TotalMilliseconds} ms");
				Thread.Sleep(tickTime);
				
				sw.Stop();
				
			}

			server.Save();
			server.Reset();
		}

		public void Cancel() {
			_cancellationTokenSource.Cancel();
		}
	}
}
