using UnityEngine;

using SMGCore;
using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Networking;

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
				if ( !_serverManager.Initialized ) {
					EventManager.Subscribe<OnServerInitializationFinished>(this, OnServerInitializationFinished);
					return;
				}
			}
			System.Threading.Thread.Sleep(50);
			TryStartClient();
		}

		void Update() {
			if ( IsServer ) {
				_serverManager.UpdateControllers();
			}

			if ( IsClient ) {
				_clientManager.UpdateControllers();
			}
		}

		void LateUpdate() {
			if ( IsServer ) {
				_serverManager.LateUpdateControllers();
			}

			if ( IsClient ) {
				_clientManager.LateUpdateControllers();
			}
		}

		void OnDestroy() {
			EventManager.Unsubscribe<OnServerInitializationFinished>(OnServerInitializationFinished);
		}

		void TryStartClient() {
			if ( !IsClient ) {
				return;
			}
			_clientManager = new ClientGameManager();
			_clientManager.Create();
			_clientManager.Init();
			_clientManager.PostInit();
			_clientManager.Load();
			_clientManager.PostLoad();
		}

		void OnServerInitializationFinished(OnServerInitializationFinished e) {
			TryStartClient();
		}
	}
}

