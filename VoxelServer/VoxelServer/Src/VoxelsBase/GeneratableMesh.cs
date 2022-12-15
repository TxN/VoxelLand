using System.Collections.Generic;
using UnityEngine;

namespace Voxels {
	public sealed class GeneratableMesh {
		public List<Color32> Colors;
		public List<int>     Triangles;
		public List<Vector2> UVs;
		public List<Vector3> Vertices;
		public Mesh          Mesh;

		public GeneratableMesh(int capacity) {
			Mesh      = new Mesh();
			Colors    = new List<Color32>(capacity);
			Triangles = new List<int>    (capacity);
			UVs       = new List<Vector2>(capacity);
			Vertices  = new List<Vector3>(capacity);
		}		

		public void ClearData() {
			Colors.Clear();
			Triangles.Clear();
			UVs.Clear();
			Vertices.Clear();
		}

		public void ClearMesh() {
		}

		public void ClearAll() {
			ClearData();
			ClearMesh();
		}

		public void BakeMesh() {
			Mesh.Clear();
			Mesh.SetVertices(Vertices);
			Mesh.SetUVs(0, UVs);
		}

		public void Destroy() {
		}
	}
}
