using UnityEngine;
using UnityEngine.UI;

using Voxels.Networking.Clientside;

namespace Voxels.UI {
	public sealed class BlockPicker : MonoBehaviour {
		public Hotbar          Hotbar     = null;
		public BlockPickerItem ItemFab    = null;
		public RectTransform   Layout     = null;
		public Button          Background = null;

		bool _isSetup = false;

		public bool IsShown => gameObject.activeInHierarchy;

		void Start() {
			if ( _isSetup ) {
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
			foreach ( var block in library.BlockDescriptions ) {
				var inst = Instantiate(ItemFab, Layout);
				inst.Setup(new BlockData(block.Type), OnBlockPicked);
				inst.gameObject.SetActive(true);
			}

			Background.onClick.RemoveAllListeners();
			Background.onClick.AddListener(CloseWindow);
			_isSetup = true;
		}

		void OnBlockPicked(BlockData block) {
			Hotbar.SetBlockInSelectedSlot(block);
		}

		
	}

}
