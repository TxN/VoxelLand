namespace Voxels {
	public sealed class GeneratedChunkData {
		public Int3        WorldCoords;
		public BlockData[] Blocks;
		public byte[]      Heightmap;
		public int         MaxHeight;
		public int         WaterLevel;

		public GeneratedChunkData(Int3 worldCoords, BlockData[] blocks, byte[] heightmap, int maxHeight, int waterLevel) {
			WorldCoords = worldCoords;
			Blocks      = blocks;
			Heightmap   = heightmap;
			MaxHeight   = maxHeight;
			WaterLevel  = waterLevel;
		}
	}
}
