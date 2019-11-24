using UnityEngine;

using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Networking;

using TMPro;

namespace Voxels.UI {
	public class ClientLoadingScreen : MonoBehaviour {

		const string CHUNK_COUNT_MESSAGE_FORMAT = "Loaded chunks: {0}";

		public TMP_Text   ChunkCountText = null;
		public GameObject LoadScreen     = null;

		int _loadedCount = 0;

		void Start() {
			LoadScreen.SetActive(true);
			EventManager.Subscribe<OnClientPlayerSpawn>(this, OnSpawnPlayer);
			EventManager.Subscribe<OnClientReceiveChunk>(this, OnReceiveChunk);
		}

		void OnDisable() {
			EventManager.Unsubscribe<OnClientPlayerSpawn>(OnSpawnPlayer);
			EventManager.Unsubscribe<OnClientReceiveChunk>(OnReceiveChunk);
		}

		void OnSpawnPlayer(OnClientPlayerSpawn e) {
			if ( !PlayerEntity.IsLocalPlayer(e.Player) ) {
				return;
			}
			LoadScreen.SetActive(false);
		}

		void OnReceiveChunk(OnClientReceiveChunk e) {
			_loadedCount++;
			ChunkCountText.text = string.Format(CHUNK_COUNT_MESSAGE_FORMAT, _loadedCount);
		}

	}
}

