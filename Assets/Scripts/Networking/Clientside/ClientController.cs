using System.IO;
using System.Collections.Generic;

using UnityEngine;

using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Networking.Utils;

using Telepathy;
using ZeroFormatter;

namespace Voxels.Networking.Clientside {
	public class ClientController : ClientsideController<ClientController> {
		const int PROTOCOL_VERSION      = 1;
		const int MAX_MESSAGES_PER_TICK = 500;
		string     _serverIp         = string.Empty;
		int        _port             = 0;
		Client     _client           = null;
		ulong       _packetsReceived = 0;
		ulong       _packetsSent     = 0;
		ulong       _bytesReceived   = 0;
		ulong       _bytesSent       = 0;
		ServerInfo  _serverInfo      = null;

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
			StartClient(NetworkOptions.PlayerName, NetworkOptions.Password ,NetworkOptions.ServerIP,1337);
		}

		public override void Update() {
			MainCycle();
		}

		public override void Reset() {
			base.Reset();
			Disconnect();
		}

		public void StartClient(string name, string password, string ip,int port) {
			if ( IsStarted ) {
				return;
			}
			FillHandlers();

			ClientName = name;
			Password = password;

			_serverInfo      = new ServerInfo();
			_serverInfo.Ip   = ip;
			_packetsReceived = 0;
			_packetsSent = 0;
			_client = new Client(65535);
			_client.OnConnected += OnConnect;
			_client.OnDisconnected += OnDisconnect;
			_client.OnData += OnDataReceived;
			_client.Connect(ip, port);
			_port = port;
			IsStarted = true;	
		}

		void FillHandlers() {
			_handlers.Clear();
			var arr = ReflectionUtility.GetSubclasses(typeof(BaseServerMessageHandler));
			foreach ( var item in arr ) {
				var handler = (BaseServerMessageHandler)ReflectionUtility.CreateObjectWithActivator(item);
				_handlers.Add(handler.CommandId, handler);
			}
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
			uint size = 0;
			if ( compress ) {
				var compressedBody   = CLZF2.Compress(body);
				header.ContentLength = (ushort) compressedBody.Length;
				_client.Send(NetworkUtils.CreateMessageBytes(header, compressedBody, out size));
			} else {
				_client.Send(NetworkUtils.CreateMessageBytes(header, body, out size));
			}
			_bytesSent += size;
			_packetsSent++;
		}

		void MainCycle() {
			if ( !IsStarted ) {
				return;
			}
			_client.Tick(MAX_MESSAGES_PER_TICK);
		}

		void OnConnect() {
			Debug.Log("Conneted to server. Awaiting handshake.");
		}

		void OnDataReceived(System.ArraySegment<byte> msg) {
			_packetsReceived++;
			_bytesReceived += (uint)msg.Array.Length;
			if ( msg.Array.Length < PacketHeader.MinPacketLength ) {
				return;
			}
			using ( var str = new MemoryStream(msg.Array) ) {
				var header = new PacketHeader(msg.Array);
				var data = new byte[header.ContentLength];
				str.Seek(PacketHeader.MinPacketLength, SeekOrigin.Begin);
				str.Read(data, 0, header.ContentLength);
				if ( header.Compressed ) {
					ProcessReceivedMessage((ServerPacketID)header.PacketID, CLZF2.Decompress(data));
				} else {
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

		void OnDisconnect() {
			if ( IsStarted ) {
				Disconnect();
			}
			Debug.LogFormat("Disconnect from server.");
			EventManager.Fire(new OnDisconnectedFromServer() {
			});

			GameManager.Instance.GoToMainMenu();
		}
	}
}

