namespace Voxels {
	public struct BlockData {
		public BlockType  Type;
		public byte       Subtype;	
		public byte       SunLevel;
		public byte       LightLevel;
		public ushort     AddColor;
		public ushort     Metadata;

		public BlockDescription Info {
			get {
				return ChunkManager.Instance.Library.GetBlockDescription(Type);
			}
		}

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
