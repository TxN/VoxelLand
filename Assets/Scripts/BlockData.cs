namespace Voxels {
	public struct BlockData {
		public BlockDescription Info { get {
				return ChunkManager.Instance.Library.GetBlockDescription(Type);
		} }
		public BlockType        Type;
		public byte             Subtype;
		public ushort           Metadata; //Для текущих нужд и байта хватит.
		public byte             SunLevel;
		public byte             LightLevel;
		public ushort           AddColor;


		public BlockData(BlockType type) {
			Type       = type;
			Subtype    = 0;
			Metadata   = 0;
			SunLevel   = 0;
			LightLevel = 0;
			AddColor   = 0;
		}

		public BlockData(BlockType type, byte subtype) {
			Type       = type;
			Subtype    = subtype;
			Metadata   = 0;
			SunLevel   = 0;
			LightLevel = 0;
			AddColor   = 0;
		}

		public static BlockData Empty {
			get {
				return new BlockData(BlockType.Air);
			}
		}

		public bool IsEmpty() {
			return Type == BlockType.Air;
		}
	}
}
