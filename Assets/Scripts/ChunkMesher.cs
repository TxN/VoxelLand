using System.Collections.Generic;

using UnityEngine;

namespace Voxels {
	public enum BlockMeshType : byte {
		CollidedOpaque = 0,
		PassableTranslucent = 1,
		CollidedTranslucent = 2,
		PassableOpaque = 3,
	}

	public struct MesherBlockInput {
		public BlockData Block;
		public Byte3 Position;
		public LightInfo Lighting;
		public VisibilityFlags Visibility;
	}

	public sealed class ChunkMesher {

		public bool Ready { get; private set; }

		public List<MesherBlockInput> Blocks;

		GeneratableMesh _opaqueCollidedMesh      = null;
		GeneratableMesh _translucentPassableMesh = null;
		Vector3         _originPos               = Vector3.zero;
		ResourceLibrary _library                 = null;

		public ChunkMesher(ResourceLibrary library, int chunkMeshCapacity, int capacity, Vector3 originPos) {
			_opaqueCollidedMesh = new GeneratableMesh(chunkMeshCapacity);
			_translucentPassableMesh = new GeneratableMesh(chunkMeshCapacity / 8);
			_library = library;
			Blocks = new List<MesherBlockInput>(capacity);
			_originPos = originPos;
		}

		public GeneratableMesh OpaqueCollidedMesh {
			get { return _opaqueCollidedMesh; }
		}

		public GeneratableMesh TranslucentPassableMesh {
			get { return _translucentPassableMesh; }
		}

		public void PrepareMesher() {
			_opaqueCollidedMesh.ClearAll();
			_translucentPassableMesh.ClearAll();
			Blocks.Clear();
		}

		public void StartMeshing() {
			Ready = false;
			foreach ( var blockData in Blocks ) {			
				var pos  = _originPos + new Vector3(blockData.Position.X, blockData.Position.Y, blockData.Position.Z);
				var desc = _library.GetBlockDescription(blockData.Block.Type);
				if ( desc.IsTranslucent ) {
					BlockModelGenerator.AddBlock(_translucentPassableMesh, desc, blockData.Block, pos, blockData.Visibility, blockData.Lighting);
				}
				else {
					BlockModelGenerator.AddBlock(_opaqueCollidedMesh, desc, blockData.Block, pos, blockData.Visibility, blockData.Lighting);
				}
			}
			//Do some magic
			_opaqueCollidedMesh.BakeMesh();
			_translucentPassableMesh.BakeMesh();
			Ready = true;
		}
	}
}

