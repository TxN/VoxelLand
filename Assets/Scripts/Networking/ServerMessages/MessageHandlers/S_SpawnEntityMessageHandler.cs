using UnityEngine;

using Voxels.Networking.Clientside;
using Voxels.Utils;

using ZeroFormatter;

namespace Voxels.Networking {
	public class S_SpawnEntityMessageHandler : BaseServerMessageHandler {

		public override ServerPacketID CommandId {
			get {
				return ServerPacketID.SpawnEntity;
			}
		}

		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<S_SpawnEntityMessage>(rawCommand);
			var ec = ClientDynamicEntityController.Instance;
			ec.SpawnEntity(command.UID, command.TypeName, command.Position, Quaternion.Euler(MathUtils.UnpackRotation(command.Rotation)), command.State);
		}
	}
}
