using UnityEngine;

namespace Voxels.UI {
	public class MobileInput : MonoBehaviour {

		public bool ForwardPressed {
			get; private set;
		}

		public bool BackwardPressed {
			get; private set;
		}

		public bool JumpPressed {
			get; private set;
		}

		public void OnForwardButton(bool pressed) {
			ForwardPressed = pressed;
		}

		public void OnBackwardButton(bool pressed) {
			ForwardPressed = pressed;
		}

		public void OnJumpButton(bool pressed) {
			ForwardPressed = pressed;
		}
	}
}
