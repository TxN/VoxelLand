using UnityEngine;

using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class S_InitChunkMessage : BaseMessage {
		[Index(1)]
		public virtual byte[] Blocks  { get; set; }
		[Index(2)]
		public virtual int BlockCount { get; set; }
		[Index(3)]
		public virtual int IndexX { get; set; }
		[Index(4)]
		public virtual int IndexY { get; set; }
		[Index(5)]
		public virtual int IndexZ { get; set; }
		[Index(6)]
		public virtual int Height { get; set; }
		[Index(7)]
		public virtual Vector3 Origin { get; set; }
	}
}
