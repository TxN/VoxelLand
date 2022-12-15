using System.Collections.Generic;

namespace Voxels {
	public sealed class BlockInfoProvider {
		public List<BlockDescription> BlockDescriptions = null;

		BlockDescription[] _desc                  = null;
		bool[]             _blockFullFlags        = null;
		bool[]             _blockTranslucentFlags = null;
		bool[]             _blockIllumFlags       = null;
		bool[]             _blockLightPassFlags   = null;
		CollisionInfo[]    _collisionModels       = null;

		public BlockInfoProvider(List<BlockDescription> blockData) {
			BlockDescriptions = blockData;
			GenerateBlockDescDict();
		}

		public BlockDescription GetBlockDescription(BlockType type) {
			return _desc[(byte)type];
		}

		public bool IsFullBlock(BlockType type) {
			return _blockFullFlags[(byte)type];
		}

		public bool IsTranslucentBlock(BlockType type) {
			return _blockTranslucentFlags[(byte)type];
		}

		public bool IsLightPassBlock(BlockType type) {
			return _blockLightPassFlags[(byte)type];
		}

		public bool IsEmissiveBlock(BlockType type, byte subtype) {
			var hash = (byte)type * 256 + subtype;
			return _blockIllumFlags[hash];
		}

		public CollisionInfo GetCollisionInfo(BlockCollisionModel type) {
			return _collisionModels[(int)type];
		}

		void GenerateBlockDescDict() {
			var maxBlockValue = 0;
			var typeValues = System.Enum.GetValues(typeof(BlockType));
			foreach ( var t in typeValues ) {
				var intVal = (byte)t;
				if ( intVal > maxBlockValue ) {
					maxBlockValue = intVal;
				}
			}
			maxBlockValue++;
			_desc = new BlockDescription[byte.MaxValue];
			_blockFullFlags = new bool[maxBlockValue];
			_blockTranslucentFlags = new bool[maxBlockValue];
			_blockIllumFlags = new bool[maxBlockValue * 256];
			_blockLightPassFlags = new bool[maxBlockValue];
			var colTypes = System.Enum.GetValues(typeof(BlockCollisionModel));
			_collisionModels = new CollisionInfo[colTypes.Length];

			foreach ( var coltype in colTypes ) {
				var info = CollisionInfo.GetForBlock((BlockCollisionModel)coltype);
				var index = (int) coltype;
				_collisionModels[index] = info;
			}

			foreach ( var desc in BlockDescriptions ) {
				var key = (int)desc.Type;
				_desc[key] = desc;
				_blockFullFlags[key] = desc.IsFull;
				_blockTranslucentFlags[key] = desc.IsTranslucent;
				var subtypeIndex = 0;
				foreach ( var subtype in desc.Subtypes ) {
					var hash = (byte)desc.Type * 256 + subtypeIndex;
					_blockIllumFlags[hash] = desc.Subtypes[subtypeIndex].IsLightEmitting;
					subtypeIndex++;
				}

				_blockLightPassFlags[key] = !desc.IsFull || desc.IsTranslucent;
			}
		}
	}
}
