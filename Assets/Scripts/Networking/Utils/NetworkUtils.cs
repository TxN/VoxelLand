namespace Voxels.Networking {
	public static class NetworkUtils {
		public static System.ArraySegment<byte> CreateMessageBytes(PacketHeader header, byte[] body, out uint messageSize) {
			var msg = new byte[body.Length + PacketHeader.MinPacketLength];
			header.ToBytes(msg);
			body.CopyTo(msg, PacketHeader.MinPacketLength);
			messageSize = (uint)msg.Length;
			return new System.ArraySegment<byte>(msg);
		}
	}
}

