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
			var library = StaticResources.BlocksInfo;
			
			foreach ( var block in library.BlockDescriptions ) {
				byte subtype = 0;
				foreach ( var s in block.Subtypes ) {
					var inst = Instantiate(ItemFab, Layout);
					inst.Setup(new BlockData(block.Type, subtype), OnBlockPicked);
					inst.gameObject.SetActive(true);
					subtype++;
				}
				
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
