using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voxels.Networking.Serverside.Entities;

namespace Voxels.Networking.Serverside {
	public static class EntityHelper {
		public static void SpawnFallingBlock(BlockData block, Vector3 position, Vector3 initialVelocity) {
			var ec = ServerDynamicEntityController.Instance;
			ec.SpawnEntity<FlyingBlockServerside>(position, Quaternion.identity, 0, (e) => {
				e.MaxAge = 80;
				e.PresentedBlock = block;
				e.ContactAction = FlyingBlockContactBehaviour.SpawnBlock;
				e.Mover.OverrideVelocity(initialVelocity);
			});
		}
	}
}
