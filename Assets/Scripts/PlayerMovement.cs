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
		
		Vector3              _lastSentPos     = Vector3.zero;
		Vector2              _lastSentDir     = Vector2.zero;
		float                _lastUpdateTime  = 0f;

		float _lastReceivedHeadPitch = 0f;

        public PlayerInteraction Interactor { get; private set; }
		public SimpleVoxelMover  Mover      { get; private set; }

        public float HeadPitch {
			get {
				if ( HasAutority ) {
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

        public bool HasAutority { get; private set; } = false;

		public void Setup(PlayerEntity info) {
			EventManager.Subscribe<OnClientPlayerUpdate> (this, OnPosUpdate);
			EventManager.Subscribe<OnClientPlayerDespawn>(this, OnDespawn);
			_info = info;
			HasAutority = ClientPlayerEntityManager.Instance.IsLocalPlayer(info);
			_lastSentPos = info.Position;
			_lastSentDir = info.LookDir;
			_lastUpdateTime = Time.time;
			if ( !HasAutority ) {
				_interpolator = GetComponent<MovementInterpolator>();
			} else {
				_lastReceivedHeadPitch = info.LookDir.x;
				Interactor = GetComponentInChildren<PlayerInteraction>();
				Mover = GetComponent<SimpleVoxelMover>();
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
			if ( (!e.Flags.IsSet(PosUpdateOptions.Force) && HasAutority) || !IsSamePlayer(e.Player) ) {
				return;
			}
			if ( _interpolator == null ) {
				transform.position = e.Player.Position;
				return;
			}
			var rot = Quaternion.Euler(0, e.Player.LookDir.y, 0);
			_interpolator.UpdatePosition(e.Player.Position, rot, e.Flags.IsSet(PosUpdateOptions.Teleport));
			_lastReceivedHeadPitch = e.Player.LookDir.x;
		}
	}
}
