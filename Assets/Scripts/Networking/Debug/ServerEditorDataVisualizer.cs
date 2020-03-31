using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

using Voxels.Networking.Serverside;

using NaughtyAttributes;

namespace Voxels.Networking.NetDebug {
	public sealed class ServerEditorDataVisualizer : MonoBehaviour {
		[Header("Options")]
		public bool DrawChunkInfo = true;

		public SingleBlockPresenter Presenter = null;
		[Header("Data")]
		public long              ReceivedCommands = 0;
		public long              SentCommands     = 0;
		public List<ClientState> Clients          = null;
		[Header("Block preview")]
		public Vector3           BlockPos         = Vector3.zero;

		void Start() {
			if ( !GameManager.Instance.IsServer ) {
				Destroy(gameObject);
				return;
			}
#if UNITY_EDITOR
			StartCoroutine(UpdateValues());
#endif
		}

		void OnDestroy() {
			StopAllCoroutines();
		}

#if UNITY_EDITOR
		void OnDrawGizmos() {
			if ( !Application.isPlaying ) {
				return;
			}
			var ex = ServerDynamicEntityController.Instance;

			foreach ( var e in ex.AllEntities ) {
				Gizmos.DrawWireSphere(e.Mover.Position, 0.5f);
			}

			var pc = ServerPlayerEntityManager.Instance;
			if ( pc == null ) {
				return;
			}
			foreach ( var player in pc.Players ) {
				Gizmos.DrawWireSphere(player.Position, 0.5f);
				Handles.Label(player.Position, player.PlayerName);
			}
			if ( DrawChunkInfo ) {
				var cm = ServerChunkManager.Instance;
				var data = cm.DebugData;
				foreach ( var item in data.Chunks ) {
					var index = item.Key;
					var centerPos = new Vector3(index.X*16 + 8, Chunk.CHUNK_SIZE_Y * 0.5f, index.Z*16 + 8);
					if ( !data.UsedChunks.ContainsKey(index) && !data.UselessChunks.ContainsKey(index) ) {
						Gizmos.DrawWireCube(centerPos, new Vector3(16, 128, 16));
					}					
				}
				Gizmos.color = Color.red;
				foreach ( var item in data.UselessChunks ) {
					var index = item.Key;
					var centerPos = new Vector3(index.X * 16 + 8, Chunk.CHUNK_SIZE_Y * 0.5f, index.Z * 16 + 8);
					Gizmos.DrawWireCube(centerPos, new Vector3(16, 128, 16));
				}
				Gizmos.color = Color.green;
				foreach ( var item in data.UsedChunks ) {
					var index = item.Key;
					var centerPos = new Vector3(index.X * 16 + 8, Chunk.CHUNK_SIZE_Y * 0.5f, index.Z * 16 + 8);
					Gizmos.DrawWireCube(centerPos, new Vector3(16, 128, 16));
				}
			}
		}
#endif

		[Button]
		void DrawBlock() {
			var block = ServerChunkManager.Instance.GetBlockIn(BlockPos);
			Presenter.gameObject.SetActive(!block.IsEmpty());
			Presenter.transform.position = BlockPos;
			Presenter.DrawBlock(block);
		}

		[Button]
		void SpawnTestEntity() {
			var ex = ServerDynamicEntityController.Instance;
			ex.SpawnEntity<TestEntityServerside>(new Vector3(0, 50, 0), Random.rotation);
		}

		IEnumerator UpdateValues() {
		//	yield return new WaitForSeconds(0.5f);
			var server = ServerController.Instance;
			while (true) {
				ReceivedCommands = server.PacketsReceived;
				SentCommands = server.PacketsSent;
				Clients = server.Clients.Values.ToList();

				yield return new WaitForSeconds(0.5f);
			}
		}
	}
}
