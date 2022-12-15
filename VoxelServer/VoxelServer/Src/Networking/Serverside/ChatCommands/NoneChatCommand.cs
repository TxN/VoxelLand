namespace Voxels.Networking.Serverside {
	public sealed class NoneChatCommand : ChatCommand {
		public override string Keyword {
			get {
				return "none";
			}
		}
		public override string ProcessCommand(ClientState sender, string[] commandWords) {
			return "<color=\"red\">Command is not recognised! Try another.</color>";
		}
	}
}
