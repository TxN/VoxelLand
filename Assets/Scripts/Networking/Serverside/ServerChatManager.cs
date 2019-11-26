using System;
using System.Collections.Generic;

using SMGCore.EventSys;
using Voxels.Networking.Events;

namespace Voxels.Networking.Serverside {
	public class ServerChatManager : ServerSideController<ServerChatManager> {
		public ServerChatManager(ServerGameManager owner) : base(owner) { }

		const string COMMAND_START_SYMBOL = "/";

		List<ChatMessage> _messages = new List<ChatMessage>();

		Dictionary<string, ChatCommand> _commands = new Dictionary<string, ChatCommand>();

		public override void Init() {
			base.Init();
			_commands.Add("none", new NoneChatCommand());
			_commands.Add("kick", new KickChatCommand());
		}

		public override void PostLoad() {
			base.PostLoad();
			EventManager.Subscribe<OnServerReceivedChatMessage>(this, OnChatMessageReceived);
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
			_messages.Add(new ChatMessage(serverName, message, type, DateTime.Now));
			SendToAll(serverName, message, type);
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
				output = handler.ProcessCommand(sender, parts);
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
		}
	}
}
