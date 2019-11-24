using System.Collections;
using System.Collections.Generic;

using Unity.Jobs;
using UnityEngine;

using SMGCore.EventSys;
using Voxels.Networking.Events;

namespace Voxels.Networking.Serverside {
	public class ServerWorldStateController : ServerSideController<ServerWorldStateController> {
		public ServerWorldStateController(ServerGameManager owner) : base(owner) { }

		public float WorldTime {
			get; private set;
		}

		public float TimeScale { get; private set; } = 1f;

		public override void Load() {
			base.Load();
			//TODO:Load from save
		}

		public override void Update() {
			base.Update();
			WorldTime += Time.deltaTime * TimeScale;
		}
	}
}