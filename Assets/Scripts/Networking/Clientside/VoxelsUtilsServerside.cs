using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Voxels.VoxelsUtils;

namespace Voxels.Networking.Serverside {
	public static class VoxelsUtilsServerside {

		public static bool IsBlockSolid(Int3 index) {
			var lib = StaticResources.BlocksInfo;
			var block = ServerChunkManager.Instance.GetBlockIn(index.X, index.Y, index.Z);
			return !lib.GetBlockDescription(block.Type).IsPassable;
		}

		public static bool HasAnyBlock(Int3 index) {
			var lib = StaticResources.BlocksInfo;
			var block = ServerChunkManager.Instance.GetBlockIn(index.X, index.Y, index.Z);
			return lib.GetBlockDescription(block.Type).Type != BlockType.Air;
		}
	}
}
