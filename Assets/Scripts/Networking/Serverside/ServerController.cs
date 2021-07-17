using System.IO;
using System.Collections.Generic;

using UnityEngine;

using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Networking.Utils;

using LiteDB;
using Telepathy;
using ZeroFormatter;
using JetBrains.Annotations;
using System;

namespace Voxels.Networking.Serverside {
	public class ServerController : ServerSideController<ServerController> {
		const int MAX_MESSAGES_PER_TICK = 1500;

		public bool EnableCompression = true;

		const int   PROTOCOL_VERSION = 1;
		const float PING_INTERVAL    = 10;

		ILiteCollection<ClientProfile>                       _clientsDB  = null;
		ILiteCollection<BanInfo>                             _bansDB     = null;
		Dictionary<int,ClientState>                          _clients    = new Dictionary<int, ClientState>();
		Dictionary<ClientPacketID, BaseClientMessageHandler> _handlers   = new Dictionary<ClientPacketID, BaseClientMessageHandler>();

		int     _port            = 0;
		Server  _server          = null;
		ulong   _packetsReceived = 0;
		ulong   _packetsSent     = 0;
		ulong   _bytesReceived   = 0;
		ulong   _bytesSent       = 0;

		public static int ProtocolVersion {
			get { return PROTOCOL_VERSION; }
		}

		public bool IsStarted { get; private set; }

		public Dictionary<int, ClientState> Clients => _clients;

		public ulong PacketsSent     => _packetsSent;
		public ulong PacketsReceived => _packetsReceived;
		public ulong BytesReceived   => _bytesReceived;
		public ulong BytesSent       => _bytesSent;

		public ServerController(ServerGameManager owner) : base(owner) {}

		public override void PostLoad() {
			base.PostLoad();
			StartServer(1337);
		}

		public override void Update() {
			MainCycle();
		}

		public override void Reset() {
			base.Reset();
			//TODO: force disconnect all players with reason
			StopServer();
		}

		public void StartServer(int port) {
			if ( IsStarted ) {
				return;
			}
			
			_clients.Clear();

			FillHandlers();

			_clientsDB = ServerSaveLoadController.Instance.GetClientsDatabase();
			_bansDB    = ServerSaveLoadController.Instance.GetBansDatabase();

			_packetsReceived = 0;
			_packetsSent     = 0;
			_bytesReceived   = 0;
			_bytesSent       = 0;
			_server = new Server(65535);
			_server.OnConnected += OnNewConnection;
			_server.OnDisconnected += OnClientDisconnect;
			_server.OnData += OnDataReceived;
			_server.Start(port);
			_port = port;
			IsStarted = true;
		}

		void FillHandlers() {
			_handlers.Clear();
			var arr = ReflectionUtility.GetSubclasses(typeof(BaseClientMessageHandler));
			foreach ( var item in arr ) {
				var handler = (BaseClientMessageHandler)ReflectionUtility.CreateObjectWithActivator(item);
				_handlers.Add(handler.CommandId, handler);
			}
		}

		public void StopServer() {
			if ( !IsStarted || _server == null ) {
				return;
			}

			_server.Stop();
			IsStarted = false;
		}

		[CanBeNull]
		public ClientState GetClientByName(string name) {
			name = name.ToLower();
			foreach ( var pair in _clients ) {
				if ( name == pair.Value.UserName.ToLower() ) {
					return pair.Value;
				}
			}
			return null;
		}

		[CanBeNull]
		public ClientState GetClientByIP(string ip) {
			foreach ( var pair in _clients ) {
				if ( ip == pair.Value.IpAdress ) {
					return pair.Value;
				}
			}
			return null;
		}

		public bool TryAuthenticate(ClientState client, string userName, string password, out bool newUser) {
			newUser = false;
			var profile = GetClientInfo(userName);
			if ( profile == null ) {
				profile = new ClientProfile { Name = userName, Password = password, Op = false };
				Debug.Log(string.Format("Registering new user with name '{0}'", userName));
				newUser = true;
				EventManager.Fire(new OnNewClientRegistered { Name = userName });
			}
			if ( profile.Password != password ) {
				return false;
			}
			profile.LastLoginTime = DateTime.Now;
			UpdateClientInfo(profile);
			client.UserName = profile.Name;
			client.IsOp = profile.Op;
			return true;
		}

		public bool IsClientBanned(string ip, string name, out BanInfo banInfo) {
			var ipBans = _bansDB.Find(i => i.IP == ip);
			foreach ( var ban in ipBans ) {
				if ( ban.BanEnd > DateTime.Now ) {
					banInfo = ban;
					return true;
				}
			}
			var nameBans = _bansDB.Find(i => i.Name == name);
			foreach ( var ban in nameBans ) {
				if ( ban.BanEnd > DateTime.Now ) {
					banInfo = ban;
					return true;
				}
			}
			banInfo = null;
			return false;
		}

		public void BanName(string name, DateTime endTime, string reason) {
			var info = new BanInfo {
				Name     = name,
				BanStart = DateTime.Now,
				BanEnd   = endTime,
				Reason   = reason
			};
			AddBan(info);
		}

		public void BanIp(string ip, DateTime endTime, string reason) {
			var info = new BanInfo {
				IP = ip,
				BanStart = DateTime.Now,
				BanEnd = endTime,
				Reason = reason
			};
			AddBan(info);
		}

		public void ClearNameBans(string name) {
			_bansDB.DeleteMany(x => x.Name == name);
		}

		public void ClearIpBans(string ip) {
			_bansDB.DeleteMany(x => x.IP == ip);
		}

		public void ForceDisconnectClient(ClientState client, string message) {
			SendNetMessage(client, ServerPacketID.ForceDisconnect, new S_ForceDisconnectMessage { Reason = message });
			Debug.LogFormat("Client with id {0} force disconnected with reason: '{1}'", client.ConnectionID, message);
			_server.Disconnect(client.ConnectionID);
		}

		public void SendNetMessage<T>(ClientState client, ServerPacketID id, T message, bool compress = false) where T : BaseMessage {
			var compressFlag = compress && EnableCompression;
			var body = ZeroFormatterSerializer.Serialize(message);
			SendRawNetMessage(client, id, body, compressFlag);
		}

		/// <summary>
		/// Используется в случае, когда надо отправить заранее отформатированный пакет в обход сериализатора (так как он может сильно тормозить на больших объемах данных)
		/// </summary>
		/// <param name="client">Клиент, которому отправляем сообщение</param>
		/// <param name="id">Код команды</param>
		/// <param name="body">Сообщение - массив байт</param>
		/// <param name="compress">Сжимать ли сообщение с помощью LZF</param>
		public void SendRawNetMessage(ClientState client, ServerPacketID id, byte[] body, bool compress = false) {
			var compressFlag = compress && EnableCompression;
			var header = new PacketHeader((byte)id, compressFlag, (ushort)body.Length);
			uint size;
			if ( compressFlag ) {
				var compressedBody = CLZF2.Compress(body);
				header.ContentLength = (ushort)compressedBody.Length;
				_server.Send(client.ConnectionID, NetworkUtils.CreateMessageBytes(header, compressedBody, out size));
			} else {
				_server.Send(client.ConnectionID, NetworkUtils.CreateMessageBytes(header, body, out size));
			}
			_packetsSent++;
			_bytesSent = _bytesSent + size;
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

			_server.Tick(MAX_MESSAGES_PER_TICK);
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

		void OnNewConnection(int connectionId) {
			var state = new ClientState {
				ConnectionID = connectionId,
				IpAdress = _server.GetClientAddress(connectionId),
				CurrentState = CState.Handshake
			};
			_clients.Add(connectionId, state);

			var motd       = Utils.NetworkOptions.Motd;
			var serverName = Utils.NetworkOptions.ServerName;
			SendNetMessage(state, ServerPacketID.Identification, new S_HandshakeMessage {
				CommandID = (byte)ServerPacketID.Identification, MOTD = motd, ProtocolVersion = PROTOCOL_VERSION, ServerName = serverName
			});
			Debug.LogFormat("Client with id {0} connecting. Sending handshake command.", connectionId);
		}

		void OnDataReceived(int connectionId, System.ArraySegment<byte> msg) {
			_packetsReceived++;
			_bytesReceived += (uint)msg.Array.Length;
			if ( msg.Array.Length < PacketHeader.MinPacketLength ) {
				return;
			}
			_clients.TryGetValue(connectionId, out var client);
			using ( var str = new MemoryStream(msg.Array)) {
				var header = new PacketHeader(msg.Array);
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

		void OnClientDisconnect(int connectionId) {
			_clients.TryGetValue(connectionId, out ClientState client);
			if ( client == null ) {
				return;
			}
			EventManager.Fire(new OnClientDisconnected() {
				ConnectionId = connectionId,
				State = client
			});
			Debug.LogFormat("Player '{0}' with id '{1}' disconnected.", client.UserName, connectionId);
			ServerChatManager.Instance.BroadcastFromServer(ChatMessageType.Info, string.Format("{0} left the server.", client.UserName));
			_clients.Remove(connectionId);
		}

		ClientProfile GetClientInfo(string name) {
			var result = _clientsDB.FindOne(x => x.Name == name);
			return result;
		}

		void UpdateClientInfo(ClientProfile info) {
			if ( info == null || string.IsNullOrEmpty(info.Name) ) {
				throw new ArgumentNullException("Client info is null or has invalid name");
			}
			if ( !_clientsDB.Update(info) ) {
				_clientsDB.Insert(info);

			}
			_clientsDB.EnsureIndex(x => x.Name);
		}

		void AddBan(BanInfo ban) {
			if ( ban == null ) {
				return;
			}
			_bansDB.Insert(ban);
		}
	}
}
