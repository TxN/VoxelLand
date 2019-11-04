using UnityEngine;

namespace Voxels {
	public sealed class ChunkData {
		public int                 IndexX     = 0;
		public int                 IndexY     = 0;
		public int                 IndexZ     = 0;
		public byte                Height     = 0;
		public Vector3             Origin     = Vector3.zero;
		public BlockData[,,]       Blocks     = null;
		public VisibilityFlags[,,] Visibiltiy = null;
	}
}

