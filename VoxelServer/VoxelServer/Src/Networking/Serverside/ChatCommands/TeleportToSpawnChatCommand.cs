namespace Voxels.Networking.Serverside {
	public sealed class TeleportToSpawnChatCommand : ChatCommand {
		public override string Keyword {
			get {
				return "spawn";
			}
		}

		public override string Description => "Teleport to spawn point.";

		public override string ProcessCommand(ClientState sender, string[] commandWords) {

			var pc = ServerPlayerEntityManager.Instance;
			var playerEntity = pc.GetPlayerByOwner(sender);
			if ( playerEntity == null ) {
				return string.Empty;
			}
			var pos = pc.GetSpawnPosition(playerEntity);
			var flags = PosUpdateOptions.Teleport;
			PosUpdateOptionsHelper.Set(ref flags, PosUpdateOptions.Force);
			pc.BroadcastPlayerPosUpdate(sender, pos, playerEntity.CompressedPitch, playerEntity.CompressedYaw, flags);

			return "<color=\"blue\">Teleporting you to spawn point.</color>";
		}
	}
}
