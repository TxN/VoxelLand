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

		public static int MinPacketLength {
			get { return MIN_PACKET_LENGTH; }
		}
		const int MIN_PACKET_LENGTH = 4;
	}
}