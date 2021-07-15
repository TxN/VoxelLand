using UnityEngine;

using Voxels.Networking.Clientside;

namespace Voxels {
	public sealed class DaylightCycle : MonoBehaviour {
		public Gradient SkyColor       = null;
		public Gradient HorizonColor   = null;
		public Gradient SunColor       = null;
		public Material SkyboxMaterial = null;

		VoxelsStatic _statics = null;

		void Start() {
			_statics = VoxelsStatic.Instance;
		}

		void Update() {
			var wsc = ClientWorldStateController.Instance;
			if ( wsc == null ) {
				return;
			}
			var dayPercent   = wsc.DayPercent;
			var skyColor     = SkyColor.Evaluate(dayPercent);
			var horizonColor = HorizonColor.Evaluate(dayPercent);
			var sunColor = SunColor.Evaluate(dayPercent);
			SkyboxMaterial.SetColor("_SkyColor1", skyColor);
			SkyboxMaterial.SetColor("_SkyColor2", horizonColor);
			SkyboxMaterial.SetColor("_SkyColor3", skyColor);
			SkyboxMaterial.SetColor("_SunColor",  sunColor);

			var sunAlt = (360f * dayPercent) + 85;
			var sunVec = SunPosToVector(2f, sunAlt);
			SkyboxMaterial.SetVector("_SunVector", sunVec);

			var intensity = ClientWorldStateController.Instance.AmbientLightIntensity;
			_statics.OpaqueMaterial.SetFloat("_Daylight", intensity);
			_statics.TranslucentMaterial.SetFloat("_Daylight", intensity);	
		}

		Vector4 SunPosToVector(float az, float al) {
			var raz = az * Mathf.Deg2Rad;
			var ral = al * Mathf.Deg2Rad;

			var upVector = new Vector4(
				Mathf.Cos(ral) * Mathf.Sin(raz),
				Mathf.Sin(ral),
				Mathf.Cos(ral) * Mathf.Cos(raz),
				0.0f
			);
			return upVector;
		}
	}
}
