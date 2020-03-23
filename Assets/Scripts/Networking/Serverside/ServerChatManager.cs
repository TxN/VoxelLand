using System;
using System.Collections.Generic;

using SMGCore.EventSys;
using Voxels.Networking.Events;

using LiteDB;

namespace Voxels.Networking.Serverside {
	public sealed class ServerChatManager : ServerSideController<ServerChatManager> {
		public ServerChatManager(ServerGameManager owner) : base(owner) { }

		const string COMMAND_START_SYMBOL      = "/";
		const string OP_COMMAND_REJECT_MESSAGE = "<color=\"red\">This command is OP only.</color>";

		List<ChatMessage>               _messages = new List<ChatMessage>();
		Dictionary<string, ChatCommand> _commands = new Dictionary<string, ChatCommand>();
		ILiteCollection<ChatMessage>    _db       = null;

		public override void Init() {
			base.Init();
			_commands.Add("none",     new NoneChatCommand());
			_commands.Add("kick",     new KickChatCommand());
			_commands.Add("time_set", new TimeSetChatCommand());
			_commands.Add("tp",       new TeleportChatCommand());
			_commands.Add("spawn",    new TeleportToSpawnChatCommand());
			_commands.Add("home",     new TeleportToHomeChatCommand());
			_commands.Add("setspawn", new SetSpawnChatCommand());
			_commands.Add("sethome",  new SetHomeChatCommand());
		}

		public override void PostLoad() {
			base.PostLoad();
			EventManager.Subscribe<OnServerReceivedChatMessage>(this, OnChatMessageReceived);
			_db = ServerSaveLoadController.Instance.GetChatDatabase();
		}

		public override void Reset() {
			base.Reset();
			_commands.Clear();
			EventManager.Unsubscribe<OnServerReceivedChatMessage>(OnChatMessageReceived);
		}

		public void SendToClient(ClientState client, string senderName, string message, ChatMessageType type) {
			var server = ServerController.Instance;
			server.SendNetMessage(client, ServerPacketID.ChatMessage, new S_ChatMessage { SenderName = senderName, MessageText = message, Type = type  });
		}

		public void BroadcastFromServer(ChatMessageType type, string message) {
			var serverName = "Server";
			var msg = new ChatMessage(serverName, message, type, DateTime.Now);
			_messages.Add(msg);
			SendToAll(serverName, message, type);
			_db.Insert(msg);
		}

		void SendToAll(string senderName, string message, ChatMessageType type) {
			ServerController.Instance.SendToAll(ServerPacketID.ChatMessage, new S_ChatMessage { SenderName = senderName, MessageText = message, Type = type });
		}

		void TryProcessCommand(ClientState sender, string message) {
			var parts = message.Split(' ');
			if ( parts.Length == 0 ) {
				return;
			}

			var output = string.Empty;

			var firstWord = parts[0].Replace("/", "").ToLower();
			if ( _commands.TryGetValue(firstWord, out var handler) ) {
				if ( handler.OpOnly && !sender.IsOp ) {
					output = OP_COMMAND_REJECT_MESSAGE;
				} else {
					output = handler.ProcessCommand(sender, parts);
				}				
			} else {
				output = _commands["none"].ProcessCommand(sender, parts);
			}

			if ( !string.IsNullOrEmpty(output) ) {
				SendToClient(sender, "Server", output, ChatMessageType.Raw);
			}
		}

		void OnChatMessageReceived(OnServerReceivedChatMessage e) {
			if ( e.Message.StartsWith(COMMAND_START_SYMBOL) ) {
				TryProcessCommand(e.Sender, e.Message);
				return;
			}		
			var msg = new ChatMessage(e.Sender.UserName, e.Message, ChatMessageType.Player, DateTime.Now);
			_messages.Add(msg);
			SendToAll(msg.PlayerName, msg.Message, ChatMessageType.Player);
			_db.Insert(msg);
		}
	}
}
