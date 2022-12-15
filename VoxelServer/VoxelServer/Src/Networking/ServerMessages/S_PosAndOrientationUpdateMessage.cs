using UnityEngine;

using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class S_PosAndOrientationUpdateMessage : BaseMessage {
		[Index(1)]
		public virtual ushort  ConId     { get; set; }
		[Index(2)]
		public virtual Vector3 Position  { get; set; }
		[Index(3)]
		public virtual byte    LookPitch { get; set; }
		[Index(4)]
		public virtual byte    Yaw       { get; set; }
	}
}
