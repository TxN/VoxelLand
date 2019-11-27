using System.Collections.Generic;

using UnityEngine;

namespace Voxels.Networking.Clientside {
	public sealed class MovementInterpolator : MonoBehaviour {
		public int   UpdateRate        = 10;
		public float SnapDistance      = 0.15f;
		public float TeleportThreshold = 3f;

		float _moveTime       = 0.1f;
		float _interpProgress = 0f;

		Vector3 _prevPos = Vector3.zero;
		Vector3 _lastPos = Vector3.zero;

		Quaternion _prevRot = Quaternion.identity;
		Quaternion _lastRot = Quaternion.identity;

		Vector3 _prevFramePos = Vector3.zero;

		public float HMoveSpeed {
			get {
				var dot = Vector3.Dot(transform.forward, transform.position - _prevFramePos);
				var v1  = new Vector2(_prevFramePos.x, _prevFramePos.z);
				var v2  = new Vector2(transform.position.x, transform.position.z);
				return Vector2.Distance(v1, v2) * UpdateRate * Mathf.Sign(dot);
			}
		}

		public void UpdatePosition(Vector3 newPos, Quaternion newRot, bool teleport) {

			_prevRot = _lastRot;
			_lastRot = newRot;

			if ( Vector3.Distance(newPos, _lastPos) > TeleportThreshold || teleport ) {
				_prevPos = _lastPos;
				_lastPos = newPos;
				_interpProgress = 1.1f;
				transform.position = newPos;
				return;
			}

			_prevPos = _lastPos;
			_lastPos = newPos;
			_interpProgress = 0f;
		}


		void Start() {
			_prevPos = transform.position;
			_lastPos = transform.position;

			_prevRot = transform.rotation;
			_lastRot = transform.rotation;

			_moveTime = 1 / (float) UpdateRate;
			_interpProgress = 1.1f;
			_prevFramePos = transform.position;
		}

		void Update() {
			if ( _interpProgress > 1f) {
				return;
			}
			_interpProgress += Time.deltaTime / _moveTime;
			transform.position = Vector3.Lerp(_prevPos, _lastPos, _interpProgress);
			transform.rotation = Quaternion.Lerp(_prevRot, _lastRot, _interpProgress);
		}

		void LateUpdate() {
			_prevFramePos = transform.position;
		}
	}
}

