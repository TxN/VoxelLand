using UnityEngine;

using Voxels.Networking.Clientside;

namespace Voxels.Networking.NetDebug {
	public sealed class ClientEditorDataVisualizer : MonoBehaviour {
		void Start() {
			if ( !GameManager.Instance.IsClient ) {
				Destroy(gameObject);
				return;
			}
		}
		
		void Update() {
			if ( Input.GetKeyDown(KeyCode.T) ) {
				ClientPlayerEntityManager.Instance.IsPlayerControlEnabled = !ClientPlayerEntityManager.Instance.IsPlayerControlEnabled;
			}
		}
	}
}

