using UnityEngine;

using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class C_PosAndOrientationUpdateMessage : BaseMessage {
		[Index(1)]
		public virtual Vector3 Position  { get; set; }
		[Index(2)]
		public virtual byte    LookPitch { get; set; }
		[Index(3)]
		public virtual byte    Yaw       { get; set; }
	}
}
