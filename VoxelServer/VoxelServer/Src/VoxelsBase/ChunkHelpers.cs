namespace Voxels {
	public enum DirIndex : byte { //for reference
		UP = 0,
		DOWN = 1,
		RIGHT = 2,
		LEFT = 3,
		FORWARD = 4,
		BACKWARD = 5
	}

	public struct LightInfo {
		public byte SunUp;
		public byte SunDown;
		public byte SunRight;
		public byte SunLeft;
		public byte SunForward;
		public byte SunBackward;

		public byte OUp;
		public byte ODown;
		public byte ORight;
		public byte OLeft;
		public byte OForward;
		public byte OBackward;

		public static LightInfo FullLit = new LightInfo {
			SunUp = Chunk.MAX_SUNLIGHT_VALUE,
			SunDown = Chunk.MAX_SUNLIGHT_VALUE,
			SunRight = Chunk.MAX_SUNLIGHT_VALUE,
			SunLeft = Chunk.MAX_SUNLIGHT_VALUE,
			SunForward = Chunk.MAX_SUNLIGHT_VALUE,
			SunBackward = Chunk.MAX_SUNLIGHT_VALUE,

			OUp = Chunk.MAX_SUNLIGHT_VALUE,
			ODown = Chunk.MAX_SUNLIGHT_VALUE,
			OBackward = Chunk.MAX_SUNLIGHT_VALUE,
			OForward = Chunk.MAX_SUNLIGHT_VALUE,
			OLeft = Chunk.MAX_SUNLIGHT_VALUE,
			ORight = Chunk.MAX_SUNLIGHT_VALUE
		};
	}

	public struct LightRemNode {
		public int X;
		public int Y;
		public int Z;
		public byte Light;

		public LightRemNode(int x, int y, int z, byte val) {
			X = x;
			Y = y;
			Z = z;
			Light = val;
		}
	}
}
