namespace UnityEngine {
	public static class Random {
		static System.Random _generator;

		public static System.Random Generator {
			get {
				if ( _generator == null ) {
					_generator = new System.Random();
				}
				return _generator;
			}
		}

		public static int Range(int min, int max) {
			return Generator.Next(min, max);
		}
	}
}
