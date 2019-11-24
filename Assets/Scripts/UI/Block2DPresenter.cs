using UnityEngine;
using UnityEngine.UI;

using SMGCore.EventSys;
using Voxels.Events;

namespace Voxels {
	[RequireComponent(typeof(RawImage))]
	public sealed class Block2DPresenter : MonoBehaviour {

		RawImage  _image      = null;
		BlockData _shownBlock = BlockData.Empty;

		void Awake() {
			_image = GetComponent<RawImage>();
			EventManager.Subscribe<Event_BlockPreviewUpdated>(this, OnBlockPreviewUpdated);
		}

		void OnDestroy() {
			EventManager.Unsubscribe<Event_BlockPreviewUpdated>(OnBlockPreviewUpdated);
		}

		public void ShowBlock(BlockData block) {
			_shownBlock = block;

			var preview = VoxelsStatic.Instance.Library.GetBlockPreview(block);
			if ( preview == null ) {
				_image.enabled = false;
				return;
			}
			_image.texture = preview;
			_image.enabled = true;
		}

		void OnBlockPreviewUpdated(Event_BlockPreviewUpdated e) {
			if ( e.Block.Type != _shownBlock.Type || e.Block.Subtype != _shownBlock.Subtype ) {
				return;
			}
			_image.texture = e.Texture;
			_image.enabled = true;
		}
	}
}
