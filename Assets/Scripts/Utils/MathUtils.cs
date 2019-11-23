namespace Voxels.Utils {
	public static class MathUtils {
		public static float Remap(float inValue, float inMin, float inMax, float outMin, float outMax) {
			return outMin + (outMax - outMin) * ((inValue - inMin) / (inMax - inMin));
		}
	}
}

