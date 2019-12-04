using UnityEngine;

namespace Voxels {
	public interface IVoxelCollider {
		bool HasContact();
		bool GetContactPoints();
	}

	public class SphereVoxelCollider : IVoxelCollider {
		public float Radius = 0.4f;

		public IChunkManager ChunkManager = null;

		public bool GetContactPoints() {
			throw new System.NotImplementedException();
		}

		public bool HasContact() {
			throw new System.NotImplementedException();
		}
	}

	public class AABBVoxelCollider : IVoxelCollider {
		public float X_Extent = 0f;
		public float Y_Extent = 0f;
		public float Z_Extent = 0f;

		public Vector3 Center = Vector3.zero;

		public bool GetContactPoints() {
			throw new System.NotImplementedException();
		}

		public bool HasContact() {
			throw new System.NotImplementedException();
		}

		bool IsIntersectsWithVoxel(int x, int y, int z) {
			var xMin = Mathf.FloorToInt(Center.x - X_Extent);
			var xMax = Mathf.FloorToInt(Center.x + X_Extent);
			var yMin = Mathf.FloorToInt(Center.y - Y_Extent);
			var yMax = Mathf.FloorToInt(Center.y + Y_Extent);
			var zMin = Mathf.FloorToInt(Center.z - Z_Extent);
			var zMax = Mathf.FloorToInt(Center.z + Z_Extent);

			return x >= xMin && x <= xMax && y >= yMin && y <= yMax && z >= zMin && z <= zMax;
		}
	}
}

