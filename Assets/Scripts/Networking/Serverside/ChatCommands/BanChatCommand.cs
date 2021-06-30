using System;

namespace Voxels.Networking.Serverside {
	public sealed class BanChatCommand : ChatCommand {
		public override string Keyword {
			get {
				return "ban";
			}
		}
		public override bool OpOnly {
			get {
				return true;
			}
		}

		public override string Description => "Ban player with name for selected amount of time. Usage: ban <type(ip/name)> <name/ip> <hours> <reason_one_word></color>";
		public override string ProcessCommand(ClientState sender, string[] commandWords) {

			if ( commandWords.Length < 5 ) {
				return "<color=\"red\">Error! Not enough arguments. Usage: ban <type> <name> <hours> <reason></color>";
			}
			var ipBan = commandWords[1] == "ip";

			if ( !float.TryParse(commandWords[2], out var duration) ) {
				return "<color=\"red\">Error! Cannot parse ban duration.</color>";
			}

			var reason = commandWords[4];

			var plyName = commandWords[2].ToLower();

			var endDate = DateTime.Now.AddHours(duration);

			if ( ipBan ) {
				ServerController.Instance.BanIp(plyName, endDate, reason);
			} else {
				ServerController.Instance.BanName(plyName, endDate, reason);
			}

			return ipBan ? BanIp(plyName) : BanName(plyName);
		}

		string BanName(string name) {
			var sc = ServerController.Instance;
			var cli = sc.GetClientByName(name);
			if ( cli != null ) {
				sc.ForceDisconnectClient(cli, "You've been banned.");
				return string.Format("<color=\"blue\">OK. {0} was banned.</color>", cli.UserName);
			}
			return "<color=\"red\">Error! Cannot find player</color>";
		}

		string BanIp(string ip) {
			var sc = ServerController.Instance;
			var cli = sc.GetClientByIP(ip);
			if ( cli != null ) {
				sc.ForceDisconnectClient(cli, "You've been banned.");
				return string.Format("<color=\"blue\">OK. {0} was banned.</color>", cli.UserName);
			}
			return "<color=\"red\">Error! Cannot find player</color>";
		}
	}
}
