namespace Voxels.Networking.Serverside {
	public sealed class SetSpawnChatCommand : ChatCommand {
		public override string Keyword {
			get {
				return "setspawn";
			}
		}

		public override string Description => "Set your respawn point. You may intantly teleport to this point from everywhere using '/spawn' command.";

		public override string ProcessCommand(ClientState sender, string[] commandWords) {

			var pc = ServerPlayerEntityManager.Instance;
			var playerEntity = pc.GetPlayerByOwner(sender);
			if ( playerEntity == null ) {
				return string.Empty;
			}
			pc.SetSpawnPoint(playerEntity.PlayerName, playerEntity.Position);

			return "<color=\"blue\">Spawn point set.</color>";
		}
	}
}
