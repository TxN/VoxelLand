using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class S_DespawnEntityMessage : BaseMessage {
		[Index(1)]
		public virtual uint UID { get; set; }
	}
}
