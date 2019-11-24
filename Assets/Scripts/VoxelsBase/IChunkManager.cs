
namespace Voxels {
	public interface IChunkManager {
		int   GetWorldHeight { get; }
		int   GatherNeighbors(Int3 index);
		Chunk GetChunk(int x, int y, int z);
	}
}

