namespace Voxels.Networking.Events {
	public struct OnClientConnected {
		public int         ConnectionId;
		public ClientState State;
	}

	public struct OnClientDisconnected {
		public int ConnectionId;
		public ClientState State;
	}
}