using System.Runtime.InteropServices;

using ZeroFormatter;

namespace Voxels {
	[ZeroFormattable]
	[StructLayout(LayoutKind.Sequential)]
	public struct BlockData {
		[Index(0)]
		public BlockType  Type;
		[Index(1)]
		public byte       Subtype;
		[Index(2)]
		public byte       SunLevel;
		[Index(3)]
		public byte       LightLevel;
		[Index(4)]
		public ushort     AddColor;
		[Index(5)]
		public ushort     Metadata;

		[IgnoreFormat]
		public BlockDescription Info {
			get {
				return VoxelsStatic.Instance.Library.GetBlockDescription(Type);
			}
		}

		[IgnoreFormat]
		public static int StructSize {
			get {
				if ( _cachedSize == 0 ) {
					_cachedSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(BlockData));
				}
				return _cachedSize;
			}
		}

		static int _cachedSize = 0;

		public BlockData(BlockType type) {
			Type       = type;
			Subtype    = 0;
			Metadata   = 0;
			SunLevel   = 0;
			LightLevel = 0;
			AddColor   = 65535;
		}

		public BlockData(BlockType type, byte subtype) {
			Type       = type;
			Subtype    = subtype;
			Metadata   = 0;
			SunLevel   = 0;
			LightLevel = 0;
			AddColor   = 65535;
		}

		public BlockData(BlockType type, byte subtype, byte sunLevel, byte lightLevel, ushort addColor, ushort metadata) {
			Type       = type;
			Subtype    = subtype;
			Metadata   = metadata;
			SunLevel   = sunLevel;
			LightLevel = lightLevel;
			AddColor   = addColor;
		}

		public static BlockData Empty {
			get {
				return new BlockData(BlockType.Air);
			}
		}

		public bool IsEmpty() {
			return Type == BlockType.Air;
		}

		public override bool Equals(object obj) {
			return base.Equals(obj);
		}

		public override int GetHashCode() {
			return base.GetHashCode();
		}

		public static bool operator ==(BlockData a, BlockData b) {
			return a.Type == b.Type && a.Subtype == b.Subtype && a.Metadata == b.Metadata && a.AddColor == b.AddColor && a.LightLevel == b.LightLevel && a.SunLevel == b.SunLevel;
		}
		public static bool operator !=(BlockData a, BlockData b) {
			return a.Type != b.Type || a.Subtype != b.Subtype || a.Metadata != b.Metadata || a.AddColor != b.AddColor || a.SunLevel != b.SunLevel || a.LightLevel != b.LightLevel;
		}
	}
}
