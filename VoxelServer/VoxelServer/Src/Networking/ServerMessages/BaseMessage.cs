using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class BaseMessage {
		[Index(0)]
		public virtual byte CommandID { get; set; }
	}
}

