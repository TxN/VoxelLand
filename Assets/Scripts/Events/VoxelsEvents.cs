namespace Voxels.Events {
	public struct Event_ChunkUpdate {
		public Chunk UpdatedChunk;
	}

	public struct Event_ChunkMeshUpdate {
		public Chunk UpdatedChunk;
	}

	public struct Event_ChunkLoaded {
		public Chunk LoadedChunk;
		public Int3  Coordinates;
	}
}
