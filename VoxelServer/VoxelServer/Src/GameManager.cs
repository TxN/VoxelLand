using SMGCore.EventSys;
using Voxels.Networking;

namespace Voxels {
	public sealed class GameManager {
		static GameManager _instance;
		public static GameManager Instance {
			get {
				if ( _instance == null ) {
					_instance = new GameManager();
				}
				return _instance;
			}
		}

		ServerThreadRunner _serverRunner;
		ServerGameManager  _serverManager = null;

		public bool IsServer => true;
		public bool IsClient => false;

		public ServerGameManager Server {
			get {
				return _serverManager;
			}
		}

		public bool ServerAlive {
			get {
				return _serverManager != null && _serverRunner != null;
			}
		}

		public void Start() {

			_serverManager = new ServerGameManager();
			_serverRunner = new ServerThreadRunner();

			var thread = new System.Threading.Thread(() => {
				_serverRunner.Run(_serverManager, 50, 1000, new System.Threading.CancellationTokenSource());
			});
			thread.Start();
			System.Threading.Thread.Sleep(50);
			if ( !_serverManager.Initialized ) {
				DebugOutput.Log("not Initialized");
				return;
			}
			System.Threading.Thread.Sleep(10);
		}

		public void Stop() {
			if ( ServerAlive ) {
				DebugOutput.Log("Shutting down server.");
				_serverRunner.Cancel();
				System.Threading.Thread.Sleep(20);
			}
		}
	}
}
