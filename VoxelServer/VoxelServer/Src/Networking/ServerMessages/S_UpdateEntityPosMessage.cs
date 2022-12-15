using System;
using UnityEngine;

using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class S_UpdateEntityPosMessage : BaseMessage {
		[Index(1)]
		public virtual Vector3 Position { get; set; }
		[Index(2)]
		public virtual uint    UID      { get; set; }

	}
}
