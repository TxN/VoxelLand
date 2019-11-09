using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class S_ChatMessage : BaseMessage {
		[Index(1)]
		public virtual string SenderName { get; set; }
		[Index(2)]
		public virtual string MessageText { get; set; }
	}
}
