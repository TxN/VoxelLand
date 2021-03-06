using Voxels.Networking.Serverside;

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

	public struct OnNewClientRegistered {
		public string Name;
	}

	public struct OnServerReceivedChatMessage {
		public ClientState Sender;
		public string      Message;
	}

	public struct OnServerPlayerDespawn {
		public PlayerEntity Player;
	}

	public struct OnServerPlayerSpawn {
		public ClientState  Client;
		public PlayerEntity Player;
	}

	public struct OnServerChunkGenerated {
		public GeneratedChunkData ChunkData;
	}

	public struct OnServerChunkLoadedFromDisk {
		public Int3  Index;
		public Chunk DeserializedChunk;
	}

	public struct OnServerChunkGenQueueEmpty {

	}

	public struct OnServerInitializationFinished {

	}

	public struct OnServerReadyToSpawnNewPlayer {
		public int         ConnectionId;
		public ClientState State;
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
		public PlayerEntity     Player;
		public PosUpdateOptions Flags;
	}

	public struct OnClientPlayerSpawn {
		public PlayerEntity Player;
	}

	public struct OnClientPlayerDespawn {
		public PlayerEntity Player;
	}

	public struct OnClientReceiveChunk {
		public ChunkData Data;
	}
}