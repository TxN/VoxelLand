using System.Collections;

using UnityEngine;

using SMGCore;
using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Networking;

using Voxels.Networking.Utils;
using UnityEngine.SceneManagement;

namespace Voxels {
	public sealed class GameManager : ManualSingleton<GameManager> {

		const float RARE_UPDATE_INTERVAL = 1f;

		public bool IsServer { get; private set; }
		public bool IsClient { get; private set; }

		public bool ServerAlive {
			get {
				return IsServer && _serverManager != null;
			}
		}

		public bool ClientAlive {
			get {
				return IsClient && _clientManager != null;
			}
		}

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
			if ( ServerAlive ) {
				_serverManager.Reset();
			}
			if ( ClientAlive ) {
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
			StartCoroutine(RareUpdate());
		}

		void Update() {
			if ( ServerAlive ) {
				_serverManager.UpdateControllers();
			}

			if ( ClientAlive ) {
				_clientManager.UpdateControllers();
			}
		}

		void LateUpdate() {
			if ( ServerAlive ) {
				_serverManager.LateUpdateControllers();
			}

			if ( ClientAlive ) {
				_clientManager.LateUpdateControllers();
			}
		}

		void OnDestroy() {
			EventManager.Unsubscribe<OnServerInitializationFinished>(OnServerInitializationFinished);

			StopAllCoroutines();
		}

		IEnumerator RareUpdate() {
			while (true) {
				if ( ServerAlive ) {
					_serverManager.RareUpdateControllers();
				}

				if ( ClientAlive ) {
					_clientManager.LateUpdateControllers();
				}
				yield return new WaitForSeconds(RARE_UPDATE_INTERVAL);
			}
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

