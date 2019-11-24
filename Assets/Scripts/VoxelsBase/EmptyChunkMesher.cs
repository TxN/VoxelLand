using System.Collections.Generic;

namespace Voxels {
	public class EmptyChunkMesher : IChunkMesher {
		public bool Busy {
			get {
				return false;
			}
		}

		public bool Ready {
			get {
				return true;
			}
		}

		public List<MesherBlockInput> Blocks {
			get {
				return null;
			}
		}

		public GeneratableMesh OpaqueCollidedMesh {
			get {
				return null;
			}
		}

		public GeneratableMesh OpaquePassableMesh {
			get {
				return null;
			}
		}

		public GeneratableMesh TranslucentPassableMesh {
			get {
				return null;
			}
		}

		public void DeInit() {
			return;
		}

		public void FinalizeBake() {
			return;
		}

		public void PrepareMesher() {
			return;
		}

		public void StartAsyncMeshing() {
			return;
		}
	}
}
