using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Voxels.Events;
using Voxels.Networking.Clientside;
using SMGCore.EventSys;

namespace Voxels.UI {
	public sealed class ColorPicker : MonoBehaviour {
		public GameObject    ItemFab      = null;
		public RectTransform Layout       = null;
		public Button        Background   = null;
		public Image         CurrentColor = null;
		public List<Color32> Colors     = new List<Color32>();

		bool _isSetup = false;

		public bool IsShown => gameObject.activeInHierarchy;

		void Start() {
			if ( !_isSetup ) {
				Setup();
			}
		}

		public void ShowWindow() {
			if ( !_isSetup ) {
				Setup();
			}
			gameObject.SetActive(true);
			ClientInputManager.Instance.AddControlLock(this);
		}

		public void CloseWindow() {
			gameObject.SetActive(false);
			ClientInputManager.Instance.RemoveControlLock(this);
		}

		void Setup() {
			ItemFab.gameObject.SetActive(false);
			var library = VoxelsStatic.Instance.Library;

			foreach ( var color in Colors ) {
				var inst = Instantiate(ItemFab, Layout);
				inst.GetComponent<Button>().onClick.AddListener(() => { SetColor(color); });
				inst.GetComponent<Image>().color = color;
				inst.gameObject.SetActive(true);
			}

			Background.onClick.RemoveAllListeners();
			Background.onClick.AddListener(CloseWindow);
			_isSetup = true;
		}

		void SetColor(Color32 col) {
			EventManager.Fire(new Event_ColorPicked() { Color = col });
			CurrentColor.color = col;
		}
	}

	
}
