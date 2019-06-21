using UnityEngine;
using EventSys;

namespace Voxels {
	public sealed class ChunkRenderer : MonoBehaviour, IPoolItem {
		public MeshRenderer MeshRenderer      = null;
		public MeshFilter   MeshFilter        = null;
		public MeshCollider Collider          = null;
		public MeshFilter   TransparentFilter = null;
		Chunk _targetChunk = null;

		public void Setup(Chunk targetChunk) {
			EventManager.Subscribe<Event_ChunkMeshUpdate>(this, OnChunkUpdate);
			_targetChunk = targetChunk;
			UpdateRenderer();
			gameObject.SetActive(true);
		}

		public void DeInit() {
			EventManager.Unsubscribe<Event_ChunkMeshUpdate>(OnChunkUpdate);
			DeInitRenderer();
			_targetChunk = null;
		}

		void DeInitRenderer() {
			MeshFilter.mesh        = null;
			TransparentFilter.mesh = null;
			Collider.sharedMesh    = null;
		}

		void UpdateRenderer() {
			DeInitRenderer();
			MeshFilter.mesh        = _targetChunk.OpaqueCollidedMesh.Mesh;
			TransparentFilter.mesh = _targetChunk.TranslucentPassableMesh.Mesh;
			Collider.sharedMesh    = _targetChunk.OpaqueCollidedMesh.Mesh;
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
