using UnityEngine;

namespace Voxels.Utils {
	public static class MathUtils {
		public static float Remap(float inValue, float inMin, float inMax, float outMin, float outMax) {
			return outMin + (outMax - outMin) * ((inValue - inMin) / (inMax - inMin));
		}

		public static Vector3 UnpackRotation(Byte3 rot) {
			var pitch = Remap(rot.X, 0, 255, 0, 360);
			var yaw   = Remap(rot.Y, 0, 255, 0, 360);
			var roll  = Remap(rot.Z, 0, 255, 0, 360);

			return new Vector3(pitch, yaw, roll);
		}

		public static Byte3 PackRotation(Vector3 rot) {
			var p = (byte)Mathf.RoundToInt(Remap(rot.x, 0, 360, 0, 255));
			var y = (byte)Mathf.RoundToInt(Remap(rot.y, 0, 360, 0, 255));
			var r = (byte)Mathf.RoundToInt(Remap(rot.z, 0, 360, 0, 255));
			return new Byte3(p, y, r);
		}
	}
}

