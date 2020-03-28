namespace Voxels.Networking.Serverside {
	public sealed class UnbanChatCommand : ChatCommand {
		public override string Keyword {
			get {
				return "unban";
			}
		}
		public override bool OpOnly {
			get {
				return true;
			}
		}
		public override string ProcessCommand(ClientState sender, string[] commandWords) {

			if ( commandWords.Length < 3 ) {
				return "<color=\"red\">Error! Player name is not set.</color>";
			}
			var ipBan = commandWords[1] == "ip";
			var plyName = commandWords[2].ToLower();

			var sc = ServerController.Instance;
			if ( ipBan ) {
				sc.ClearIpBans(plyName);
			} else {
				sc.ClearNameBans(plyName);
			}
			return string.Format("<color=\"blue\">OK. clearing bans for {0}", plyName);
		}
	}
}
