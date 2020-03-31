using System;
using UnityEngine;

using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class S_UpdateEntityPosRotMessage : BaseMessage {
		[Index(1)]
		public virtual Vector3 Position { get; set; }
		[Index(2)]
		public virtual Byte3   Rotation { get; set; }
		[Index(3)]
		public virtual UInt32 UID { get; set; }
	}
}
