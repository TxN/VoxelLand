using UnityEngine;

using Voxels.Networking.Clientside;

using TMPro;

namespace Voxels.UI {
	public sealed class Waila : MonoBehaviour {
		public GameObject MainHolder = null;
		public TMP_Text BlockNameText = null;
		public TMP_Text LightLevelText = null;
		public Block2DPresenter BlockImagePresenter = null;

		BlockData _prevSelectedBlock = BlockData.Empty;

		void Start() {
			
		}

		void Update() {
			var player = ClientPlayerEntityManager.Instance.LocalPlayer;
			if ( player == null ) {
				return;
			}
			var playerView = player.View;
			if ( !playerView ) {
				MainHolder.SetActive(false);
				return;
			}
			var selectedBlock = playerView.Interactor.BlockInSight;
			var normalBlock   = playerView.Interactor.BlockOutSight;
			MainHolder.SetActive(selectedBlock.IsEmpty() ? false : true);
			if ( selectedBlock.IsEmpty() || selectedBlock == _prevSelectedBlock ) {
				return;
			}

			BlockImagePresenter.ShowBlock(selectedBlock);
			BlockNameText.text  = selectedBlock.Type.ToString();
			LightLevelText.text = string.Format("Light level: {0}", normalBlock.LightLevel);
			_prevSelectedBlock = selectedBlock;
			
		}
		
	}
}

