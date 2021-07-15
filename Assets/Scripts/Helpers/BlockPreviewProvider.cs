using System.Collections.Generic;

using Voxels.Events;
using SMGCore.EventSys;

using UnityEngine;

namespace Voxels.Game {
	public sealed class BlockPreviewProvider {
		BlockPreviewGenerator      _generator     = null;
		Dictionary<int, Texture2D> _blockPreviews = new Dictionary<int, Texture2D>();

		public BlockPreviewProvider(BlockPreviewGenerator generator) {
			_generator = generator;
			EventManager.Subscribe<Event_BlockPreviewUpdated>(this, OnPreviewUpdated);
		}

		public void DeInit() {
			EventManager.Unsubscribe<Event_BlockPreviewUpdated>(OnPreviewUpdated);
		}

		public Texture2D GetBlockPreview(BlockData block) {
			var hash = (byte)block.Type * 256 + block.Subtype;
			if ( _blockPreviews.ContainsKey(hash) ) {
				return _blockPreviews[hash];
			}
			_generator.RenderBlockPreview(block);
			return null;
		}

		void OnPreviewUpdated(Event_BlockPreviewUpdated e) {
			var hash = (byte)e.Block.Type * 256 + e.Block.Subtype;
			if ( _blockPreviews.ContainsKey(hash) ) {
				_blockPreviews[hash] = e.Texture;
			} else {
				_blockPreviews.Add(hash, e.Texture);
			}
		}
	}
}
