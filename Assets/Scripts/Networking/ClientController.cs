using System.IO;
using System.Collections.Generic;

using UnityEngine;

using SMGCore;
using SMGCore.EventSys;
using Voxels.Networking.Events;

using Telepathy;
using ZeroFormatter;

namespace Voxels.Networking {
	public class ClientController : ClientsideController<ClientController> {
		const int PROTOCOL_VERSION = 1;
		string _serverIp       = string.Empty;
		int    _port           = 0;
		Client _client         = null;
		long _packetsReceived  = 0;
		long _packetsSent      = 0;
		ServerInfo _serverInfo = null;


		Dictionary<ServerPacketID, BaseServerMessageHandler> _handlers = new Dictionary<ServerPacketID, BaseServerMessageHandler>();

		public static int ProtocolVersion {
			get { return PROTOCOL_VERSION; }
		}

		public ServerInfo ServerInfo { get { return _serverInfo; } }
        public string     ClientName { get; private set; } = string.Empty;
        public string     Password   { get; private set; } = string.Empty;

		public bool IsStarted { get; private set; }

		public ClientController(ClientGameManager owner) : base(owner) {
		}

		public override void PostLoad() {
			base.PostLoad();
			StartClient("TestClient", "" ,"localhost",1337);
		}

		public override void Update() {
			MainCycle();
		}

		public void StartClient(string name, string password, string ip,int port) {
			if ( IsStarted ) {
				return;
			}
			_handlers.Clear();

			_handlers.Add(ServerPacketID.Identification,  new S_HandshakeMessageHandler());
			_handlers.Add(ServerPacketID.ForceDisconnect, new S_ForceDisconnectMessageHandler());
			_handlers.Add(ServerPacketID.JoinSuccess,     new S_JoinSuccessMessageHandler());
			_handlers.Add(ServerPacketID.Ping,            new S_PingMessageHandler());
			_handlers.Add(ServerPacketID.ChatMessage,     new S_ChatMessageHandler());

			ClientName = name;
			Password = password;

			_serverInfo = new ServerInfo();
			_serverInfo.Ip = ip;
			_packetsReceived = 0;
			_packetsSent = 0;
			_client = new Client();
			_client.Connect(ip, port);
			_port = port;
			IsStarted = true;
		}

		public void Disconnect() {
			if ( !IsStarted || _client == null ) {
				return;
			}

			_client.Disconnect();
			IsStarted = false;
		}

		public void SendNetMessage<T>(ClientPacketID id, T message, bool compress = false) where T : BaseMessage {
			var body = ZeroFormatterSerializer.Serialize(message);
			var header = new PacketHeader((byte)id, compress, (ushort)body.Length);
			if ( compress ) {
				_client.Send(NetworkUtils.CreateMessageBytes(header, CLZF2.Compress(body)));
			} else {
				_client.Send(NetworkUtils.CreateMessageBytes(header, body));
			}
			_packetsSent++;
		}

		void MainCycle() {
			if ( !IsStarted ) {
				return;
			}
			while ( _client.GetNextMessage(out Message msg) ) {
				switch ( msg.eventType ) {
					case Telepathy.EventType.Connected:
						OnConnect(msg);
						break;
					case Telepathy.EventType.Data:
						OnDataReceived(msg);
						break;
					case Telepathy.EventType.Disconnected:
						OnDisconnect(msg);
						break;
					default:
						break;
				}
			}
		}

		void OnConnect(Message msg) {
			Debug.Log("Conneted to server. Awaiting handshake.");
		}

		void OnDataReceived(Message msg) {
			_packetsReceived++;
			if ( msg.data.Length < PacketHeader.MinPacketLength ) {
				return;
			}
			using ( var str = new MemoryStream(msg.data) ) {
				var header = new PacketHeader(msg.data);
				var data = new byte[header.ContentLength];
				str.Seek(PacketHeader.MinPacketLength, SeekOrigin.Begin);
				str.Read(data, 0, header.ContentLength);
				if ( header.Compressed ) {
					ProcessReceivedMessage((ServerPacketID)header.PacketID, CLZF2.Decompress(data));
				}
				else {
					ProcessReceivedMessage((ServerPacketID)header.PacketID, data);
				}
			}
		}

		void ProcessReceivedMessage(ServerPacketID id, byte[] message) {
			_handlers.TryGetValue(id, out var handler);
			if ( handler != null ) {
				handler.ProcessMessage(message);
			}
		}

		void OnDisconnect(Message msg) {
			if ( IsStarted ) {
				Disconnect();
			}
			Debug.LogFormat("Disconnect from server.");
			EventManager.Fire(new OnDisconnectedFromServer() {
			});
		}
	}
}

