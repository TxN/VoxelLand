using System;

using LiteDB;

namespace Voxels.Networking {
	public enum ChatMessageType: byte {
		Raw,
		Info,
		Player
	}

	public sealed class ChatMessage {
		const string SIMPLE_FORMAT        = "{0} {1}: {2}";
		const string PLAYER_CHAT_FORMAT   = "<<color=\"green\">{0}</color>> {1}";
		const string INFO_CHAT_FORMAT     = "<color=\"green\">{0}</color>";
		const string RAW_CHAT_FORMAT      = "{0}";

		[BsonId]
		public int             Id         { get; set; } //for database storage
		public string          PlayerName { get; set; }
		public string          Message    { get; set; }
		public DateTime        Time       { get; set; }
		public ChatMessageType Type       { get; set; }

		string _cachedString     = string.Empty;
		string _cachedChatString = string.Empty;

		public ChatMessage(string playerName, string message, ChatMessageType type, DateTime time) {
			PlayerName = playerName;
			Message    = message;
			Time       = time;
			Type       = type;
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
			switch ( Type ) {
				case ChatMessageType.Raw:
					_cachedChatString = string.Format(RAW_CHAT_FORMAT, Message);
					break;
				case ChatMessageType.Info:
					_cachedChatString = string.Format(INFO_CHAT_FORMAT, Message);
					break;
				case ChatMessageType.Player:
					_cachedChatString = string.Format(PLAYER_CHAT_FORMAT, PlayerName, Message);
					break;
				default:
					break;
			}
			
			return _cachedChatString;
		}
	}
}
