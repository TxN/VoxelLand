namespace Voxels.Networking.Serverside {
	public sealed class TimeSetChatCommand : ChatCommand {
		public override string Keyword {
			get {
				return "time_set";
			}
		}

		public override bool OpOnly {
			get {
				return false;
			}
		}

		public override string ProcessCommand(ClientState sender, string[] commandWords) {


			if ( commandWords.Length < 2 ) {
				return "<color=\"red\">Error! Time is not set.</color>";
			}

			float.TryParse(commandWords[1], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var time);

			ServerWorldStateController.Instance.SetDayTime(time);
			return "<color=\"blue\">Time set.</color>";
		}
	}
}
