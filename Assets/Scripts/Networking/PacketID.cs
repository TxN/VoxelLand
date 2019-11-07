namespace Voxels.Networking {

	//Packets sent by server
	public enum ServerPacketID : byte {
		Identification,
		Ping,
		Message,
		None = 255
	}

	//Packets sent by client
	public enum ClientPacketID : byte {
		Identification,
		Pong,
		Message,
		None = 255
	}
}