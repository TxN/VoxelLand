using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Voxels.Networking.Serverside {
	public class TestEntityServerside : DynamicEntityServerside {
		public override string EntityType {
			get {
				return "TestEntity";
			}
		}
		public override void Init() {
			Mover.Radius = 0.5f;
			Mover.UpHeight = 0.5f;
			Mover.DownHeight = 0.5f;
		}

		public override void Tick() {
			base.Tick();
			var rot = Mover.Rotation;
			Mover.Rotation = rot * Quaternion.Euler(0, 30 * ServerDynamicEntityController.TICK_TIME, 0);
		}
	}
}

