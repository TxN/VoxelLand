using System;

using UnityEngine;

namespace Voxels.Utils.Collisions {
	public struct Ray : ICollisionShape {
		public ShapeType ShapeType => ShapeType.Ray;

		public Vector3 Point { get { return _point; } }
		public Vector3 Dir { get { return _dir; } }
		public Vector3 InvDir { get { return _invDir; } }
		public Vector3 Sign { get { return _sign; } }

		Vector3 _point;
		Vector3 _dir;
		Vector3 _invDir;
		Vector3 _sign;

		public Ray(Vector3 point, Vector3 dir) {
			_point = point;

			_dir = dir;
			_invDir = new Vector3(
				1f / dir.x,
				1f / dir.y,
				1f / dir.z
			);
			_sign = new Vector3(
				_invDir.x < 0f ? 1 : 0,
				_invDir.y < 0f ? 1 : 0,
				_invDir.z < 0f ? 1 : 0
			);
		}


		public bool Intersects(ICollisionShape other, out Vector3 point) {
			throw new NotImplementedException();
		}
	}
}
