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
}