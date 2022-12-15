namespace Voxels.Networking.Serverside {
	public sealed class SaveChatCommand : ChatCommand {
		public override string Keyword {
			get {
				return "save";
			}
		}
		public override bool OpOnly {
			get {
				return true;
			}
		}

		public override string Description => "Forces server to save world to disk";

		public override string ProcessCommand(ClientState sender, string[] commandWords) {
			GameManager.Instance.Server.Save();
			return string.Format("<color=\"blue\">OK. Force save completed");
		}
	}
}
