using Voxels.Networking.Clientside;

using ZeroFormatter;

namespace Voxels.Networking {
	public class S_PlayerUpdateMessageHandler : BaseServerMessageHandler {
		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<S_PlayerUpdateMessage>(rawCommand);
			
			ClientPlayerEntityManager.Instance.UpdatePlayer(command.Player);
		}
	}
}
