using System;
using UnityEngine;

using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class S_UpdateEntityRotMessage : BaseMessage {
		[Index(1)]
		public virtual Byte3 Rotation { get; set; }
		[Index(2)]
		public virtual uint UID     { get; set; }
	}
}
