using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class S_EntityRPCMessage : BaseMessage {
		[Index(1)]
		public virtual uint UID        { get; set; }

		[Index(2)]
		public virtual uint MethodName { get; set; }
	}
}
