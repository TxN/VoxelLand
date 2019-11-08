namespace Voxels.Networking {
	public struct PacketHeader {
		public byte PacketID;
		public bool Compressed;
		public ushort ContentLength;

		public PacketHeader(byte[] rawMessage) {
			if ( rawMessage.Length >= MIN_PACKET_LENGTH ) {
				PacketID      = rawMessage[0];
				Compressed    = rawMessage[1] > 0;
				ContentLength = (ushort) (rawMessage[2] + 255 * rawMessage[3]);
			} else {
				PacketID = 255;
				Compressed = false;
				ContentLength = 0;
			}
		}

		public PacketHeader(byte packetId, bool compressed, ushort contentLength) {
			PacketID      = packetId;
			Compressed    = compressed;
			ContentLength = contentLength;
		}

		public void ToBytes(byte[] buffer) {
			buffer[0] = PacketID;
			buffer[1] =  Compressed ? (byte) 1 : (byte) 0;
			buffer[2] = (byte) (ContentLength % 256);
			buffer[3] = (byte) (ContentLength / 256);
		}

		public static int MinPacketLength {
			get { return MIN_PACKET_LENGTH; }
		}
		const int MIN_PACKET_LENGTH = 4;
	}
}