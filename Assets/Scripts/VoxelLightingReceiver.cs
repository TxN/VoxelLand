using UnityEngine;

namespace Voxels {
	public sealed class VoxelLightingReceiver : MonoBehaviour {
		public byte GetLightLevel() {
			var cm = ChunkManager.Instance;
			var block = cm.GetBlockIn(transform.position);
			return (byte) Mathf.Max(block.LightLevel, block.SunLevel);
		}
	}
}

