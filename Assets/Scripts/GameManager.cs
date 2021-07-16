using System.Collections;
using System.Collections.Concurrent;

using UnityEngine;

using SMGCore;
using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Networking;

using Voxels.Networking.Utils;
using UnityEngine.SceneManagement;
using System;

namespace Voxels {
	public sealed class GameManager : ManualSingleton<GameManager> {

		const float RARE_UPDATE_INTERVAL = 1f;

		ConcurrentQueue<Func<IEnumerator>> _coroutineRequests = new ConcurrentQueue<Func<IEnumerator>>();

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

		ServerThreadRunner _serverRunner;
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
				_serverRunner.Cancel();
				System.Threading.Thread.Sleep(20);
			}
			if ( ClientAlive ) {
				_clientManager.Reset();
			}
			SceneManager.LoadScene("MainMenu");
		}

		public void StartCoroutineThreadSafe(Func<IEnumerator> enumerator) {
			if ( enumerator == null ) {
				return;
			}
			_coroutineRequests.Enqueue(enumerator);
		}

		void Start() {
			IsServer = NetworkOptions.StartServer;
			IsClient = NetworkOptions.StartClient;

			if ( IsServer ) {
				_serverManager = new ServerGameManager();
				_serverRunner  = new ServerThreadRunner();
				
				var thread = new System.Threading.Thread( ()=> {
					_serverRunner.Run(_serverManager, 50, 1000, new System.Threading.CancellationTokenSource());
					});
				thread.Start();
				System.Threading.Thread.Sleep(50);
				if ( !_serverManager.Initialized ) {
					Debug.Log("not Initialized");
					EventManager.Subscribe<OnServerInitializationFinished>(this, OnServerInitializationFinished);
					return;
				}
			}
			System.Threading.Thread.Sleep(10);
			TryStartClient();
			StartCoroutine(RareUpdate());
		}

		void Update() {
			while ( _coroutineRequests.TryDequeue(out var func) ) {
				var e = func();
				StartCoroutine(e);
			}
			if ( ClientAlive ) {
				_clientManager.UpdateControllers();
			}
		}

		void LateUpdate() {
			if ( ClientAlive ) {
				_clientManager.LateUpdateControllers();
			}
		}

		void OnDestroy() {
			EventManager.Unsubscribe<OnServerInitializationFinished>(OnServerInitializationFinished);

			StopAllCoroutines();
		}

		void OnApplicationQuit() {		
			if ( ClientAlive ) {
				Debug.Log("Shutting down client.");
				_clientManager.Save();
				_clientManager.Reset();
			}

			if ( ServerAlive ) {
				Debug.Log("Shutting down server.");
				_serverRunner.Cancel();
				System.Threading.Thread.Sleep(20);
			}
		}

		IEnumerator RareUpdate() {
			while (true) {
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
