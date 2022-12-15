namespace Voxels.Networking {
	public class ServerInfo {
		public SState State      = SState.Disconneted;
		public string Ip         = string.Empty;
		public string ServerName = string.Empty;
		public string Motd       = string.Empty;

	}

	public enum SState : byte {
		Disconneted,
		Handshake,
		Connected
	}
}

