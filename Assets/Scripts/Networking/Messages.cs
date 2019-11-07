using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public struct HandshakeMessage {
		[Index(0)]
		public string Username;
		[Index(1)]
		public string Password;
		[Index(2)]
		public byte ClientVersion;

		public HandshakeMessage(string username, string password, byte clientVersion) {
			Username = username;
			Password = password;
			ClientVersion = clientVersion;
		}
	}
}