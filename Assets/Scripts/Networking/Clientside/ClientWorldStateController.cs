using UnityEngine;

namespace Voxels.Networking.Clientside {
	public class ClientWorldStateController : ClientsideController<ClientWorldStateController> {
		public ClientWorldStateController(ClientGameManager owner) : base(owner) { }

		const string SKYBOX_CONTROLLER_PATH = "Client/DayNightCycle";
		const string CLOUDS_CONTROLLER_PATH = "Client/CloudsSystem";
		const string POSTPROCESS_MAIN       = "Client/MainPostProcess";

		DaylightCycle _skyboxController = null;
		CloudAnimator _cloudsAnimator   = null;
		GameObject    _postprocess      = null;

		VoxelsStatic _statics = null;

		public float WorldTime {
			get; private set;
		}

		public float TimeScale {
			get; private set;
		}

		public float DayPercent {
			get {
				var days = WorldTime / DayLength;
				var whole = Mathf.FloorToInt(days);
				return days - whole;
			}
		}

		public int DayNumber {
			get {
				var days = WorldTime / DayLength;
				var whole = Mathf.FloorToInt(days);
				return whole;
			}
		}

		public float DayLength { get; private set; } = 600;

		public float AmbientLightIntensity {
			get {
				return _statics.AmbientLightIntensity.Evaluate(DayPercent);
			}
		}

		public override void Init() {
			base.Init();
			_statics  = VoxelsStatic.Instance;
			var sbFab = Resources.Load(SKYBOX_CONTROLLER_PATH);
			var clFab = Resources.Load(CLOUDS_CONTROLLER_PATH);
			var ppFab = Resources.Load(POSTPROCESS_MAIN);
			_skyboxController = Object.Instantiate((GameObject)sbFab, null).GetComponent<DaylightCycle>();
			_cloudsAnimator   = Object.Instantiate((GameObject)clFab, null).GetComponent<CloudAnimator>();
			_postprocess      = Object.Instantiate((GameObject)ppFab, null);
		}

		public override void Update() {
			base.Update();
			WorldTime += Time.deltaTime * TimeScale;
		}

		public void SetTimeParameters(float time, float timeScale, float dayLength) {
			WorldTime = time;
			TimeScale = timeScale;
			DayLength = dayLength;
		}
	}
}