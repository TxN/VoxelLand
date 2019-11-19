using System.IO;
using System.Collections.Generic;

using UnityEngine;

using SMGCore;
using SMGCore.EventSys;
using Voxels.Networking.Events;

using Telepathy;
using ZeroFormatter;

namespace Voxels.Networking {
	public class ServerController : ServerSideController<ServerController> {
		const int   PROTOCOL_VERSION = 1;
		const float PING_INTERVAL    = 10;
		
		public string ServerName = "Untitled";
		public string MOTD       = "Greetings!";

		Dictionary<int,ClientState>                          _clients  = new Dictionary<int, ClientState>();
		Dictionary<ClientPacketID, BaseClientMessageHandler> _handlers = new Dictionary<ClientPacketID, BaseClientMessageHandler>();

		int    _port            = 0;
		Server _server          = null;
		long   _packetsReceived = 0;
		long   _packetsSent     = 0;

		public static int ProtocolVersion {
			get { return PROTOCOL_VERSION; }
		}

		public bool IsStarted { get; private set; }

		public Dictionary<int,ClientState> Clients {
			get { return _clients; }
		}

		public long PacketsSent {
			get { return _packetsSent; }
		}

		public long PacketsReceived {
			get { return _packetsReceived; }
		}

		public ServerController(ServerGameManager owner) : base(owner) {
		}

		public override void PostLoad() {
			base.PostLoad();
			StartServer(1337);
		}

		public override void Update() {
			MainCycle();
		}

		public void StartServer(int port) {
			if ( IsStarted ) {
				return;
			}
			_handlers.Clear();
			_clients.Clear();

			_handlers.Add(ClientPacketID.Identification, new C_HandshakeMessageHandler());
			_handlers.Add(ClientPacketID.Pong,           new C_PongMessageHandler());
			_handlers.Add(ClientPacketID.ChatMessage,    new C_ChatMessageHandler());
			_handlers.Add(ClientPacketID.PlayerUpdate,   new C_PlayerUpdateMessageHandler());

			_packetsReceived = 0;
			_packetsSent     = 0;
			_server = new Server();
			_server.Start(port);
			_port = port;
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
			SendNetMessage(client, ServerPacketID.ForceDisconnect, new S_ForceDisconnectMessage { Reason = message });
			Debug.LogFormat("Client with id {0} force disconnected with reason: '{1}'", client.ConnectionID, message);
			_server.Disconnect(client.ConnectionID);
		}

		public void SendNetMessage<T>(ClientState client, ServerPacketID id, T message, bool compress = false) where T : BaseMessage {
			var body = ZeroFormatterSerializer.Serialize(message);
			var header = new PacketHeader((byte)id, compress, (ushort)body.Length);
			if ( compress ) {
				_server.Send(client.ConnectionID, NetworkUtils.CreateMessageBytes(header, CLZF2.Compress(body)));
			}
			else {
				_server.Send(client.ConnectionID, NetworkUtils.CreateMessageBytes(header, body));
			}
			_packetsSent++;
		}

		public void SendToAll<T>(ServerPacketID id, T message, bool compress = false) where T : BaseMessage {
			foreach ( var client in Clients ) {
				SendNetMessage(client.Value, id, message, compress);
			}
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
			SendPing();
		}

		void SendPing() {
			var now = System.DateTime.Now;
			foreach ( var pair in _clients ) {
				var cli = pair.Value;
				if ( cli.CurrentState == CState.Connected ) {
					if ( (now - cli.LastPingTime).TotalSeconds > PING_INTERVAL ) {
						cli.LastPingTime = now;
						SendNetMessage(cli, ServerPacketID.Ping, new S_PingMessage());
					}
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

			SendNetMessage(state, ServerPacketID.Identification, new S_HandshakeMessage { CommandID = (byte)ServerPacketID.Identification, MOTD = MOTD, ProtocolVersion = PROTOCOL_VERSION, ServerName = ServerName });
			Debug.LogFormat("Client with id {0} connecting. Sending handshake command.", msg.connectionId);
		}

		void OnDataReceived(Message msg) {
			_packetsReceived++;
			if ( msg.data.Length < PacketHeader.MinPacketLength ) {
				return;
			}
			_clients.TryGetValue(msg.connectionId, out var client);
			using ( var str = new MemoryStream(msg.data)) {
				var header = new PacketHeader(msg.data);
				var data = new byte[header.ContentLength];
				str.Seek(PacketHeader.MinPacketLength, SeekOrigin.Begin);
				str.Read(data, 0, header.ContentLength);
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
			Debug.LogFormat("Player '{0}' with id '{1}' disconnected.", client.UserName, msg.connectionId);
			_clients.Remove(msg.connectionId);
		}
	}
}
