using System.Text;

namespace Voxels.Networking.Serverside {
	public sealed class HelpChatCommand : ChatCommand {
		public override string Keyword {
			get {
				return "help";
			}
		}
		public override bool OpOnly {
			get {
				return false;
			}
		}

		public override string Description => "Type 'help' to show all available commands. Type 'help <commandName>' to get command usage info.";

		public override string ProcessCommand(ClientState sender, string[] commandWords) {
			if ( commandWords.Length < 2 ) {
				return ListAllCommands(sender.IsOp);
			}

			return GetCommandUsageInfo(commandWords[1], sender.IsOp);
		}

		string GetCommandUsageInfo(string commandName, bool showOpCommand) {
			var notFoundMessage = $"<color=\"red\"> Command '{commandName}' not found!</color>";
			if ( string.IsNullOrEmpty(commandName) ) {
				return notFoundMessage;
			}

			var commands = ServerChatManager.Instance.GetChatCommands();
			if ( commands.TryGetValue(commandName, out var command) && (!command.OpOnly || showOpCommand) ) {
				return  string.Format("<color=\"green\">Help for <color=\"white\">'{0}'</color> command:</color>\n{1}", command.Keyword, command.Description);
			}
			return notFoundMessage;
		}

		string ListAllCommands(bool showOpCommands) {
			var sb = new StringBuilder(256);
			sb.Append("List of all commands:\n");

			var commands = ServerChatManager.Instance.GetChatCommands();
			foreach ( var pair in commands ) {
				if ( pair.Value.OpOnly && !showOpCommands ) {
					continue;
				}
				if ( pair.Value.OpOnly ) {
					sb.Append($"<color=\"red\">{pair.Key}</color>");
				} else {
					sb.Append(pair.Key);
				}
				sb.Append(", ");
			}

			sb.Append("\nType 'help <commandName>' to get usage info.");
			return sb.ToString();
		}
	}
}
