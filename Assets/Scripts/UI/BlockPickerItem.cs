using System;

using UnityEngine;
using UnityEngine.UI;

namespace Voxels.UI {
	public class BlockPickerItem : MonoBehaviour {
		public Block2DPresenter Presenter = null;

		Action<BlockData> _onPicked = null;
		BlockData         _block    = default;

		public void Setup(BlockData block, Action<BlockData> onPickAction) {
			_onPicked = onPickAction;
			_block = block;
			Presenter.ShowBlock(block);
			var btn = GetComponent<Button>();
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(OnBlockPicked);
		}

		void OnBlockPicked() {
			_onPicked?.Invoke(_block);
		}
	}
}

