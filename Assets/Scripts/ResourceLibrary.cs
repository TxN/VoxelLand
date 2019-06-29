using System.Collections.Generic;
using UnityEngine;

namespace Voxels {
	public sealed class ResourceLibrary : ScriptableObject {
		public Material OpaqueMaterial      = null;
		public Material TranslucentMaterial = null;
		public Texture2D BlockTilest        = null;
		public int       TilesetSize        = 512;
		public int       TileSize           = 16;

		public List<BlockDescription> BlockDescriptions = new List<BlockDescription>();

		BlockDescription[] _desc                  = null;
		bool[]             _blockFullFlags        = null;
		bool[]             _blockTranslucentFlags = null;
		bool[]             _blockIllumFlags       = null;
		bool[]             _blockLightPassFlags   = null;

		public BlockDescription GetBlockDescription(BlockType type) {
			return _desc[(byte) type];
		}

		public bool IsFullBlock(BlockType type) {
			return _blockFullFlags[(byte) type];
		}

		public bool IsTranslucentBlock(BlockType type) {
			return _blockTranslucentFlags[(byte)type];
		}

		public bool IsLightPassBlock(BlockType type) {
			return _blockLightPassFlags[(byte)type];
		}

		public bool IsEmissiveBlock(BlockType type) {
			return _blockIllumFlags[(ushort)type];
		}

		public void GenerateBlockDescDict() {
			var maxBlockValue = 0;
			var typeValues = System.Enum.GetValues(typeof(BlockType));
			foreach ( var t in  typeValues) {
				var intVal = (byte)t;
				if ( intVal > maxBlockValue ) {
					maxBlockValue = intVal;
				}
			}
			_desc                  = new BlockDescription[byte.MaxValue];
			_blockFullFlags        = new bool[maxBlockValue];
			_blockTranslucentFlags = new bool[maxBlockValue];
			_blockIllumFlags       = new bool[maxBlockValue];
			_blockLightPassFlags   = new bool[maxBlockValue];

			foreach ( var desc in BlockDescriptions ) {				
				var key =  (int)desc.Type;
				_desc[key]                  = desc;
				_blockFullFlags[key]        =  desc.IsFull;
				_blockTranslucentFlags[key] =  desc.IsTranslucent;
				_blockIllumFlags[key]       =  desc.IsLightEmitting;
				_blockLightPassFlags[key]   = !desc.IsFull || desc.IsTranslucent;
			}
		}
	}

	//Only square tilesets are supported
	public sealed class TilesetHelper {
		public readonly int TileSizePixels    = 16;
		public readonly int TilesetSizePixels = 512;

		float _uvPerTile = 1f;

		public TilesetHelper(int tileSize, int tilesetSize) {
			TilesetSizePixels = tileSize;
			TilesetSizePixels = tilesetSize;
			_uvPerTile = 1f / (TilesetSizePixels / TileSizePixels);
		}

		public Vector2 RelativeToAbsolute(float u, float v, Byte2 tilePos) {
			return new Vector2(_uvPerTile *  u + tilePos.X * _uvPerTile, 1 - (_uvPerTile *  v + tilePos.Y * _uvPerTile) );
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
