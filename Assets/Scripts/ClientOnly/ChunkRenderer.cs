using UnityEngine;

using SMGCore;
using SMGCore.EventSys;
using Voxels.Events;
using Voxels.Networking.Clientside;

namespace Voxels {
	public sealed class ChunkRenderer : PoolItem {
		public MeshRenderer MeshRenderer           = null;
		public MeshFilter   MeshFilter             = null;
		public MeshFilter   TransparentFilter      = null;
		public MeshFilter   OpaquePassableFilter   = null;

		Chunk _targetChunk   = null;

		public void Setup(Chunk targetChunk) {
			EventManager.Subscribe<Event_ChunkMeshUpdate>(this, OnChunkUpdate);
			_targetChunk = targetChunk;
			UpdateRenderer();
			gameObject.SetActive(true);
		}

		public override void DeInit() {
			EventManager.Unsubscribe<Event_ChunkMeshUpdate>(OnChunkUpdate);
			DeInitRenderer();
			_targetChunk = null;
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
			OpaquePassableFilter.mesh         = null;
		}

		void UpdateRenderer() {
			DeInitRenderer();
			MeshFilter.mesh           = _targetChunk.OpaqueCollidedMesh.Mesh;
			TransparentFilter.mesh    = _targetChunk.TranslucentPassableMesh.Mesh;
			OpaquePassableFilter.mesh = _targetChunk.OpaquePassableMesh.Mesh;
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
