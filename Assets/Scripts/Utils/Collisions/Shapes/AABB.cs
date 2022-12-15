using System;

using UnityEngine;

namespace Voxels.Utils.Collisions {
	[Serializable]
	public struct AABB : ICollisionShape {
		public ShapeType ShapeType => ShapeType.AABB;
		public Vector3 Min { get { return _min; } }
		public Vector3 Max { get { return _max; } }
		public Vector3 Center { get { return (_min + _max) * 0.5f; } }

		public Vector3 Size => (_max - _min) * 0.5f;

		Vector3 _min;
		Vector3 _max;

		public AABB(Vector3 min, Vector3 max) {
			_min = Vector3.Min(min, max);
			_max = Vector3.Max(min, max);
		}

		public Vector3 NormalAt(Vector3 point) {
			var normal = Vector3.zero;
			var localPoint = point - Center;
			float min = float.MaxValue;
			var size = Size;

			float distance = Mathf.Abs(size.x - Mathf.Abs(localPoint.x));
			if ( distance < min ) {
				min = distance;
				normal = new Vector3(1, 0, 0);
				normal *= Mathf.Sign(localPoint.x);
			}
			distance = Mathf.Abs(size.y - Mathf.Abs(localPoint.y));
			if ( distance < min ) {
				min = distance;
				normal = new Vector3(0, 1, 0);
				normal *= Mathf.Sign(localPoint.y);
			}
			distance = Mathf.Abs(size.z - Mathf.Abs(localPoint.z));
			if ( distance < min ) {
				min = distance;
				normal = new Vector3(0, 0, 1);
				normal *= Mathf.Sign(localPoint.z);
			}
			return normal;
		}

		public Vector3 BoxNormal(Vector3 point) {
		var pc = point - Center;
		var normal = Vector3.zero;
		normal += new Vector3(Mathf.Sign(pc.x), 0f, 0f) * Step(Mathf.Abs(Mathf.Abs(pc.x) - Size.x), Mathf.Epsilon);
		normal += new Vector3(0f, Mathf.Sign(pc.y), 0f) * Step(Mathf.Abs(Mathf.Abs(pc.y) - Size.y), Mathf.Epsilon);
		normal += new Vector3(0f, 0f, Mathf.Sign(pc.z)) * Step(Mathf.Abs(Mathf.Abs(pc.z) - Size.z), Mathf.Epsilon);
		return normal.normalized;
		}

		float Step(float edge, float x) {
			return x < edge ? 0 : 1;
		}

	public bool Intersects(ICollisionShape other, out Vector3 point) {
			throw new NotImplementedException();
		}

		public AABB AddToOrigin(Vector3 offset) {
			return new AABB(_min + offset, _max + offset);
		}
	}

}
