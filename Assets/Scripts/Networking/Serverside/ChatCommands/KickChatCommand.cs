namespace Voxels.Networking.Serverside {
	public sealed class KickChatCommand : ChatCommand {
		public override string Keyword {
			get {
				return "kick";
			}
		}
		public override bool OpOnly {
			get {
				return true;
			}
		}
		public override string ProcessCommand(ClientState sender, string[] commandWords) {

			if ( commandWords.Length < 2 ) {
				return "<color=\"red\">Error! Player name is not set.</color>";
			}

			var plyName = commandWords[1].ToLower();
			var sc = ServerController.Instance;
			var cli = sc.GetClientByName(plyName);
			if ( cli != null ) {
				sc.ForceDisconnectClient(cli, "You've been kicked by admin.");
				return string.Format("<color=\"blue\">OK. Kicking {0}.</color>", cli.UserName);
			}

			return "<color=\"red\">Error! Cannot find player</color>";
		}
	}
}
