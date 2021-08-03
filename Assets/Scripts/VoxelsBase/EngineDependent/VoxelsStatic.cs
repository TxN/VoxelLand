using UnityEngine;

using SMGCore;

using Voxels.Game;

namespace Voxels {
	public sealed class VoxelsStatic : ManualSingleton<VoxelsStatic> {
		[Header("Graphic assets")]
		public AnimationCurve AmbientLightIntensity = new AnimationCurve();
		public Material       OpaqueMaterial        = null;
		public Material       TranslucentMaterial   = null;

		[Header("Blocks data")]
		public BlockPreviewGenerator PreviewGenerator = null;
		public BlockPreviewProvider  PreviewProvider  = null;
		
		[Header("Tileset Settings")]
		public int       TilesetSize = 512;
		public int       TileSize    = 16;
		public Texture2D BlockTilest = null;

		public TilesetHelper         TilesetHelper { get; private set; } = null;

		protected override void Awake() {
			base.Awake();
			TilesetHelper = new TilesetHelper(TileSize, TilesetSize);
			BlockModelGenerator.PrepareGenerator(TilesetHelper);
			PreviewProvider = new BlockPreviewProvider(PreviewGenerator);
		}

		void OnDestroy() {
			PreviewProvider.DeInit();
		}
	}
}
