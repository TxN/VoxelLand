using UnityEngine;

namespace Voxels.Networking {
	public class ClientState {
		public CState CurrentState = CState.Disconneted;
		public int    ConnectionID = 0;
		public string UserName     = string.Empty;
		public string IpAdress     = string.Empty;

	}

	public enum CState : byte {
		Disconneted,
		Handshake,
		Connected
	}
}
