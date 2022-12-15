using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class S_ForceDisconnectMessage : BaseMessage {
		[Index(1)]
		public virtual string Reason { get; set; }
	}
}

