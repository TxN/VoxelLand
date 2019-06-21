namespace Voxels {
	public sealed class ChunkRendererPool: PrefabPool<ChunkRenderer> {

		public ChunkRendererPool() {
			PresenterPrefabPath = "ChunkRender";
		}
	}
}
