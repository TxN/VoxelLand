using System;

using LiteDB;

namespace Voxels.Networking.Serverside {
	public class ClientProfile {
		[BsonId]
		public string   Name          { get; set; }
		public string   Password      { get; set; }
		public bool     Op            { get; set; }
		public DateTime LastLoginTime { get; set; }
	}


	[Serializable]
	public class ClientState {
		public CState   CurrentState   = CState.Disconneted;
		public int      ConnectionID   = 0;
		public bool     IsOp           = false;
		public string   UserName       = string.Empty;
		public string   IpAdress       = string.Empty;
		public DateTime LastPingTime   = DateTime.MinValue;
		public DateTime LastPongTime   = DateTime.MinValue;
		public DateTime ConnectionTime = DateTime.MinValue;
	}

	public enum CState : byte {
		Disconneted,
		Handshake,
		Initialize,
		Connected
	}
}
