using Voxels.Networking.Clientside;


using ZeroFormatter;

namespace Voxels.Networking {
	public class S_ChatMessageHandler : BaseServerMessageHandler {
		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<S_ChatMessage>(rawCommand);

			ClientChatManager.Instance.AddReceivedMessage(command.SenderName, command.MessageText, command.Type);
		}
	}
}

