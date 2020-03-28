using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Voxels.Networking.Utils;

using TMPro;

namespace Voxels.UI {
	public sealed class MainMenu : MonoBehaviour {
		public Button         StartServerButton = null;
		public Button         JoinGameButton    = null;
		public Button         LocalGameButton   = null;
		public Button         QuitButton        = null;
		public TMP_InputField IpInput           = null;
		public TMP_InputField NameInput         = null;
		public TMP_InputField PasswordInput     = null;
		public GameObject     LoadingScreen     = null;

		void Start() {
			LoadingScreen.SetActive(false);
			StartServerButton.onClick.AddListener(StartServer);
			JoinGameButton.onClick.AddListener(JoinGame);
			LocalGameButton.onClick.AddListener(LocalGame);
			QuitButton.onClick.AddListener(QuitGame);

			if ( Application.isBatchMode ) {
				Application.targetFrameRate = 120;
				StartServer();
			} else {
#if UNITY_EDITOR
				QualitySettings.vSyncCount = 0;
				Application.targetFrameRate = 60;
#endif
			}
		}

		void StartServer() {
			StartGame(false, true);
		}

		void JoinGame() {
			StartGame(true, false);
		}

		void LocalGame() {
			IpInput.text = NetworkOptions.Localhost;
			StartGame(true, true);
		}

		void QuitGame() {
			Application.Quit();
		}

		void StartGame(bool isClient, bool isServer) {
			if ( !string.IsNullOrEmpty(IpInput.text) ) {
				NetworkOptions.ServerIP = IpInput.text;
			}
			if ( !string.IsNullOrEmpty(NameInput.text) ) {
				NetworkOptions.PlayerName = NameInput.text;
			}
			if ( !string.IsNullOrEmpty(PasswordInput.text) ) {
				NetworkOptions.Password = PasswordInput.text;
			}
			NetworkOptions.StartClient = isClient;
			NetworkOptions.StartServer = isServer;
			LoadingScreen.SetActive(true);
			SceneManager.LoadScene("NetworkGame");
		}
	}
}

