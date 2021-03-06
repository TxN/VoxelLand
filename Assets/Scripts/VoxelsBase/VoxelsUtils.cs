using System;

using UnityEngine;

namespace Voxels {
	public static class VoxelsUtils {

		public struct CastResult {
			public Vector3 HitPosition;
			public Vector3 Normal;
		}

		public static  bool Cast(Vector3 startPoint, Vector3 direction, float maxDistance, Func<Int3, bool> checkMethod, out CastResult result) {
			direction = direction.normalized;
			var t = 0f;
			var ix = Mathf.FloorToInt(startPoint.x);
			var iy = Mathf.FloorToInt(startPoint.y);
			var iz = Mathf.FloorToInt(startPoint.z);

			var stepX = (int)Mathf.Sign(direction.x);
			var stepY = (int)Mathf.Sign(direction.y);
			var stepZ = (int)Mathf.Sign(direction.z);

			var txDelta = Mathf.Abs(1 / direction.x);
			var tyDelta = Mathf.Abs(1 / direction.y);
			var tzDelta = Mathf.Abs(1 / direction.z);

			var xDist = (stepX > 0) ? (ix + 1 - startPoint.x) : (startPoint.x - ix);
			var yDist = (stepY > 0) ? (iy + 1 - startPoint.y) : (startPoint.y - iy);
			var zDist = (stepZ > 0) ? (iz + 1 - startPoint.z) : (startPoint.z - iz);

			var txMax = (txDelta < Mathf.Infinity) ? txDelta * xDist : Mathf.Infinity;
			var tyMax = (tyDelta < Mathf.Infinity) ? tyDelta * yDist : Mathf.Infinity;
			var tzMax = (tzDelta < Mathf.Infinity) ? tzDelta * zDist : Mathf.Infinity;

			var steppedIndex = -1;
			var res = new CastResult();

			while ( t < maxDistance ) {
				var isSolid = checkMethod(new Int3(ix, iy, iz));
				if ( isSolid ) {

					var point = startPoint + new Vector3(t * direction.x, t * direction.y, t * direction.z);
					res.HitPosition = point;
					if ( steppedIndex == 0 ) { res.Normal = new Vector3(-stepX, 0, 0); } 
					if ( steppedIndex == 1 ) { res.Normal = new Vector3(0, -stepY, 0); } 
					if ( steppedIndex == 2 ) { res.Normal = new Vector3(0, 0, -stepZ); }
					result = res;
					return true;
				}

				if ( txMax < tyMax ) {
					if ( txMax < tzMax ) {
						ix += stepX;
						t = txMax;
						txMax += txDelta;
						steppedIndex = 0;
					} else {
						iz += stepZ;
						t = tzMax;
						tzMax += tzDelta;
						steppedIndex = 2;
					}
				} else {
					if ( tyMax < tzMax ) {
						iy += stepY;
						t = tyMax;
						tyMax += tyDelta;
						steppedIndex = 1;
					} else {
						iz += stepZ;
						t = tzMax;
						tzMax += tzDelta;
						steppedIndex = 2;
					}
				}
			}
			result = res;
			return false;
		}
	}
}
