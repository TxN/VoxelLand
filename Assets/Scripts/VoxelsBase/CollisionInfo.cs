using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Voxels.Utils.Collisions;

namespace Voxels {
	public sealed class CollisionInfo {
		public List<AABB> BoundingBoxes = new List<AABB>();

		public static CollisionInfo GetForBlock(BlockCollisionModel collisionType) {
			var info = new CollisionInfo();

			switch( collisionType) {
				case BlockCollisionModel.None:
					return info;
				case BlockCollisionModel.FullBlock:
					info.BoundingBoxes.Add(new AABB(Vector3.zero, Vector3.one));
					break;
				case BlockCollisionModel.HalfBlockDown:
					info.BoundingBoxes.Add(new AABB(Vector3.zero, new Vector3(1f, 0.5f,1f)));
					break;
				case BlockCollisionModel.HalfBlockUp:
					info.BoundingBoxes.Add(new AABB(new Vector3(0f, 0.5f, 0f), Vector3.one));
					break;
				case BlockCollisionModel.PlateDown:
					info.BoundingBoxes.Add(new AABB(Vector3.zero, new Vector3(1f, 0.1f, 1f)));
					break;
				case BlockCollisionModel.PlateUp:
					info.BoundingBoxes.Add(new AABB(new Vector3(0f, 0.9f, 0f), Vector3.one));
					break;
				case BlockCollisionModel.DoorLeft:
					info.BoundingBoxes.Add(new AABB(new Vector3(0f, 0f, 0f), new Vector3(0.2f, 1f, 1f)));
					break;
				case BlockCollisionModel.DoorRight:
					info.BoundingBoxes.Add(new AABB(new Vector3(0f, 0f, 0f), new Vector3(0.2f, 1f, 1f)));
					break;
				case BlockCollisionModel.DoorUp:
					info.BoundingBoxes.Add(new AABB(new Vector3(0f, 0f, 0f), new Vector3(0.2f, 1f, 1f)));
					break;
				case BlockCollisionModel.DoorDown:
					info.BoundingBoxes.Add(new AABB(new Vector3(0f, 0f, 0f), new Vector3(0.2f, 1f, 1f)));
					break;
				case BlockCollisionModel.Torch:
					info.BoundingBoxes.Add(new AABB(new Vector3(0.4f, 0f, 0.4f), new Vector3(0.6f, 0.7f, 0.6f)));
					break;
				case BlockCollisionModel.Pillar:
					info.BoundingBoxes.Add(new AABB(new Vector3(0.4f, 0f, 0.4f), new Vector3(0.6f, 1f, 0.6f)));
					break;

			}	

			return info;
		}
	}
}

