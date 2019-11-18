namespace Voxels.Networking.Events {
	/// <summary>
	/// Server Events
	/// </summary>
	public struct OnClientConnected {
		public int         ConnectionId;
		public ClientState State;
	}

	public struct OnClientDisconnected {
		public int ConnectionId;
		public ClientState State;
	}

	public struct OnServerReceivedChatMessage {
		public ClientState Sender;
		public string      Message;
	}

	public struct OnServerPlayerDespawn {
		public PlayerEntity Player;
	}

	public struct OnServerPlayerSpawn {
		public PlayerEntity Player;
	}

	/// <summary>
	/// Client Events
	/// </summary>
	public struct OnDisconnectedFromServer {

	}

	public struct OnForceDisconnectedFromServer {
		public string Reason;
	}

	public struct OnConnectSuccess {

	}

	public struct OnClientReceivedChatMessage {
		public string Sender;
		public string Message;
	}

	public struct OnClientPlayerUpdate {
		public PlayerEntity Player;
	}

	public struct OnClientPlayerSpawn {
		public PlayerEntity Player;
	}

	public struct OnClientPlayerDespawn {
		public PlayerEntity Player;
	}
}