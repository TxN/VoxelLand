using System;
using System.Collections.Generic;

using Voxels.Networking.Clientside;

using UnityEngine;

namespace Voxels.Networking {
	public class ClientGameManager {
		Dictionary<string, BaseClientsideController> _controllers = new Dictionary<string, BaseClientsideController>();

		public void Create() {
			_controllers.Add("client",         new ClientController(this));
			_controllers.Add("input-client",   new ClientInputManager(this));
			_controllers.Add("chat-client",    new ClientChatManager(this));
			_controllers.Add("players-client", new ClientPlayerEntityManager(this));
			_controllers.Add("chunks-client",  new ClientChunkManager(this));
			_controllers.Add("dynamic-entity", new ClientDynamicEntityController(this));
			_controllers.Add("ui-client",      new ClientUIManager(this));
			_controllers.Add("world-client",   new ClientWorldStateController(this));
		}

		public void Reset() {
			foreach ( var pair in _controllers ) {
				try {
					pair.Value.Reset();
				}
				catch ( Exception e ) {
					Debug.LogError(e);
				}
			}
		}

		public void Init() {
			foreach ( var pair in _controllers ) {
				try {
					pair.Value.Init();
				}
				catch ( Exception e ) {
					Debug.LogError(e);
				}
			}
		}

		public void PostInit() {
			foreach ( var pair in _controllers ) {
				try {
					pair.Value.PostInit();
				}
				catch ( Exception e ) {
					Debug.LogError(e);
				}
			}
		}

		public void Load() {
			foreach ( var pair in _controllers ) {
				var name = pair.Key;
				var controller = pair.Value;
				controller.Load();
			}
		}

		public void PostLoad() {
			foreach ( var pair in _controllers ) {
				pair.Value.PostLoad();
			}
		}

		public void Save() {
			foreach ( var pair in _controllers ) {
				pair.Value.Save();
			}
		}

		public void UpdateControllers() {
			foreach ( var pair in _controllers ) {
				try {
					pair.Value.Update();
				}
				catch ( Exception e ) {
					DebugOutput.LogException(e);
				}
			}
		}

		public void LateUpdateControllers() {
			foreach ( var pair in _controllers ) {
				try {
					pair.Value.LateUpdate();
				}
				catch ( Exception e ) {
					DebugOutput.LogException(e);
				}
			}
		}

		public void RareUpdateControllers() {
			foreach ( var pair in _controllers ) {
				try {
					pair.Value.RareUpdate();
				}
				catch ( Exception e ) {
					DebugOutput.LogException(e);
				}
			}
		}

	}
}

