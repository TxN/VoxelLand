using System.Collections.Generic;

namespace Voxels {
	public interface IChunkMesher {
		bool                   Busy   { get; }
		bool                   Ready  { get; }
		List<MesherBlockInput> Blocks { get; }

		GeneratableMesh OpaqueCollidedMesh      {get;}
		GeneratableMesh OpaquePassableMesh      {get;}
		GeneratableMesh TranslucentPassableMesh {get;}
		

		void PrepareMesher();
		void InitData(Chunk data);
		void DeInit();
		void StartAsyncMeshing();
		void FinalizeBake();
	}
}
