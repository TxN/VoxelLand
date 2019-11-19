using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

using Voxels.Networking.Serverside;

namespace Voxels.Networking.NetDebug {
	public sealed class ServerEditorDataVisualizer : MonoBehaviour {

		public long ReceivedCommands = 0;
		public long SentCommands = 0;
		public List<ClientState> Clients = null;

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
				Handles.Label(player.Position, player.PlayerName);
			}
		}
#endif

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
