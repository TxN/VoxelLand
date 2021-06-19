using UnityEngine;

namespace Voxels {
	[RequireComponent(typeof(MeshRenderer))]
	[RequireComponent(typeof(MeshFilter))]
	public sealed class SingleBlockPresenter : MonoBehaviour {
		public Vector3      Offset = new Vector3(-0.5f, -0.5f, -0.5f);

		MeshRenderer    _renderer = null;
		MeshFilter      _filter   = null;
		GeneratableMesh _genMesh  = null;
		bool            _inited   = false;

		private void Start() {
			Init();
		}

		public void Init() {
			_renderer = GetComponent<MeshRenderer>();
			_filter   = GetComponent<MeshFilter>();
			_genMesh  = new GeneratableMesh(64);
			_inited   = true;
		}

		public void DrawBlock(BlockData data) {
			_genMesh.ClearAll();
			var library = VoxelsStatic.Instance.Library;
			var desc = library.GetBlockDescription(data.Type);
			var inp = new MesherBlockInput() { Block = data, Lighting = LightInfo.FullLit, Position = Byte3.Zero, Visibility = VisibilityFlags.All };
			BlockModelGenerator.AddBlock(_genMesh, desc, ref Offset,ref inp);
			_renderer.material = library.OpaqueMaterial;
			_genMesh.BakeMesh();
			_filter.mesh = _genMesh.Mesh;
		}

		public void RemoveBlock() {
			if ( !_inited ) {
				return;
			}
			_filter.mesh = null;
			_genMesh.Destroy();
			_inited = false;
		}

		private void OnDestroy() {
			RemoveBlock();
		}
	}
}
