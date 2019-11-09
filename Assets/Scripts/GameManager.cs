using UnityEngine;

using Voxels.Networking;
using SMGCore;

namespace Voxels {
	public sealed class GameManager : MonoSingleton<GameManager> {

		public bool IsServer { get; private set; }
		public bool IsClient { get; private set; }

		ServerGameManager _serverManager = null;
		ClientGameManager _clientManager = null;

		void Start() {
			//TODO: получать настройки отуда-то еще, например из стартового меню.
			IsServer = true;
			IsClient = true;

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
	}
}

