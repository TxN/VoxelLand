using UnityEngine;

using SMGCore;

namespace Voxels {
	public sealed class VoxelsStatic : ManualSingleton<VoxelsStatic> {
		public ResourceLibrary       Library          = null;
		public BlockPreviewGenerator PreviewGenerator = null;
		public TilesetHelper         TilesetHelper { get; private set; } = null;

		protected override void Awake() {
			base.Awake();
			TilesetHelper = new TilesetHelper(Library.TileSize, Library.TilesetSize);
			Library.Init(PreviewGenerator);
			BlockModelGenerator.PrepareGenerator(TilesetHelper);
		}

		private void OnDestroy() {
			Library.DeInit();
		}
	}

}
