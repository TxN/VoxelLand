using System;

namespace Voxels.Networking {
	public sealed class ChatMessage {
		public readonly string   PlayerName = string.Empty;
		public readonly string   Message    = string.Empty;
		public readonly DateTime Time       = DateTime.MinValue;

		public ChatMessage(string playerName, string message, DateTime time) {
			PlayerName = playerName;
			Message    = message;
			Time       = time;
		}
	}
}
