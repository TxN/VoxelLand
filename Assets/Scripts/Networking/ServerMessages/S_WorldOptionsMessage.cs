using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class S_WorldOptionsMessage : BaseMessage {
		[Index(1)]
		public virtual int Seed           { get; set; }
		[Index(2)]
		public virtual int Time           { get; set; }
		[Index(3)]
		public virtual int TimeMultiplier { get; set; }
	}
}
