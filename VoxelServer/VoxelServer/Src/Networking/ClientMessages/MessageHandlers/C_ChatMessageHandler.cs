using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Networking.Serverside;

using ZeroFormatter;


namespace Voxels.Networking {
	public class C_ChatMessageHandler : BaseClientMessageHandler {
		public override ClientPacketID CommandId {
			get {
				return ClientPacketID.ChatMessage;
			}
		}
		public override void ProcessMessage(ClientState client, byte[] rawCommand) {
			base.ProcessMessage(client, rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<C_ChatMessage>(rawCommand);
			EventManager.Fire(new OnServerReceivedChatMessage { Sender = client, Message = command.MessageText });
		}
	}
}
