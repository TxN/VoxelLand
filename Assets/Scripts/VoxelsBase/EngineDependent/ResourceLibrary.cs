using System.Collections.Generic;
using System.IO;

using UnityEngine;

namespace Voxels {
	
	public sealed class ResourceLibrary : ScriptableObject {
		public List<BlockDescription> BlockDescriptions = new List<BlockDescription>();

		[ContextMenu("ExportToJson")]
		public void ExportToJson() {
			var serialized = JsonUtility.ToJson(this);
			File.WriteAllText("VoxelServer/VoxelServer/Resources/blockInfo.json", serialized);
			Debug.Log("Exported");
		}

		private void OnValidate() {
			foreach ( var desc in BlockDescriptions ) {
				desc.Name = desc.Type.ToString();
			}
		}
	}
}
