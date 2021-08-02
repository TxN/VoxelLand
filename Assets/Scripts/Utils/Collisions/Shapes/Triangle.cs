using UnityEngine;

namespace Voxels.Utils.Collisions {

	public struct Triangle : ICollisionShape {
		public ShapeType ShapeType => ShapeType.Triangle;

		public Vector3 A { get { return _a; } }
		public Vector3 B { get { return _b; } }
		public Vector3 C { get { return _c; } }

		public Vector3 AB { get { return _ab; } }
		public Vector3 BC { get { return _bc; } }
		public Vector3 CA { get { return _ca; } }

		public Vector3 Normal { get { return _normal; } }

		Vector3 _a, _b, _c, _normal;
		Vector3 _ab, _bc, _ca;

		public Triangle(Vector3 a, Vector3 b, Vector3 c) {
			_a = a;
			_b = b;
			_c = c;
			_ab = b - a;
			_bc = c - b;
			_ca = a - c;

			var cross = Vector3.Cross(_ab, _bc);
			_normal = cross / cross.magnitude;
		}

		public bool Intersects(ICollisionShape other, out Vector3 point) {
			throw new System.NotImplementedException();
		}
	}
}
