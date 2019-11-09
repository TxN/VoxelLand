using System;
using System.Collections.Generic;

using UnityEngine;

using SMGCore;
using Voxels.Networking.Serverside;

namespace Voxels.Networking {
	public sealed class ServerGameManager {	

		Dictionary<string, BaseServersideController> _controllers = new Dictionary<string, BaseServersideController>();

		public void Create() {
			_controllers.Add("server",      new ServerController(this));
			_controllers.Add("chat-server", new ServerChatManager(this));

		}

		void Reset() {
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
				pair.Value.Update();
			}
		}
	}

}
