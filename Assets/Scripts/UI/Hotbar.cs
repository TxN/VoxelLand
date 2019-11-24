using System.Collections.Generic;

using UnityEngine;

namespace Voxels.UI {
	public sealed class Hotbar : MonoBehaviour {
		public List<BlockType>        SlotsContent      = new List<BlockType>();
		public List<Block2DPresenter> Slots             = new List<Block2DPresenter>();
		public RectTransform          SelectedSlotFrame = null;
		public Vector2                FirstSlotPos      = Vector2.zero;
		public float                  SlotSizePixels    = 0;

		int _curSlot = 0;

		public BlockType SelectedBlock {
			get {
				return SlotsContent[_curSlot];
			}
		}

		void Start() {
			for ( int i = 0; i < 9; i++ ) {
				Slots[i].ShowBlock(new BlockData(SlotsContent[i],0));
			}
			
		}

		void Update() {
			var scroll = Input.GetAxis("Mouse ScrollWheel");
			if ( scroll < 0 ) {
				_curSlot++;
				if ( _curSlot > 8 ) {
					_curSlot = 0;
				}
				SelectedSlotFrame.anchoredPosition = FirstSlotPos + new Vector2(SlotSizePixels * _curSlot, 0);
			} else if ( scroll > 0 ) {
				_curSlot--;
				if ( _curSlot < 0 ) {
					_curSlot = 8;
				}
				SelectedSlotFrame.anchoredPosition = FirstSlotPos + new Vector2(SlotSizePixels * _curSlot, 0);
			}

			for ( int i = 0; i < 9; i++ ) {
				if ( Input.GetKeyDown((KeyCode) 49 + i) ) {
					_curSlot = i;
					SelectedSlotFrame.anchoredPosition = FirstSlotPos + new Vector2(SlotSizePixels * _curSlot, 0);
				}
			}	
		}
	}
}

