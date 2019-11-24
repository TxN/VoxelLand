using System.Collections.Generic;

using UnityEngine;

using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Networking.Utils;

namespace Voxels.Networking.Clientside {
	public class ClientWorldStateController : ClientsideController<ClientWorldStateController> {
		public ClientWorldStateController(ClientGameManager owner) : base(owner) { }

		const string SKYBOX_CONTROLLER_PATH = "Client/DayNightCycle";

		GameObject _skyboxController = null;

		public float WorldTime {
			get; private set;
		}

		public float TimeScale {
			get; private set;
		}

		public float DayPercent {
			get {
				var days = WorldTime / WorldOptions.DayLength;
				var whole = Mathf.FloorToInt(days);
				return days - whole;
			}
		}

		public int DayNumber {
			get {
				var days = WorldTime / WorldOptions.DayLength;
				var whole = Mathf.FloorToInt(days);
				return whole;
			}
		}

		public override void Init() {
			base.Init();

			var sbFab = Resources.Load(SKYBOX_CONTROLLER_PATH);
			_skyboxController = Object.Instantiate((GameObject)sbFab, null);
		}

		public override void Update() {
			base.Update();
			WorldTime += Time.deltaTime * TimeScale;
		}

		public void SetTimeParameters(float time, float timeScale) {
			WorldTime = time;
			TimeScale = timeScale;
		}
	}
}