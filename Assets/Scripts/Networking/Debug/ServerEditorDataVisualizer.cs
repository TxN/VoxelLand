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

		public SingleBlockPresenter Presenter = null;

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
			StartCoroutine(UpdateValues());
		}

		void OnDestroy() {
			StopAllCoroutines();
		}

#if UNITY_EDITOR
		void OnDrawGizmos() {
			var pc = ServerPlayerEntityManager.Instance;
			if ( pc == null ) {
				return;
			}
			foreach ( var player in pc.Players ) {
				Gizmos.DrawWireSphere(player.Position, 0.5f);
				Handles.Label(player.Position, player.PlayerName);
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
