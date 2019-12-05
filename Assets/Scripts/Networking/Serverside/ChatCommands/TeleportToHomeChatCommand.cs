namespace Voxels.Networking.Serverside {
	public sealed class TeleportToHomeChatCommand : ChatCommand {
		public override string Keyword {
			get {
				return "home";
			}
		}

		public override string ProcessCommand(ClientState sender, string[] commandWords) {

			var pc = ServerPlayerEntityManager.Instance;
			var playerEntity = pc.GetPlayerByOwner(sender);
			if ( playerEntity == null ) {
				return string.Empty;
			}
			var pos = pc.GetHomePosition(sender);
			var flags = PosUpdateOptions.Teleport;
			PosUpdateOptionsHelper.Set(ref flags, PosUpdateOptions.Force);
			pc.BroadcastPlayerPosUpdate(sender, pos, playerEntity.CompressedPitch, playerEntity.CompressedYaw, flags);

			return "<color=\"blue\">Teleporting you to your home.</color>";
		}
	}
}
