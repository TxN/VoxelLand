using Voxels.Networking.Clientside;

using ZeroFormatter;

namespace Voxels.Networking {
	public class S_PosAndOrientationUpdateMessageHandler : BaseServerMessageHandler {
		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<S_PosAndOrientationUpdateMessage>(rawCommand);

			ClientPlayerEntityManager.Instance.UpdatePlayerPos(command.ConId, command.Position, command.LookPitch, command.Yaw);
		}
	}
}
