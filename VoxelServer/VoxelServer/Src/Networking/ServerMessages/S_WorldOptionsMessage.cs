using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class S_WorldOptionsMessage : BaseMessage {
		[Index(1)]
		public virtual int   Seed           { get; set; }
		[Index(2)]
		public virtual float Time           { get; set; }
		[Index(3)]
		public virtual float TimeMultiplier { get; set; }
		[Index(4)]
		public virtual float DayLength      { get; set; }
	}
}
