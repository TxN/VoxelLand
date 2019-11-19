using UnityEngine;

using Voxels.Networking.Clientside;

namespace Voxels {
	public sealed class CameraVerticalLook : MonoBehaviour {
		public float Sensivity = 2;
		public Vector2 Limits = new Vector2(-85, 85);

		PlayerMovement _main = null;
		Vector3 _rotation = Vector3.zero;

		void Start() {
			_main = transform.parent.GetComponent<PlayerMovement>();
		}

		void Update() {
			if ( _main.HasAutority && ClientPlayerEntityManager.Instance.IsPlayerControlEnabled ) {
				_rotation.x -= Input.GetAxis("Mouse Y") * Sensivity;
				_rotation.x = Mathf.Clamp(_rotation.x, Limits.x, Limits.y);
				transform.localEulerAngles = _rotation;
				Cursor.lockState = CursorLockMode.Locked;
			} else if ( _main.HasAutority ) {
				Cursor.lockState = CursorLockMode.None;
			}
		}

		public float LookSin() {
			return Mathf.Sin(-_rotation.x * Mathf.Deg2Rad);
		}
	}
}
