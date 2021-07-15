using UnityEngine;
using UnityEngine.SceneManagement;

using Voxels.Networking.Utils;

namespace Voxels.Utils {
	public sealed class HeadlessServerRunner : MonoBehaviour {
		void Start() {
			if ( !Application.isBatchMode ) {
				SceneManager.LoadScene("MainMenu");
				return;
			}
			Application.targetFrameRate = 60;
			NetworkOptions.ServerIP = "127.0.0.1";
			NetworkOptions.StartServer = true;
			SceneManager.LoadScene("NetworkGame");
		}
	}
}
