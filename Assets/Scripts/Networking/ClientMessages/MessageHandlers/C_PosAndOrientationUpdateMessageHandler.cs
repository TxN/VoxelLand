using Voxels.Networking.Serverside;

using ZeroFormatter;

namespace Voxels.Networking {
	public class C_PosAndOrientationUpdateMessageHandler : BaseClientMessageHandler {
		public override void ProcessMessage(ClientState client, byte[] rawCommand) {
			base.ProcessMessage(client, rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<C_PosAndOrientationUpdateMessage>(rawCommand);

			ServerPlayerEntityManager.Instance.BroadcastPlayerPosUpdate(client, command.Position, command.LookPitch, command.Yaw);
		}
	}
}
