using System.Collections.Generic;
using UnityEngine;

namespace Voxels {
	public sealed class ResourceLibrary : ScriptableObject {
		public Texture2D BlockTilest = null;
		public int       TilesetSize = 512;
		public int       TileSize    = 16;

		public List<BlockDescription> BlockDescriptions = new List<BlockDescription>();

		Dictionary<BlockType, BlockDescription> _blockDescDict = null;
		List<bool> _blockFullFlags        = null;
		List<bool> _blockTranslucentFlags = null;
		List<bool> _blockIllumFlags       = null;
		List<bool> _blockLightPassFlags   = null;

		public BlockDescription GetBlockDescription(BlockType type) {
			_blockDescDict.TryGetValue(type, out var res);
			return res;
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
			if ( _blockDescDict != null ) {
				return;
			}
			var maxBlockValue = 0;
			var typeValues = System.Enum.GetValues(typeof(BlockType));
			foreach ( var t in  typeValues) {
				var intVal = (byte)t;
				if ( intVal > maxBlockValue ) {
					maxBlockValue = intVal;
				}
			}
			_blockDescDict  = new Dictionary<BlockType, BlockDescription>(BlockDescriptions.Count);
			_blockFullFlags        = new List<bool>(maxBlockValue);
			_blockTranslucentFlags = new List<bool>(maxBlockValue);
			_blockIllumFlags       = new List<bool>(maxBlockValue);
			_blockLightPassFlags   = new List<bool>(maxBlockValue);
			for ( int i = 0; i <= maxBlockValue; i++ ) {
				_blockFullFlags.Add(false);
				_blockTranslucentFlags.Add(false);
				_blockIllumFlags.Add(false);
				_blockLightPassFlags.Add(false);
			}
			foreach ( var desc in BlockDescriptions ) {
				_blockDescDict.Add(desc.Type, desc);
				var key =  (int)desc.Type;
				_blockFullFlags[key]        =  desc.IsFull;
				_blockTranslucentFlags[key] =  desc.IsTranslucent;
				_blockIllumFlags[key]       =  desc.IsLightEmitting;
				_blockLightPassFlags[key]   = !desc.IsFull || desc.IsTranslucent;
			}
		}
	}

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
	}
}
