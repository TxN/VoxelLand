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
		PlayerPosAndRotUpdate,
		WorldOptions,
		ChunkInit,
		ChunkUnload,
		LoadFinalize,
		PutBlock,
		SpawnEntity,
		DespawnEntity,
		UpdateEntityPos,
		UpdateEntityRot,
		UpdateEntityPosRot,
		UpdateEntityData,
		EnityRPC,
		None = 255
	}

	//Packets sent by client
	public enum ClientPacketID : byte {
		Identification,
		Pong,
		ChatMessage,
		PlayerUpdate,
		PlayerPosAndRotUpdate,
		PutBlock,
		EntityRPC,
		PlayerAction,
		None = 255
	}
}
