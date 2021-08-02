using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Voxels.Utils.Collisions {
	public struct Plane : ICollisionShape {
		public ShapeType ShapeType => ShapeType.Plane;

		public Vector3 Normal { get { return _normal; } }
		public float Distance { get { return _distance; } }

		Vector3 _normal;
		float _distance;

		public Plane(Vector3 normal, float distance) {
			_normal = normal;
			_distance = distance;
		}

		public bool Intersects(ICollisionShape other, out Vector3 point) {
			throw new System.NotImplementedException();
		}
	}
}
