using SMGCore.EventSys;
using Voxels.Networking.Events;

using ZeroFormatter;

namespace Voxels.Networking {
	public class S_ChatMessageHandler : BaseServerMessageHandler {
		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<S_ChatMessage>(rawCommand);

			EventManager.Fire(new OnClientReceivedChatMessage { Sender = command.SenderName, Message = command.MessageText });
		}
	}
}

