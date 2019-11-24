namespace Voxels.Networking {

	//Packets sent by server
	public enum ServerPacketID : byte {
		Identification,
		Ping,
		JoinSuccess,
		ForceDisconnect,
		ChatMessage,
		PlayerSpawn,
		PlayerDespawn,
		PlayerUpdate,
		WorldOptions,
		ChunkInit,
		LoadFinalize,
		PutBlock,
		None = 255
	}

	//Packets sent by client
	public enum ClientPacketID : byte {
		Identification,
		Pong,
		ChatMessage,
		PlayerUpdate,
		PutBlock,
		None = 255
	}
}