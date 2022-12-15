using UnityEngine;

using Voxels.Utils.Collisions;

namespace Voxels.Utils {
	[System.Flags]
	public enum CastType : byte {
		None = 0,
		Solid = 1,
		Liquid = 2,
		Passable = 4,
		AnyBlock = 7,
		EntitySolid = 8,
		EntityPassable = 16,
		AnySolid = Solid | EntitySolid,
		Any = 31,
	}

	public enum HitResult : byte {
		Nothing = 0,
		HitBlock = 1,
		HitEntity = 2,
		HitBoth = 3,
	}

	public struct CastResult {
		public Vector3 HitPosition;
		public Vector3 Normal;
		public HitResult HitResult;
	}

	public sealed class CollisionHelper {
		IChunkManager _owner;

		public void Init(IChunkManager owner) {
			_owner = owner;
		}

		public bool Cast(CastType type, Vector3 startPoint, Vector3 direction, float maxDistance, out CastResult result) {
			var hasCollision = RayMarchBlock(startPoint, direction, maxDistance, type, out result);
			//TODO: check against entity
			return hasCollision;
		}

		bool RayMarchBlock(Vector3 startPoint, Vector3 direction, float maxDistance, CastType type, out CastResult result) {
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
				var checkPos = new Int3(ix, iy, iz);
				var hasBlock = CheckBlock(checkPos, type);
				if ( hasBlock ) {
					var remainingDistace = maxDistance - t;
					var point = startPoint + new Vector3(t * direction.x, t * direction.y, t * direction.z);
					var normal = Vector3.zero;
					if ( steppedIndex == 0 ) { normal = new Vector3(-stepX, 0, 0); }
					if ( steppedIndex == 1 ) { normal = new Vector3(0, -stepY, 0); }
					if ( steppedIndex == 2 ) { normal = new Vector3(0, 0, -stepZ); }

					if ( HasCollision(checkPos, point, direction, remainingDistace, out var collisionPoint, ref normal) ) {
						res.HitPosition = collisionPoint;
						res.HitResult = HitResult.HitBlock;
						res.Normal = normal;
						result = res;
						return true;
					}
				}

				if ( txMax < tyMax ) {
					if ( txMax < tzMax ) {
						ix += stepX;
						t = txMax;
						txMax += txDelta;
						steppedIndex = 0;
					}	else {
						iz += stepZ;
						t = tzMax;
						tzMax += tzDelta;
						steppedIndex = 2;
					}
				}	else {
					if ( tyMax < tzMax ) {
						iy += stepY;
						t = tyMax;
						tyMax += tyDelta;
						steppedIndex = 1;
					}	else {
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

		bool CheckBlock(Int3 pos, CastType type) {
			var block = _owner.GetBlockIn(pos.X, pos.Y, pos.Z);
			if ( block.IsEmpty() || type == CastType.None ) {
				return false;
			}

			if ( type == CastType.Any ) {
				return true;
			}

			var desc = StaticResources.BlocksInfo.GetBlockDescription(block.Type);
			if ( VoxelsUtils.IsSet(type, CastType.Solid) && !desc.IsPassable ) {
				return true;
			}

			if ( VoxelsUtils.IsSet(type, CastType.Passable) && desc.IsPassable ) {
				return true;
			}
			if ( VoxelsUtils.IsSet(type, CastType.Liquid) && (desc.IsPassable && desc.IsSwimmable) ) {
				return true;
			}

			return false;
		}

		bool HasCollision(Int3 pos, Vector3 checkPoint, Vector3 direction, float maxDistance, out Vector3 point, ref Vector3 normal) {
			point = checkPoint;
			var block = _owner.GetBlockIn(pos.X, pos.Y, pos.Z);
			var desc = StaticResources.BlocksInfo.GetBlockDescription(block.Type);
			if ( block.IsEmpty() || desc.IsFull ) {
				return true;
			}
			var collider = StaticResources.BlocksInfo.GetCollisionInfo(desc.Subtypes[block.Subtype].CollisionModel);

			if ( collider == null ) {
				Debug.LogWarning($"Collider data for block {block.Type} subtype {block.Subtype} is null");
				return false;
			}
			var ray = new Collisions.Ray(checkPoint, direction);
			var minDist = 10000f;
			var minIndex = -1;
			for ( int i = 0; i < collider.BoundingBoxes.Count; i++ ) {
				var bb = collider.BoundingBoxes[i];
				var movedAaBb = bb.AddToOrigin(pos.ToVector3);
				if ( Intersection.Intersects(ray, movedAaBb, out var dist) ) {
					if ( dist < minDist ) {
						minIndex = i;
						minDist = dist;
					}
				}
				//Gizmos.DrawWireCube(movedAaBb.Center, movedAaBb.Size * 2);
			}
			
			if ( minIndex >= 0 ) {
				var movedAaBb = collider.BoundingBoxes[minIndex].AddToOrigin(pos.ToVector3);
				point = checkPoint + direction * minDist;
				normal = movedAaBb.BoxNormal(point);
			}

			return minIndex >= 0 && minDist < maxDistance;
		}
	}
}

