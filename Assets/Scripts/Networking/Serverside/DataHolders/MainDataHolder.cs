using System.Collections.Generic;

using ZeroFormatter;

namespace Voxels.Networking.Serverside {
	[ZeroFormattable]
	public class MainDataHolder {
		[IgnoreFormat]
		public virtual HashSet<Int3> ChunkLibrary { get; set; }

		[Index(0)]
		public virtual Int3[] ChunkArray { get; set; }
	}
}

