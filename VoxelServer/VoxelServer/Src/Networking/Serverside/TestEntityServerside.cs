using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Voxels.Networking.Serverside.Entities {
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
			if ( Random.Range(0, 100) < 5 ) {
				Mover.Jump();
			}

			if ( Random.Range(0, 100) < 3 ) {
				var r = Mover.Rotation;
				Mover.Rotation = r * Quaternion.Euler(0, Random.Range(-100, 100), 0);
			}

			Mover.Move(Vector3.forward, 1);
		}
	}
}

