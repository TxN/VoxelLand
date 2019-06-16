using UnityEngine;

namespace Voxels {
	public sealed class DaylightCycle : MonoBehaviour {
		public AnimationCurve LightIntensityCurve = null;
		public Gradient SkyColor     = null;
		public Gradient HorizonColor = null;
		public Gradient SunColor     = null;
		public Material SkyboxMaterial = null;
		public Material TilesetOpaqueMaterial = null;
		public Material TilesetTranslucentMaterial = null;

		public float TimeScale = 1f;

		public float DayLength = 1200f;

		float _time = 0f;

		void Update() {
			_time += TimeScale * Time.deltaTime;
			var dayPercent = _time / DayLength;
			if ( dayPercent > 1f) {
				_time = 0f;
			}
			var skyColor = SkyColor.Evaluate(dayPercent);
			var horizonColor = HorizonColor.Evaluate(dayPercent);
			var sunColor = SunColor.Evaluate(dayPercent);
			SkyboxMaterial.SetColor("_SkyColor1", skyColor);
			SkyboxMaterial.SetColor("_SkyColor2", horizonColor);
			SkyboxMaterial.SetColor("_SkyColor3", skyColor);
			SkyboxMaterial.SetColor("_SunColor", sunColor);

			var sunAlt = (360f * dayPercent) + 85;
			var sunVec = SunPosToVector(2f, sunAlt);
			SkyboxMaterial.SetVector("_SunVector", sunVec);

			TilesetOpaqueMaterial.SetFloat("_Daylight", LightIntensityCurve.Evaluate(dayPercent));
			TilesetTranslucentMaterial.SetFloat("_Daylight", LightIntensityCurve.Evaluate(dayPercent));
			
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

