using Voxels.Networking.Clientside;

using ZeroFormatter;

namespace Voxels.Networking {
	public class S_SpawnPlayerMessageHandler : BaseServerMessageHandler {

		public override ServerPacketID CommandId {
			get {
				return ServerPacketID.PlayerSpawn;
			}
		}

		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<S_SpawnPlayerMessage>(rawCommand);

			ClientPlayerEntityManager.Instance.SpawnPlayer(command.PlayerToSpawn);
		}
	}
}
