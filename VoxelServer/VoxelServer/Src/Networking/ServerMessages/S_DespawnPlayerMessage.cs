using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class S_DespawnPlayerMessage : BaseMessage {
		[Index(1)]
		public virtual PlayerEntity PlayerToDespawn { get; set; }
	}
}
