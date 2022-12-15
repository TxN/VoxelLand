using UnityEngine;
using Voxels.Utils;

namespace Voxels {
	public interface IChunkManager {
		int   GetWorldHeight { get; }
		int   GatherNeighbors(Int3 index);
		Chunk GetChunk(int x, int y, int z);
		BlockData GetBlockIn(int x, int y, int z);
		BlockData GetBlockIn(Vector3 pos);

		CollisionHelper CollisionHelper { get; }
	}
}

