using System.IO;
using System.Collections.Generic;

using UnityEngine;

using SMGCore;
using SMGCore.EventSys;
using Voxels.Networking.Events;

using Telepathy;
using ZeroFormatter;

namespace Voxels.Networking {
	public class ServerController : MonoSingleton<ServerController> {
		const int PROTOCOL_VERSION = 1;

		Dictionary<int,ClientState> _clients = new Dictionary<int, ClientState>();
		Dictionary<ClientPacketID, BaseClientMessageHandler> _handlers = new Dictionary<ClientPacketID, BaseClientMessageHandler>();

		string ServerName = "Untitled";
		string MOTD = "Greetings!";
		int _port = 1337;
		
		Telepathy.Server _server = null;

		public bool IsStarted { get; private set; }

		public static int ProtocolVersion {
			get { return PROTOCOL_VERSION; }
		}

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
			_handlers.Clear();
			_clients.Clear();

			_handlers.Add(ClientPacketID.Identification, new C_HandshakeMessageHandler());
			_handlers.Add(ClientPacketID.Pong,           new C_PongMessageHandler());
			_handlers.Add(ClientPacketID.ChatMessage,    new C_ChatMessageHandler());


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

		public void ForceDisconnectClient(ClientState client, string message) {
			//TODO: send disconnect message
			_server.Disconnect(client.ConnectionID);
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
			var state = new ClientState {
				ConnectionID = msg.connectionId,
				IpAdress = _server.GetClientAddress(msg.connectionId),
				CurrentState = CState.Handshake
			};
			_clients.Add(msg.connectionId, state);

			var body   = ZeroFormatterSerializer.Serialize(new S_HandshakeMessage { CommandID = (byte)ServerPacketID.Identification, MOTD = MOTD, ProtocolVersion = PROTOCOL_VERSION, ServerName = ServerName });
			var header = new PacketHeader((byte)ServerPacketID.Identification, false, (ushort) body.Length);
			_server.Send(msg.connectionId, CreateMessageBytes(header, body));
			Debug.LogFormat("Client with id {0} connecting. Sending handshake command.");
		}

		void OnDataReceived(Message msg) {
			if ( msg.data.Length < PacketHeader.MinPacketLength ) {
				return;
			}
			_clients.TryGetValue(msg.connectionId, out var client);
			using ( var str = new MemoryStream(msg.data)) {
				var header = new PacketHeader(msg.data);
				var data = new byte[header.ContentLength];
				str.Read(data, PacketHeader.MinPacketLength, header.ContentLength);
				if ( header.Compressed ) {	
					ProcessReceivedMessage(client, (ClientPacketID) header.PacketID, CLZF2.Decompress(data));
				} else {
					ProcessReceivedMessage(client, (ClientPacketID)header.PacketID, data);
				}
			}
		}

		void ProcessReceivedMessage(ClientState client, ClientPacketID id, byte[] message) {
			_handlers.TryGetValue(id, out var handler);
			if ( handler != null ) {
				handler.ProcessMessage(client, message);
			}
		}

		void OnClientDisconnect(Message msg) {
			_clients.TryGetValue(msg.connectionId, out ClientState client);
			if ( client == null ) {
				return;
			}
			EventManager.Fire(new OnClientDisconnected() {
				ConnectionId = msg.connectionId,
				State = client
			});
			Debug.LogFormat("Player '{0}' with id '{1}' disconnected.");
			_clients.Remove(msg.connectionId);
		}



		byte[] CreateMessageBytes(PacketHeader header, byte[] body) {
			var msg = new byte[header.ContentLength + body.Length];
			header.ToBytes(msg);
			body.CopyTo(msg, header.ContentLength);
			return msg;
		}

	}
}


