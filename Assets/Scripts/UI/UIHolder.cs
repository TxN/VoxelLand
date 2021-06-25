using UnityEngine;

using Voxels.Networking.Clientside;

namespace Voxels.UI {
	public sealed class UIHolder : MonoBehaviour {
		public BlockPicker PickerWindow = null;

		void Update() {
			if ( Input.GetKeyDown(KeyCode.B) ) {
				if ( ClientInputManager.Instance.IsMovementEnabled  && !PickerWindow.IsShown ) {
					PickerWindow.ShowWindow();
				} else if ( PickerWindow.IsShown ) {
					PickerWindow.CloseWindow();
				}
			}
		}
	}
}
