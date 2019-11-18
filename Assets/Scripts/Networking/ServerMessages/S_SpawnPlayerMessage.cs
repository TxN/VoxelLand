using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class S_SpawnPlayerMessage : BaseMessage {
		[Index(1)]
		public virtual PlayerEntity PlayerToSpawn { get; set; }
	}
}


