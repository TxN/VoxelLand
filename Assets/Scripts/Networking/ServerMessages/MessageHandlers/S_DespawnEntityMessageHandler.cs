using Voxels.Networking.Clientside;

using ZeroFormatter;

namespace Voxels.Networking {
	public class S_DespawnEntityMessageHandler : BaseServerMessageHandler {

		public override ServerPacketID CommandId {
			get {
				return ServerPacketID.DespawnEntity;
			}
		}

		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<S_DespawnEntityMessage>(rawCommand);
			var ec = ClientDynamicEntityController.Instance;
			ec.DespawnEntity(command.UID);
		}
	}
}
