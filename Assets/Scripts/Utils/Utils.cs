using System;

using UnityEngine;

using ZeroFormatter;

namespace Voxels {
	[Serializable]
	public struct Byte2: System.IEquatable<Byte2> {
		public byte X;
		public byte Y;

		public Byte2(byte x, byte y) {
			X = x;
			Y = y;
		}

		public Byte2 Zero {
			get {
				return new Byte2(0, 0);
			}
		}


		public override bool Equals(object obj) {
			return Equals((Byte2)obj);
		}

		public bool Equals(Byte2 other) =>
			X == other.X && Y == other.Y;

		public override int GetHashCode() {
			return 256 * X + Y;
		}
	}

	[Serializable]
	[ZeroFormattable]
	public struct Int3: System.IEquatable<Int3> {
		[Index(0)]
		public int X;
		[Index(1)]
		public int Y;
		[Index(2)]
		public int Z;

		public Int3(int x, int y, int z) {
			X = x;
			Y = y;
			Z = z;
		}

		[IgnoreFormat]
		public static Int3 Zero {
			get {
				return new Int3(0, 0, 0);
			}
		}

		public static Int3 operator+ (Int3 a, Int3 b) {
			return a.Add(b);
		}

		public Int3 Add(int x, int y, int z) {
			return new Int3(X + x, Y + y, Z + z);
		}

		public Int3 Add(Int3 other) {
			return new Int3(X + other.X, Y + other.Y, Z + other.Z);
		}

		public bool Equals(Int3 other) {
			return X == other.X && Y == other.Y && Z == other.Z;
		}

		public static float Distance(Int3 a, Int3 b) {
			var x = (b.X - a.X);
			var y = (b.Y - a.Y);
			var z = (b.Z - a.Z);
			return Mathf.Sqrt(x * x + y * y + z * z);
		}

		public static float SquareDistanceFlat(Int3 a, Int3 b) {
			var x = (b.X - a.X);
			var z = (b.Z - a.Z);
			return x * x + z * z;
		}

		public override string ToString() {
			return string.Format("{0} {1} {2}", X, Y, Z);
		}
	}

	[Serializable]
	public struct Byte3 : System.IEquatable<Byte3> {
		public byte X;
		public byte Y;
		public byte Z;

		public Byte3(int x, int y, int z) {
			X = (byte) x;
			Y = (byte) y;
			Z = (byte) z;
		}

		public Byte3(byte x, byte y, byte z) {
			X = x;
			Y = y;
			Z = z;
		}

		public static Byte3 Zero {
			get {
				return new Byte3(0, 0, 0);
			}
		}

		public bool Equals(Byte3 other) {
			return X == other.X && Y == other.Y && Z == other.Z;
		}
	}

	public static class VisibilityFlagsHelper {
		public static bool IsSet(this VisibilityFlags flags, VisibilityFlags flag) {
			return (flags & flag) != 0;
		}

		public static void Set(ref VisibilityFlags flags, VisibilityFlags flag) {
			flags = (flags | flag);
		}

		public static void Unset(VisibilityFlags flags, VisibilityFlags flag) {
			flags = (flags & (~flag));
		}
	}

	public static class ChunkHelper {
		public static Int3 GetChunkIdFromCoords(Vector3 pos) {
			var posX = Mathf.FloorToInt(pos.x);
			var posY = Mathf.FloorToInt(pos.y);
			var posZ = Mathf.FloorToInt(pos.z);
			var fullChunksX = Mathf.FloorToInt(posX / (float)Chunk.CHUNK_SIZE_X);
			var fullChunksY = Mathf.FloorToInt(posY / (float)Chunk.CHUNK_SIZE_Y);
			var fullChunksZ = Mathf.FloorToInt(posZ / (float)Chunk.CHUNK_SIZE_Z);
			return new Int3(fullChunksX, fullChunksY, fullChunksZ);
		}

		public static void Spiral(int dimX, int dimY, Action<int,int> callback) {
			int x, y, dx, dy;
			x = y = dx = 0;
			dy = -1;
			var t = Mathf.Max(dimX, dimY);
			var maxI = t * t;
			for ( int i = 0; i < maxI; i++ ) {
				if ( (-dimX / 2 <= x) && (x <= dimX / 2) && (-dimY / 2 <= y) && (y <= dimY / 2) ) {
					callback(x, y);
				}
				if ( (x == y) || ((x < 0) && (x == -y)) || ((x > 0) && (x == 1 - y)) ) {
					t = dx;
					dx = -dy;
					dy = t;
				}
				x += dx;
				y += dy;
			}
		}
	}

}