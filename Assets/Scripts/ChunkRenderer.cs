using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSys;

namespace Voxels {
	public class ChunkRenderer : MonoBehaviour {
		public MeshRenderer MeshRenderer = null;
		public MeshFilter   MeshFilter   = null;
		public MeshCollider Collider     = null;
		public MeshFilter   TransparentFilter = null;
		Chunk _targetChunk = null;

		private void Start() {
			EventManager.Subscribe<Event_ChunkMeshUpdate>(this, OnChunkUpdate);
			UpdateRenderer();
		}

		public void Setup(Chunk targetChunk) {
			_targetChunk = targetChunk;
			UpdateRenderer();
		}

		void UpdateRenderer() {
			MeshFilter.mesh = null;
			MeshFilter.mesh = _targetChunk.OpaqueCollidedMesh.Mesh;
			TransparentFilter.mesh = null;
			TransparentFilter.mesh = _targetChunk.TranslucentPassableMesh.Mesh;
			Collider.sharedMesh = null;
			Collider.sharedMesh = _targetChunk.OpaqueCollidedMesh.Mesh;
		}

		void OnChunkUpdate(Event_ChunkMeshUpdate e) {
			if ( e.UpdatedChunk == _targetChunk ) {
				UpdateRenderer();
			}
		}

		private void OnDestroy() {
			EventManager.Unsubscribe<Event_ChunkMeshUpdate>(OnChunkUpdate);
		}
	}
}

