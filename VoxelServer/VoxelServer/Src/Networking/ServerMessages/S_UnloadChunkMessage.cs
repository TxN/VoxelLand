using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class S_UnloadChunkMessage : BaseMessage {
		[Index(1)]
		public virtual int X { get; set; }
		[Index(2)]
		public virtual int Y { get; set; }
		[Index(3)]
		public virtual int Z { get; set; }
	}
}
