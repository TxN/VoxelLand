using System;

using UnityEngine;

namespace Voxels.Utils.Collisions {

	public struct AABB : ICollisionShape {
		public ShapeType ShapeType => ShapeType.AABB;
		public Vector3 Min { get { return _min; } }
		public Vector3 Max { get { return _max; } }
		public Vector3 Center { get { return (_min + _max) * 0.5f; } }

		Vector3 _min;
		Vector3 _max;

		public AABB(Vector3 min, Vector3 max) {
			_min = Vector3.Min(min, max);
			_max = Vector3.Max(min, max);
		}

		public bool Intersects(ICollisionShape other, out Vector3 point) {
			throw new NotImplementedException();
		}
	}

}
