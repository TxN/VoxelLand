using UnityEngine;

using SMGCore.EventSys;
using Voxels.Networking;
using Voxels.Networking.Events;
using Voxels.Networking.Clientside;

namespace Voxels {
	public class PlayerMovement : MonoBehaviour {

		public Transform CameraTransform = null;

		const float POS_UPDATE_DELAY = 0.1f;
		const float POS_MIN_DELTA    = 0.1f;
		const float ANG_MIN_DELTA    = 1f;

		PlayerEntity         _info            = null;
		MovementInterpolator _interpolator    = null;
		bool                 _isLocalAutority = false;
		float                _lastUpdateTime  = 0f;
		Vector3              _lastSentPos     = Vector3.zero;
		Vector2              _lastSentDir     = Vector2.zero;

		float _lastReceivedHeadPitch = 0f;

		PlayerInteraction _interactor;

		public PlayerInteraction Interactor {
			get {
				return _interactor;
			}
		}

		public float HeadPitch {
			get {
				if ( _isLocalAutority ) {
					return CameraTransform.rotation.eulerAngles.x;
				}
				return _lastReceivedHeadPitch;
			}
		}

		public string PlayerName {
			get {
				return _info.PlayerName;
			}
		}

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
				_interpolator = GetComponent<MovementInterpolator>();
			} else {
				_lastReceivedHeadPitch = info.LookDir.x;
				_interactor = GetComponentInChildren<PlayerInteraction>();
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

			var yaw = transform.rotation.eulerAngles.y;
			var currentLook = new Vector2(HeadPitch, yaw);

			var lookDelta = Vector2.Distance(_lastSentDir, currentLook);
			if ( moveDelta.magnitude < POS_MIN_DELTA && lookDelta < ANG_MIN_DELTA ) {
				return;
			}
			_lastSentPos = transform.position;

			_lastSentDir = currentLook;
			_lastUpdateTime = Time.time;
			ClientPlayerEntityManager.Instance.SendPosUpdateToServer(_info, _lastSentPos, yaw, HeadPitch);
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
			if ( _interpolator == null ) {
				return;
			}
			var rot = Quaternion.Euler(0, e.Player.LookDir.y, 0);
			_interpolator.UpdatePosition(e.Player.Position, rot);
			_lastReceivedHeadPitch = e.Player.LookDir.x;
		}
	}
}

