using System.Collections.Generic;

using UnityEngine;

using SMGCore;
using SMGCore.EventSys;
using Voxels.Networking.Events;

using Telepathy;

namespace Voxels.Networking {
	public class ServerController : MonoSingleton<ServerController> {

		Dictionary<int,ClientState> _clients = new Dictionary<int, ClientState>();

		int _port = 1337;
		Telepathy.Server _server = null;

		public bool IsStarted { get; private set; }

		void Start() {
			StartServer();			
		}

		void Update() {
			MainCycle();
		}

		public void StartServer() {
			if ( IsStarted ) {
				return;
			}
			_clients.Clear();
			_server = new Server();
			_server.Start(_port);
			IsStarted = true;
		}

		public void StopServer() {
			if ( !IsStarted || _server == null ) {
				return;
			}

			_server.Stop();
			IsStarted = false;
		}

		void MainCycle() {
			if ( !IsStarted ) {
				return;
			}
			while ( _server.GetNextMessage(out Message msg) ) {
				switch ( msg.eventType ) {
					case Telepathy.EventType.Connected:
						OnNewConnection(msg);
						break;
					case Telepathy.EventType.Data:
						OnDataReceived(msg);
						break;
					case Telepathy.EventType.Disconnected:
						OnClientDisconnect(msg);
						break;
					default:
						break;
				}
			}
		}

		void OnNewConnection(Message msg) {
			//TODO: send ack packet and register connection in handshake state.
		}

		void OnDataReceived(Message msg) {
			/*if ( msg.data.Length < PacketHeader.MinPacketLength ) {
				//TODO: send disconnect reason
				_server.Disconnect(msg.connectionId);
				return;
			}
			*/
		}

		void OnClientDisconnect(Message msg) {
			_clients.TryGetValue(msg.connectionId, out ClientState client);
			if ( client == null ) {
				return;
			}
			EventManager.Fire(new OnClientConnected() {
				ConnectionId = msg.connectionId,
				State = client
			});
			Debug.LogFormat("Player '{0}' with id '{1}' disconnected.");
			_clients.Remove(msg.connectionId);
		}

	}
}


