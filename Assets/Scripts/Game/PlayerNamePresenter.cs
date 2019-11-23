using UnityEngine;

using TMPro;

namespace Voxels.Game {
	public sealed class PlayerNamePresenter : MonoBehaviour {
		public TMP_Text       NameLabel = null;
		public PlayerMovement Owner     = null;

		void Start() {
			NameLabel.text = Owner.PlayerName;
		}
	}
}
