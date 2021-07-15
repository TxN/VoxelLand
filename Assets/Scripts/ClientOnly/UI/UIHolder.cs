using UnityEngine;

using Voxels.Networking.Clientside;

namespace Voxels.UI {
	public sealed class UIHolder : MonoBehaviour {
		public BlockPicker PickerWindow  = null;
		public ColorPicker PaletteWindow = null;

		void Update() {
			if ( Input.GetKeyDown(KeyCode.B) ) {
				if ( ClientInputManager.Instance.IsMovementEnabled  && !PickerWindow.IsShown ) {
					PickerWindow.ShowWindow();
				} else if ( PickerWindow.IsShown ) {
					PickerWindow.CloseWindow();
				}
			}
			if ( Input.GetKeyDown(KeyCode.P) ) {
				if ( ClientInputManager.Instance.IsMovementEnabled && !PaletteWindow.IsShown ) {
					PaletteWindow.ShowWindow();
				}
				else if ( PaletteWindow.IsShown ) {
					PaletteWindow.CloseWindow();
				}
			}
		}
	}
}
