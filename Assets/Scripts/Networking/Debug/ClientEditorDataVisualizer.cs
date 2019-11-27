#if UNITY_EDITOR
using UnityEditor;
#endif

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

#if UNITY_EDITOR
		void OnDrawGizmos() {
			var pc = ClientPlayerEntityManager.Instance;
			if ( pc == null ) {
				return;
			}
			var localPlayer = pc.LocalPlayer;
			if ( localPlayer == null ) {
				return;
			}
			var view = localPlayer.View;
			if ( view == null ) {
				return;
			}
			var rawPos   = view.Interactor.CurrentOutPos;
			var floorPos = new Vector3(Mathf.Floor(rawPos.x), Mathf.Floor(rawPos.y), Mathf.Floor(rawPos.z)) + new Vector3(0.5f, 0.5f, 0.5f);
			Gizmos.DrawWireCube(floorPos, Vector3.one);
		}
#endif


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

