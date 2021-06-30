namespace Voxels.Networking.Serverside {
	public sealed class SetHomeChatCommand : ChatCommand {
		public override string Keyword {
			get {
				return "sethome";
			}
		}

		public override string Description => "Set your main home point (in which you may instantly teleport using 'home' command)";

		public override string ProcessCommand(ClientState sender, string[] commandWords) {

			var pc = ServerPlayerEntityManager.Instance;
			var playerEntity = pc.GetPlayerByOwner(sender);
			if ( playerEntity == null ) {
				return string.Empty;
			}
			pc.SetHomePoint(playerEntity.PlayerName, playerEntity.Position);

			return "<color=\"blue\">Home set.</color>";
		}
	}
}
