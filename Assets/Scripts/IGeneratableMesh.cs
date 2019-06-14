using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Voxels {
	public interface IGeneratableMesh {
		List<Vector3> Vertices  { get; }
		List<int>     Triangles { get; }
		List<Color>   Colors    { get; }
		List<Vector2> UVs       { get; }
		Mesh          Mesh      { get; }
		void ClearData();
		void ClearAll();
		void BakeMesh();
	}
}

