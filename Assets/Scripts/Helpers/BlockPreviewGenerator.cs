using System.Collections.Generic;

using UnityEngine;

using SMGCore.EventSys;
using Voxels.Events;

namespace Voxels {
	[RequireComponent(typeof(Camera))]
	public sealed class BlockPreviewGenerator : MonoBehaviour {

		Camera               _camera         = null;
		SingleBlockPresenter _blockPresenter = null;

		RenderTexture _rt = null;
		Queue<BlockData> _blockPreviewQueue = new Queue<BlockData>();

		const int PREVIEW_WIDTH   = 128;
		const int PREVIEW_HEIGHT = 128;

		void Awake() {
			_camera = GetComponent<Camera>();
			_blockPresenter = GetComponentInChildren<SingleBlockPresenter>();
			_camera.enabled = false;
			_blockPresenter.Init();
			_rt = new RenderTexture(PREVIEW_WIDTH, PREVIEW_HEIGHT, 32);
			_camera.targetTexture = _rt;
		}

		private void Update() {
		
		}

		void LateUpdate() {
			if ( _blockPreviewQueue.Count > 0 ) {
				_blockPresenter.gameObject.SetActive(true);
				var curBlock = _blockPreviewQueue.Dequeue();
				_blockPresenter.DrawBlock(curBlock);
				_camera.enabled = true;
				var snapshot = new Texture2D(PREVIEW_WIDTH, PREVIEW_HEIGHT, TextureFormat.RGBA32, false);
				_camera.Render();
				RenderTexture.active = _camera.targetTexture;
				snapshot.ReadPixels(new Rect(0, 0, PREVIEW_WIDTH, PREVIEW_HEIGHT), 0, 0);
				snapshot.Apply();
				EventManager.Fire(new Event_BlockPreviewUpdated() { Block = curBlock, Texture = snapshot });
				_blockPresenter.gameObject.SetActive(false);
				_camera.enabled = false;
			}
		}

		void OnDestroy() {
			if ( _rt != null ) {
				Destroy(_rt);
			}
		}

		public void RenderBlockPreview(BlockData block) {
			_blockPreviewQueue.Enqueue(block);
		}
	}
}

