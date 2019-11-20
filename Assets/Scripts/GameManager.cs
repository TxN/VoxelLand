using UnityEngine;

using Voxels.Networking;
using SMGCore;

using Voxels.Networking.Utils;
using UnityEngine.SceneManagement;

namespace Voxels {
	public sealed class GameManager : ManualSingleton<GameManager> {

		public bool IsServer { get; private set; }
		public bool IsClient { get; private set; }

		ServerGameManager _serverManager = null;
		ClientGameManager _clientManager = null;

		public ServerGameManager Server {
			get {
				return _serverManager;
			}
		}

		public ClientGameManager Client {
			get {
				return _clientManager;
			}
		}

		void Start() {
			IsServer = NetworkOptions.StartServer;
			IsClient = NetworkOptions.StartClient;

			if ( IsServer ) {
				_serverManager = new ServerGameManager();
				_serverManager.Create();
				_serverManager.Init();
				_serverManager.PostInit();
				_serverManager.Load();
				_serverManager.PostLoad();
			}
			System.Threading.Thread.Sleep(100);
			if ( IsClient ) {
				//TODO
				_clientManager = new ClientGameManager();
				_clientManager.Create();
				_clientManager.Init();
				_clientManager.PostInit();
				_clientManager.Load();
				_clientManager.PostLoad();
			}
		}

		void Update() {
			if ( IsServer ) {
				_serverManager.UpdateControllers();
			}

			if ( IsClient ) {
				_clientManager.UpdateControllers();
			}
		}

		public void GoToMainMenu() {
			//TODO: quit more properly.
			if ( IsServer ) {
				_serverManager.Reset();
			}
			if ( IsClient ) {
				_clientManager.Reset();
			}
			SceneManager.LoadScene("MainMenu");
		}
	}
}

