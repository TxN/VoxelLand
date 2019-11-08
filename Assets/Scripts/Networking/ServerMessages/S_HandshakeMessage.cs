using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class S_HandshakeMessage : BaseMessage {
		[Index(1)]
		public virtual string ServerName   { get; set; }
		[Index(2)]
		public virtual string MOTD         { get; set; }
		[Index(3)]
		public virtual int ProtocolVersion { get; set; }
	}
}

