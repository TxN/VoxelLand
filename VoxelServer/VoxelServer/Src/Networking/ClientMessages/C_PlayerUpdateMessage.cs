using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class C_PlayerUpdateMessage : BaseMessage {
		[Index(1)]
		public virtual PlayerEntity PlayerInfo { get; set; }
	}
}
