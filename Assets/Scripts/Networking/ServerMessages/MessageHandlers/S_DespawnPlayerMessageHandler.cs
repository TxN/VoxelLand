using Voxels.Networking.Clientside;

using ZeroFormatter;

namespace Voxels.Networking {
	public class S_DespawnPlayerMessageHandler : BaseServerMessageHandler {
		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<S_DespawnPlayerMessage>(rawCommand);

			ClientPlayerEntityManager.Instance.SpawnPlayer(command.PlayerToDespawn);
		}
	}
}
