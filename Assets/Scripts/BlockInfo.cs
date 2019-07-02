namespace Voxels {
	public struct BlockInfo {
		public BlockData Block;
		public Int3      InChunkPos;
		public Chunk     Chunk;

		public bool IsEmpty() {
			return Chunk == null || Block.IsEmpty();
		}
	}
}

