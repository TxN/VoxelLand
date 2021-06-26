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
			var pc = ServerPlayerEntityManager.Instance;
			var player = pc.GetPlayerByOwner(client);
			if ( player == null ) {
				return;
			}

			var command = ZeroFormatterSerializer.Deserialize<C_PlayerActionMessage>(rawCommand);
			player.LookDir = new Vector2(command.LookPitch, command.LookYaw);
			Debug.Log($"Player pitch = {command.LookPitch}, yaw = {command.LookYaw}");
			switch ( command.Action ) {
				case PlayerActionType.None:
					break;
				case PlayerActionType.Use:
					ParseBlockInteractionAction(client);
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

		void ParseBlockInteractionAction(ClientState client) {
			var pc = ServerPlayerEntityManager.Instance;
			var player = pc.GetPlayerByOwner(client);
			if ( player == null ) {
				return;
			}
			if ( pc.GetBlockInSight(player, out var pos, out var block) ) {
				Debug.Log($"Player {client.UserName} tried to interact with block of type {block.Type} at {pos} .");
			} else {
				Debug.Log($"Player {client.UserName} tried to interact with nothing");
			}
		}
	}
}