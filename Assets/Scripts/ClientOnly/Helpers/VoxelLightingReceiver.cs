using UnityEngine;

using Voxels.Networking.Clientside;

namespace Voxels {
	public class VoxelLightingReceiver : MonoBehaviour {
		public byte GetLightLevel() {
			var cm = ClientChunkManager.Instance;
			var block = cm.GetBlockIn(transform.position);
			var cwc = ClientWorldStateController.Instance;
			return (byte) Mathf.Max(block.LightLevel, block.SunLevel * cwc.AmbientLightIntensity );
		}

		public byte GetAmbientLightLevel() {
			var cm = ClientChunkManager.Instance;
			var block = cm.GetBlockIn(transform.position);
			var cwc = ClientWorldStateController.Instance;
			return (byte)(block.SunLevel * cwc.AmbientLightIntensity);
		}

		public byte GetBlockLightLevel() {
			var cm = ClientChunkManager.Instance;
			var block = cm.GetBlockIn(transform.position);
			return (byte)block.LightLevel;
		}
	}
}

