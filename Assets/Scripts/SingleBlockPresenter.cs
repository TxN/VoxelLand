using UnityEngine;

namespace Voxels {
	[RequireComponent(typeof(MeshRenderer))]
	[RequireComponent(typeof(MeshFilter))]
	public sealed class SingleBlockPresenter : MonoBehaviour {
		public MeshRenderer Renderer       = null;
		public MeshFilter   Filter         = null;
		public Vector3      Offset         = new Vector3(-0.5f, -0.5f, -0.5f);

		GeneratableMesh _genMesh = null;
			
		private void Awake() {
			Init();
			DrawBlock(new BlockData(BlockType.Bricks, 0));
		}

		public void Init() {
			Renderer = GetComponent<MeshRenderer>();
			Filter   = GetComponent<MeshFilter>();
			_genMesh = new GeneratableMesh(64);
		}

		public void DrawBlock(BlockData data) {
			_genMesh.ClearAll();
			var library = ChunkManager.Instance.Library;
			var desc = library.GetBlockDescription(data.Type);
			var inp = new MesherBlockInput() { Block = data, Lighting = LightInfo.FullLit, Position = Byte3.Zero, Visibility = VisibilityFlags.All };
			BlockModelGenerator.AddBlock(_genMesh, desc, ref Offset,ref inp);
			Renderer.material = library.OpaqueMaterial;
			_genMesh.BakeMesh();
			Filter.mesh = _genMesh.Mesh;
		}


		private void OnDestroy() {
			Filter.mesh = null;
			_genMesh.Destroy();
		}
	}

}
