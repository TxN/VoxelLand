using UnityEngine;

using Voxels.Networking.Serverside;

using ZeroFormatter;

namespace Voxels.Networking {
	public class C_PlayerActionMessageHandler : BaseClientMessageHandler {
		public override ClientPacketID CommandId {
			get {
				return ClientPacketID.PlayerAction;
			}
		}

		public override void ProcessMessage(ClientState client, byte[] rawCommand) {
			base.ProcessMessage(client, rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<C_PlayerActionMessage>(rawCommand);
			switch ( command.Action ) {
				case PlayerActionType.None:
					break;
				case PlayerActionType.Use:
					break;
				case PlayerActionType.AltUse:
					break;
				case PlayerActionType.Drop:
					break;
				case PlayerActionType.Launch:
					ParseLaunchAction(client, command);
					break;
				default:
					break;
			}
		}

		void ParseLaunchAction(ClientState client, C_PlayerActionMessage command) {
			var pc = ServerPlayerEntityManager.Instance;
			var player = pc.GetPlayerByOwner(client);
			var rot = Quaternion.Euler(player.LookDir.x, player.LookDir.y, 0);
			EntityHelper.SpawnFallingBlock(new BlockData((BlockType)command.PayloadInt), player.Position + Vector3.up, rot * new Vector3(0, 4, 10));
		}
	}
}