using UnityEngine;

using SMGCore;
using SMGCore.EventSys;
using Voxels.Events;
using Voxels.Networking.Clientside;
using Voxels.Networking.Utils;

namespace Voxels {
	public sealed class ChunkRenderer : MonoBehaviour, IPoolItem {
		public MeshRenderer MeshRenderer           = null;
		public MeshFilter   MeshFilter             = null;
		public MeshCollider Collider               = null;
		public MeshFilter   TransparentFilter      = null;
		public MeshFilter   OpaquePassableFilter   = null;
		public MeshCollider OpaquePassableCollider = null;

		Chunk _targetChunk   = null;
		bool _colliderInited = false;

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

		void Update() {
			if ( !_colliderInited && _targetChunk != null && _targetChunk.OpaqueCollidedMesh != null && _targetChunk.OpaquePassableMesh != null ) {
				var p = ClientPlayerEntityManager.Instance.LocalPlayer;
				if ( GetDistanceToPlayer() < WorldOptions.PhysXCollisionDist ) {
					UpdateColliders();
				}
			}
		}

		void UpdateColliders() {
			_colliderInited = true;
			Collider.sharedMesh = _targetChunk.OpaqueCollidedMesh.Mesh;
			OpaquePassableCollider.sharedMesh = _targetChunk.OpaquePassableMesh.Mesh;
		}

		float GetDistanceToPlayer() {
			if ( ClientChatManager.Instance == null || _targetChunk == null ) {
				return 0;
			}
			var p = ClientPlayerEntityManager.Instance.LocalPlayer;
			if ( p == null ) {
				return 0;
			}
			return Vector3.Distance(_targetChunk.OriginPos, p.Position);
		}

		void DeInitRenderer() {
			MeshFilter.mesh                   = null;
			TransparentFilter.mesh            = null;
			Collider.sharedMesh               = null;
			OpaquePassableFilter.mesh         = null;
			OpaquePassableCollider.sharedMesh = null;
			_colliderInited = false;
		}

		void UpdateRenderer() {
			_colliderInited = false;
			DeInitRenderer();
			MeshFilter.mesh           = _targetChunk.OpaqueCollidedMesh.Mesh;
			TransparentFilter.mesh    = _targetChunk.TranslucentPassableMesh.Mesh;
			OpaquePassableFilter.mesh = _targetChunk.OpaquePassableMesh.Mesh;

			if ( GetDistanceToPlayer() < WorldOptions.PhysXCollisionDist ) {
				UpdateColliders();
			}
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
