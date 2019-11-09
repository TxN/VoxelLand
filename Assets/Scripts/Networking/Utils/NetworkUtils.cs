using UnityEngine;

namespace Voxels.Networking {
	public static class NetworkUtils {
		public static byte[] CreateMessageBytes(PacketHeader header, byte[] body) {
			var msg = new byte[header.ContentLength + PacketHeader.MinPacketLength];
			header.ToBytes(msg);
			body.CopyTo(msg, PacketHeader.MinPacketLength);
			return msg;
		}
	}
}

