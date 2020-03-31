using UnityEngine;

using Voxels.Networking.Clientside;
using Voxels.Utils;
using ZeroFormatter;

namespace Voxels.Networking {
	public class S_UpdateEntityPosMessageHandler : BaseServerMessageHandler {

		public override ServerPacketID CommandId {
			get {
				return ServerPacketID.UpdateEntityPos;
			}
		}

		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<S_UpdateEntityPosMessage>(rawCommand);
			var ec = ClientDynamicEntityController.Instance;
			ec.UpdatePosition(command.UID, PosUpdateType.Pos, command.Position, Quaternion.identity);
		}
	}

	public class S_UpdateEntityRotMessageHandler : BaseServerMessageHandler {

		public override ServerPacketID CommandId {
			get {
				return ServerPacketID.UpdateEntityRot;
			}
		}

		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<S_UpdateEntityRotMessage>(rawCommand);
			var ec = ClientDynamicEntityController.Instance;
			var uid = command.UID;
			var rot = command.Rotation;
			ec.UpdatePosition(uid, PosUpdateType.Rot, Vector3.zero, Quaternion.Euler(MathUtils.UnpackRotation(rot)));
		}
	}

	public class S_UpdateEntityPosRotMessageHandler : BaseServerMessageHandler {

		public override ServerPacketID CommandId {
			get {
				return ServerPacketID.UpdateEntityPosRot;
			}
		}

		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<S_UpdateEntityPosRotMessage>(rawCommand);
			var ec = ClientDynamicEntityController.Instance;
			ec.UpdatePosition(command.UID, PosUpdateType.PosRot, command.Position, Quaternion.Euler(MathUtils.UnpackRotation(command.Rotation)));
		}
	}
}
