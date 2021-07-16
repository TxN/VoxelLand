using System.Collections.Generic;

using UnityEngine;

namespace Voxels {
	public sealed class ResourceLibrary : ScriptableObject {
		public List<BlockDescription> BlockDescriptions = new List<BlockDescription>();
	}
}
