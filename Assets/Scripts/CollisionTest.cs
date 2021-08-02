using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voxels.Utils.Collisions;

public class CollisionTest : MonoBehaviour {
	public Transform RaySource = null;
	public Transform AABBSource = null;

	private void Start() {
		
	}

	private void OnDrawGizmos() {
		var ray = new Voxels.Utils.Collisions.Ray(RaySource.position, RaySource.forward);
		Gizmos.color = Color.white;
		Gizmos.DrawRay(RaySource.position, RaySource.forward);

		var size = new Vector3(1, 0.3f, 1);

		var cube = new AABB(AABBSource.position - size * 0.5f, AABBSource.position + size * 0.5f);
		Gizmos.DrawWireCube(AABBSource.position, size);
		if ( Intersection.Intersects(ray, cube, out var dist) ) {
			Gizmos.color = Color.red;
			Gizmos.DrawWireCube(AABBSource.position, size);
			var colPoint = RaySource.position + RaySource.forward * dist;
			Gizmos.DrawWireSphere(colPoint, 0.1f);
			Gizmos.DrawLine(RaySource.position, colPoint);
		}
	}
}
