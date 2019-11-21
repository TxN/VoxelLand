using System;
using System.Collections.Generic;

using SMGCore.EventSys;
using Voxels.Networking.Events;

namespace Voxels.Networking.Clientside {
	public class ClientChatManager : ClientsideController<ClientChatManager> {
		public ClientChatManager(ClientGameManager owner) : base(owner) { }

        public List<ChatMessage> Messages { get; } = new List<ChatMessage>();

		public override void PostLoad() {
			base.PostLoad();
		}

		public override void Reset() {
			base.Reset();
		}

		public void AddReceivedMessage(string sender, string message) {
			var msg = new ChatMessage(sender, message, DateTime.Now);
			Messages.Add(msg);

			EventManager.Fire(new OnClientReceivedChatMessage { Sender = sender, Message = message });
		}

		public void SendMessage(string message) {
			var cc = ClientController.Instance;
			cc.SendNetMessage(ClientPacketID.ChatMessage, new C_ChatMessage { MessageText = message });
		}
	}
}

