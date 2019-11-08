using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class C_ChatMessage : BaseMessage {
		[Index(1)]
		public virtual string MessageText { get; set; }
	}
}
