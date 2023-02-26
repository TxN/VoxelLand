using UnityEngine;

using Voxels.Networking.Clientside;

namespace Voxels {
	public sealed class DaylightCycle : MonoBehaviour {
		public Gradient SkyColor        = null;
		public Gradient HorizonColor    = null;
		public Gradient SunColor        = null;
		public Gradient UnderwaterColor = null;
		public Material SkyboxMaterial  = null;
		public Material CloudMaterial   = null;

		public Vector2 NormalFogParams     = new Vector2(60, 160);
		public Vector2 NightFogParams      = new Vector2(30, 110);
		public Vector2 UnderwaterFogParams = new Vector2(0, 20);

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
			Shader.SetGlobalVector("_SunDirection", sunVec);
			Shader.SetGlobalColor("_SunGlobalColor", sunColor);
			var intensity = ClientWorldStateController.Instance.AmbientLightIntensity;
			var fogParams = Vector2.Lerp(NightFogParams, NormalFogParams, intensity);

			_statics.OpaqueMaterial.SetFloat("_Daylight", intensity);
			_statics.TranslucentMaterial.SetFloat("_Daylight", intensity);
			SkyboxMaterial.SetFloat("_LightLevel", intensity);

			var isUnderwater = ClientPlayerEntityManager.Instance.LocalPlayer?.View?.Mover?.IsUnderwater ?? false;
			if ( isUnderwater ) {
				var underwaterColor = UnderwaterColor.Evaluate(dayPercent);
				RenderSettings.fogStartDistance = UnderwaterFogParams.x;
				RenderSettings.fogEndDistance = UnderwaterFogParams.y;
				RenderSettings.fogColor = underwaterColor;
			} else {
				RenderSettings.fogColor = skyColor;
				RenderSettings.fogStartDistance = fogParams.x;
				RenderSettings.fogEndDistance = fogParams.y;
			}

			
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
			return upVector.normalized;
		}
	}
}
