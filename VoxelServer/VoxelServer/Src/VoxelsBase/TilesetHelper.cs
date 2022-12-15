using UnityEngine;

namespace Voxels {
	//Only square tilesets are supported
	public sealed class TilesetHelper {
		public readonly int TileSizePixels = 16;
		public readonly int TilesetSizePixels = 512;

		float _uvPerTile = 1f;

		public TilesetHelper(int tileSize, int tilesetSize) {
			TilesetSizePixels = tileSize;
			TilesetSizePixels = tilesetSize;
			_uvPerTile = 1f / (TilesetSizePixels / TileSizePixels);
		}

		public Vector2 RelativeToAbsolute(float u, float v, Byte2 tilePos) {
			return new Vector2(_uvPerTile * u + tilePos.X * _uvPerTile, 1 - (_uvPerTile * v + tilePos.Y * _uvPerTile));
		}

		public int TilesetWidthTiles {
			get {
				return TilesetSizePixels / TileSizePixels;
			}
		}

		public int TileCount {
			get {
				return TilesetWidthTiles * TilesetWidthTiles;
			}
		}
	}
}
