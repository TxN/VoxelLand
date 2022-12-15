using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class S_PlayerUpdateMessage : BaseMessage {
		[Index(1)]
		public virtual PlayerEntity Player { get; set; }
		[Index(2)]
		public virtual bool         Teleport      { get; set; }
	}
}
