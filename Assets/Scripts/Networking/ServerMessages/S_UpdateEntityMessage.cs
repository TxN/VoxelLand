using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class S_UpdateEntityMessage : BaseMessage {
		[Index(1)]
		public virtual uint UID { get; set; }
	}
}
