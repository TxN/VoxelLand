using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class C_HandshakeMessage : BaseMessage {
		[Index(1)]
		public virtual string ClientName   { get; set; }
		[Index(2)]
		public virtual string Password     { get; set; }
		[Index(3)]
		public virtual int ProtocolVersion { get; set; }
	}
}
