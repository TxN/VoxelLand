using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class C_PlayerActionMessage : BaseMessage {
		[Index(1)]
		public virtual PlayerActionType Action        { get; set; }
		[Index(2)]
		public virtual string           PayloadString { get; set; }
		[Index(3)]
		public virtual int              PayloadInt    { get; set; }
	}
}
