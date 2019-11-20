using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

using SMGCore.EventSys;
using Voxels.Networking;
using Voxels.Networking.Events;
using Voxels.Networking.Clientside;

namespace Voxels {
	public class PlayerMovement : MonoBehaviour {

		public Transform CameraTransform = null;

		PlayerEntity _info            = null;
		bool         _isLocalAutority = false;

		const float POS_UPDATE_DELAY = 0.1f;
		const float POS_MIN_DELTA    = 0.1f;
		const float ANG_MIN_DELTA    = 1f;


		float   _lastUpdateTime = 0f;
		Vector3 _lastSentPos    = Vector3.zero;
		Vector2 _lastSentDir    = Vector2.zero;

		public bool HasAutority {
			get {
				return _isLocalAutority;
			}
		}

		public void Setup(PlayerEntity info) {
			EventManager.Subscribe<OnClientPlayerUpdate> (this, OnPosUpdate);
			EventManager.Subscribe<OnClientPlayerDespawn>(this, OnDespawn);
			_info = info;
			_isLocalAutority = ClientPlayerEntityManager.Instance.IsLocalPlayer(info);
			_lastSentPos = info.Position;
			_lastSentDir = info.LookDir;
			_lastUpdateTime = Time.time;
			if ( !_isLocalAutority ) {
				Destroy(GetComponentInChildren<PostProcessLayer>());
				Destroy(GetComponentInChildren<Camera>());
				Destroy(GetComponentInChildren<AudioListener>());
			}
		}

		public bool IsSamePlayer(PlayerEntity player) {
			if ( _info == null || player == null ) {
				return false;
			}
			return player.PlayerName == _info.PlayerName;
		}

		void Update() {
			if ( HasAutority ) {
				TrySendPosUpdate();
			}
		}

		void OnDestroy() {
			EventManager.Unsubscribe<OnClientPlayerUpdate> (OnPosUpdate);
			EventManager.Unsubscribe<OnClientPlayerDespawn>(OnDespawn);
		}

		void TrySendPosUpdate() {
			if ( Time.time < _lastUpdateTime + POS_UPDATE_DELAY ) {
				return;
			}
			var moveDelta = transform.position - _lastSentPos;
			// TODO: look delta calculation
			//var lookDelta = 
			if ( moveDelta.magnitude < POS_MIN_DELTA ) {
				return;
			}
			_lastSentPos = transform.position;
			//_lastSentDir = new Vector2(;
			_lastUpdateTime = Time.time;

			_info.Position = _lastSentPos;
			_info.LookDir  = _lastSentDir;
			ClientPlayerEntityManager.Instance.SendUpdateToServer(_info);
		}

		void OnDespawn(OnClientPlayerDespawn e) {
			if ( !IsSamePlayer(e.Player) ) {
				return;
			}
			Destroy(gameObject);
		}

		void OnPosUpdate(OnClientPlayerUpdate e) {
			if ( HasAutority || !IsSamePlayer(e.Player) ) {
				return;
			}
			transform.position = e.Player.Position;
			var curRot = transform.rotation;
			transform.rotation = Quaternion.Euler(curRot.eulerAngles.x, e.Player.LookDir.y, curRot.eulerAngles.z);
		}
	}
}

