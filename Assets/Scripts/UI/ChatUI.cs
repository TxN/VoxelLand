using System.Text;

using UnityEngine;
using UnityEngine.UI;

using SMGCore.EventSys;
using Voxels.Networking.Clientside;
using Voxels.Networking.Events;

using TMPro;

namespace Voxels.UI {
	public sealed class ChatUI : MonoBehaviour {
		const int SMALL_BOX_CAPACITY = 5;
		const int BIG_BOX_CAPACITY   = 30;

		public TMP_InputField InputLine = null;
		public GameObject     SmallChat = null;
		public GameObject     BigChat   = null;

		public TMP_Text SmallChatText = null;
		public TMP_Text BigChatText   = null;

		public bool ChatOpened { get; private set; }

		void Start() {
			InputLine.onSubmit.AddListener(OnChatSubmit);
			EventManager.Subscribe<OnClientReceivedChatMessage>(this, OnChatMessage);
			SwitchChat(false);
		}

		void Update() {
			if ( !ChatOpened && Input.GetKeyDown(KeyCode.Slash) ) {
				SwitchChat(!ChatOpened);
			} else if (ChatOpened && Input.GetKeyDown(KeyCode.Escape) ) {
				SwitchChat(!ChatOpened);
			}
			
		}

		void OnDestroy() {
			EventManager.Unsubscribe<OnClientReceivedChatMessage>(OnChatMessage);
		}

		void SwitchChat(bool open) {
			SmallChat.SetActive(!open);
			BigChat.SetActive(open);

			if ( open ) {
				UpdateBigView();
			} else {
				UpdateSmallView();
			}
			if ( open ) {
				InputLine.Select();
				InputLine.ActivateInputField();
			}
			ChatOpened = open;
		}

		void UpdateSmallView() {
			var messages   = ClientChatManager.Instance.Messages;
			var minMessage = Mathf.Clamp(messages.Count - SMALL_BOX_CAPACITY, 0, messages.Count);
			var text = new StringBuilder();
			for ( int i = minMessage; i < messages.Count; i++ ) {
				text.AppendLine(messages[i].ToChatString());
			}
			SmallChatText.text = text.ToString();
		}

		void UpdateBigView() {
			var messages = ClientChatManager.Instance.Messages;
			var minMessage = Mathf.Clamp(messages.Count - BIG_BOX_CAPACITY, 0, messages.Count);
			var text = new StringBuilder();
			for ( int i = minMessage; i < messages.Count; i++ ) {
				text.AppendLine(messages[i].ToChatString());
			}
			BigChatText.text = text.ToString();
		}

		void OnChatSubmit(string text) {
			InputLine.text = string.Empty;
			ClientChatManager.Instance.SendMessage(text);
			SwitchChat(false);
		}

		void OnChatMessage(OnClientReceivedChatMessage e) {
			if ( ChatOpened ) {
				UpdateBigView();
			} else {
				UpdateSmallView();
			}
		}
	}

}
