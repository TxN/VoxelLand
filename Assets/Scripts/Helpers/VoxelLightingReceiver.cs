using UnityEngine;

using Voxels.Networking.Clientside;

namespace Voxels {
	public sealed class VoxelLightingReceiver : MonoBehaviour {
		public byte GetLightLevel() {
			var cm = ClientChunkManager.Instance;
			var block = cm.GetBlockIn(transform.position);
			var cwc = ClientWorldStateController.Instance;
			return (byte) Mathf.Max(block.LightLevel, block.SunLevel * cwc.AmbientLightIntensity );
		}
	}
}

