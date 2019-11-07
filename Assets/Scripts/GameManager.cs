using UnityEngine;

using Voxels.UI;
using SMGCore;

using ZeroFormatter;

namespace Voxels {
	public sealed class GameManager : MonoSingleton<GameManager> {
		public PlayerInteraction LocalPlayer = null;
		public Hotbar            Hotbar      = null;

		const string   PlayerPrefabPath = "Player";
		public Vector3 SpawnPos = new Vector3(0, 60, 0);

		public SaveLoadManager SaveLoad = null;

		public bool PlayerControlEnabled {
			get {
				return true;
			}
		}

		void Start() {
			ZeroFormatterInitializer.Register();
			SaveLoad = new SaveLoadManager();
			SaveLoad.Load();
			SpawnPlayer();
		}

		void Update() {
			if (Input.GetKeyDown(KeyCode.U)) {
				SaveLoad.Save();
			}
		}

		void SpawnPlayer() {
			var ply = Resources.Load<GameObject>(PlayerPrefabPath);
			LocalPlayer = Instantiate(ply, SpawnPos, Quaternion.identity, null).GetComponent<PlayerInteraction>();
		}
	}
}

