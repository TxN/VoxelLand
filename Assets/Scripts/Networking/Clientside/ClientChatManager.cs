using System;
using System.Collections.Generic;

using SMGCore.EventSys;
using Voxels.Networking.Events;

namespace Voxels.Networking.Clientside {
	public class ClientChatManager : ClientsideController<ClientChatManager> {
		public ClientChatManager(ClientGameManager owner) : base(owner) { }

		List<ChatMessage> _messages = new List<ChatMessage>();

		public override void PostLoad() {
			base.PostLoad();
			EventManager.Subscribe<OnClientReceivedChatMessage>(this, OnChatMessageReceived);
		}

		public override void Reset() {
			base.Reset();
			EventManager.Unsubscribe<OnClientReceivedChatMessage>(OnChatMessageReceived);
		}

		public void SendMessage(string message) {
			var cc = ClientController.Instance;
			cc.SendNetMessage(ClientPacketID.ChatMessage, new C_ChatMessage { MessageText = message });
		}

		void OnChatMessageReceived(OnClientReceivedChatMessage e) {
			var msg = new ChatMessage(e.Sender, e.Message, DateTime.Now);
			_messages.Add(msg);
		}
	}
}

