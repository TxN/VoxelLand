using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voxels;

public class GeneratorTest : MonoBehaviour {
	public ResourceLibrary Library      = null;
	public MeshFilter      MeshFilter   = null;
	public MeshRenderer    MeshRenderer = null;

	GeneratableMesh _usedMesh = null;
	TilesetHelper   _tilesetHelper = null;

	private void Start() {
		_tilesetHelper = new TilesetHelper(Library.TileSize, Library.TilesetSize);
		_usedMesh = new GeneratableMesh(1024);
		_usedMesh.ClearAll();
		var pos = Vector3.zero;
		for ( int i = 0; i < 10; i++ ) {
			//BlockModelGenerator.AddBlock(_usedMesh, _tilesetHelper, Library.GetBlockDescription(BlockType.Grass), 0, pos, 0, VisibilityFlags.All);
			pos += Vector3.forward;
		}
		
		_usedMesh.BakeMesh();
		MeshFilter.mesh = _usedMesh.Mesh;
		
	}

	private void OnDestroy() {
		if ( _usedMesh != null ) {
			_usedMesh.Destroy();
		}
	}
}
