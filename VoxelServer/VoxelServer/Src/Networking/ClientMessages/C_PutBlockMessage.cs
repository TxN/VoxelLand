using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class C_PutBlockMessage : BaseMessage {
		[Index(1)]
		public virtual BlockData Block { get; set; }
		[Index(2)]
		public virtual int       X     { get; set; }
		[Index(3)]
		public virtual int       Y     { get; set; }
		[Index(4)]
		public virtual int       Z     { get; set; }
		[Index(5)]
		public virtual bool      Put   { get; set; }
	}
}
