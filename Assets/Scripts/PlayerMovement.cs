using UnityEngine;


using SMGCore.EventSys;
using Voxels.Networking;
using Voxels.Networking.Events;
using Voxels.Networking.Clientside;

namespace Voxels {
	public class PlayerMovement : MonoBehaviour {

		PlayerEntity _info            = null;
		bool         _isLocalAutority = false;

		public void Setup(PlayerEntity info) {
			EventManager.Subscribe<OnClientPlayerUpdate> (this, OnPosUpdate);
			EventManager.Subscribe<OnClientPlayerDespawn>(this, OnDespawn);

			//_isLocalAutority = ClientPlayerEntityManager.Instance.
		}

		public bool IsSamePlayer(PlayerEntity player) {
			if ( _info == null || player == null ) {
				return false;
			}
			return player.PlayerName == _info.PlayerName;
		}

		void OnDestroy() {
			EventManager.Unsubscribe<OnClientPlayerUpdate> (OnPosUpdate);
			EventManager.Unsubscribe<OnClientPlayerDespawn>(OnDespawn);
		}

		void OnDespawn(OnClientPlayerDespawn e) {
			Destroy(gameObject);
		}

		void OnPosUpdate(OnClientPlayerUpdate e) {
			if ( _isLocalAutority || !IsSamePlayer(e.Player) ) {
				return;
			}
			transform.position = e.Player.Position;
			var curRot = transform.rotation;
			transform.rotation = Quaternion.Euler(curRot.eulerAngles.x, e.Player.LookDir.y, curRot.eulerAngles.z);
		}
	}
}

