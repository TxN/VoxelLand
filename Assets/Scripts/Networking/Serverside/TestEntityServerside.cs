using UnityEngine;

namespace Voxels.Networking.Serverside.Entities {
	public sealed class TestEntityServerside : DynamicEntityServerside {
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
			if ( ServerGameManager.Random.Next(0, 100) < 5 ) {
				Mover.Jump();
			}

			if ( ServerGameManager.Random.Next(0, 100) < 3 ) {
				var r = Mover.Rotation;
				Mover.Rotation = r * Quaternion.Euler(0, ServerGameManager.Random.Next(-100, 100), 0);
			}

			Mover.Move(Vector3.forward, 1);
		}
	}
}
