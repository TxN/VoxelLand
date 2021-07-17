using ZeroFormatter;

namespace Voxels.Networking.Clientside.Entities {
[ZeroFormattable]
	public class FlyingBlockClientState {
		[Index(0)]
		public virtual BlockData BlockData { get; set; }
	}
}
