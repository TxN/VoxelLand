using ZeroFormatter;

#if INCLUDE_ONLY_CODE_GENERATION

namespace UnityEngine {
	[ZeroFormattable]
	public struct Vector2 {
		[Index(0)]
		public float x;
		[Index(1)]
		public float y;

		public Vector2(float x, float y) {
			this.x = x;
			this.y = y;
		}
	}

	[ZeroFormattable]
	public struct Vector3 {
		[Index(0)]
		public float x;
		[Index(1)]
		public float y;
		[Index(2)]
		public float z;

		public Vector3(float x, float y, float z) {
			this.x = x;
			this.y = y;
			this.z = z;
		}
	}


}

#endif

namespace Voxels {
	[ZeroFormattable]
	public class BlockDataArrayHint {
		[Index(0)]
		public virtual Voxels.BlockData[,,] Hint1 { get; set; }
	}

	[ZeroFormattable]
	public class VisibilityFlagsArrayHint {
		[Index(0)]
		public virtual Voxels.VisibilityFlags[,,] Hint1 { get; set; }
	}
}