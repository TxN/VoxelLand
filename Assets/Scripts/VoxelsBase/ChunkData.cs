using UnityEngine;

using ZeroFormatter;

namespace Voxels {
	[ZeroFormattable]
	public class ChunkData {
		[Index(0)]
		public virtual int                   IndexX     { get; set; }
		[Index(1)]
		public virtual int                   IndexY     { get; set; }
		[Index(2)]
		public virtual int                   IndexZ     { get; set; }
		[Index(3)]
		public virtual int                   Height     { get; set; }
		[Index(4)]
		public virtual Vector3               Origin     { get; set; }
		[Index(5)]
		public virtual BlockDataHolder       Blocks     { get; set; }
		[Index(6)]
		public virtual VisibilityFlagsHolder Visibiltiy { get; set; }
	}
}
