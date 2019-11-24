using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class S_InitChunkMessage : BaseMessage {
		[Index(1)]
		public virtual ChunkData Chunk { get; set; }
	}
}
