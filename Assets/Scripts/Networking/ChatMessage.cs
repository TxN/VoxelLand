using System;

namespace Voxels.Networking {
	public sealed class ChatMessage {
		const string SIMPLE_FORMAT = "{0} {1}: {2}";
		const string CHAT_FORMAT   = "<<color=\"green\">{0}</color>> {1}";

		public readonly string   PlayerName = string.Empty;
		public readonly string   Message    = string.Empty;
		public readonly DateTime Time       = DateTime.MinValue;

		string _cachedString = string.Empty;
		string _cachedChatString = string.Empty;

		public ChatMessage(string playerName, string message, DateTime time) {
			PlayerName = playerName;
			Message    = message;
			Time       = time;
		}

		public override string ToString() {
			if ( !string.IsNullOrEmpty(_cachedString) ) {
				return _cachedString;
			}
			_cachedString = string.Format(SIMPLE_FORMAT, Time.ToShortTimeString(), PlayerName, Message);
			return _cachedString;
		}

		public string ToChatString() {
			if ( !string.IsNullOrEmpty(_cachedChatString) ) {
				return _cachedChatString;
			}
			_cachedChatString = string.Format(CHAT_FORMAT, PlayerName, Message);
			return _cachedChatString;
		}
	}
}
