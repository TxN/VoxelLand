using UnityEngine;

using Voxels;

public sealed class CameraVerticalLook : MonoBehaviour {
	public float   Sensivity = 2;
	public Vector2 Limits    = new Vector2(-85, 85);

	Vector3 _rotation = Vector3.zero;

	
	void Update() {
	//	if ( GameManager.Instance.PlayerControlEnabled ) {
		if ( true ) {
			_rotation.x -= Input.GetAxis("Mouse Y") * Sensivity;
			_rotation.x = Mathf.Clamp(_rotation.x, Limits.x, Limits.y);
			transform.localEulerAngles = _rotation ;
			Cursor.lockState = CursorLockMode.Locked;
		} else {
			Cursor.lockState = CursorLockMode.None;
		}
	}

	public float LookSin() {
		return Mathf.Sin(-_rotation.x * Mathf.Deg2Rad);
	}
}
