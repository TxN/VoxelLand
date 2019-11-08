using UnityEngine;

namespace Voxels.Networking {
	public class ClientState {
		public CState CurrentState = CState.Disconneted;
		public int    ConnectionID = 0;
		public string UserName     = string.Empty;
		public string IpAdress     = string.Empty;
		public float  LastPingTime = 0f;
		public float  LastPongTime = 0;

	}

	public enum CState : byte {
		Disconneted,
		Handshake,
		Connected
	}
}
