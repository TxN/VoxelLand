#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

using Voxels.Networking.Clientside;

namespace Voxels.Networking.NetDebug {
	public sealed class ClientEditorDataVisualizer : MonoBehaviour {

		public bool ShowPlayerRaycast = false;

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
			ShowRaycast();
		}

		void ShowRaycast() {
			if ( !ShowPlayerRaycast ) {
				return;
			}
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
			var rawPos = view.Interactor.CurrentOutPos;
			var floorPos = new Vector3(Mathf.Floor(rawPos.x), Mathf.Floor(rawPos.y), Mathf.Floor(rawPos.z)) + new Vector3(0.5f, 0.5f, 0.5f);
			Gizmos.DrawWireCube(floorPos, Vector3.one);
			Gizmos.color = Color.cyan;

			Gizmos.DrawRay(view.Interactor.transform.position, view.Interactor.ViewDirection * 15f);
			var result = VoxelsUtils.Cast(view.Interactor.transform.position, view.Interactor.ViewDirection, 15, (pos) => {
				var p = pos.ToVector3 + new Vector3(0.5f, 0.5f, 0.5f);
				Gizmos.DrawWireCube(p, Vector3.one);
				return !ClientChunkManager.Instance.GetBlockIn(pos.X, pos.Y, pos.Z).IsEmpty();
			}, out var hit);
			if ( !result ) {
				return;
			}
			Gizmos.color = Color.yellow;
			var voxelPos = new Vector3(Mathf.Floor(hit.HitPosition.x), Mathf.Floor(hit.HitPosition.y), Mathf.Floor(hit.HitPosition.z));
			var outPos = hit.Normal * 0.5f + voxelPos;
			Gizmos.DrawWireCube(new Vector3(Mathf.Floor(outPos.x), Mathf.Floor(outPos.y), Mathf.Floor(outPos.z)) + new Vector3(0.5f, 0.5f, 0.5f), Vector3.one);
			Gizmos.DrawWireSphere(hit.HitPosition, 0.2f);
			Gizmos.DrawRay(hit.HitPosition, hit.Normal * 0.5f);
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

