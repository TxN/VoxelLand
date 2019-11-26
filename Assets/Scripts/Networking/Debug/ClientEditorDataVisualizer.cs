using UnityEngine;

using Voxels.Networking.Clientside;

namespace Voxels.Networking.NetDebug {
	public sealed class ClientEditorDataVisualizer : MonoBehaviour {

		bool _showGUI = true;

		void Start() {
			if ( !GameManager.Instance.IsClient ) {
				Destroy(gameObject);
				return;
			}
		}
		
		void Update() {
			if ( Input.GetKeyDown(KeyCode.F1) ) {
				ClientInputManager.Instance.AddOrRemoveControlLock(this);
			}
			if ( Input.GetKeyDown(KeyCode.Y) ) {
				_showGUI = !_showGUI;
			}
		}

		void OnGUI() {
			if ( !_showGUI || !GameManager.Instance.IsClient ) {
				return;
			}

			var cc = ClientController.Instance;

			if ( cc == null ) {
				return;
			}

			GUI.Label(new Rect(10, 10, 150, 20), string.Format("Player name: {0}", cc.ClientName));
		}
	}
}

