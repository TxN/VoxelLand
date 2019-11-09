using UnityEngine;

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
		/*	var player = GameManager.Instance.LocalPlayer;
			if ( !player ) {
				MainHolder.SetActive(false);
				return;
			}
			var selectedBlock = player.BlockInSight;
			MainHolder.SetActive(selectedBlock.IsEmpty() ? false : true);
			if ( selectedBlock.IsEmpty() || selectedBlock == _prevSelectedBlock ) {
				return;
			}


			BlockImagePresenter.ShowBlock(selectedBlock);
			BlockNameText.text  = selectedBlock.Type.ToString();
			LightLevelText.text = string.Format("Light level: {0}", selectedBlock.LightLevel);
			_prevSelectedBlock = selectedBlock;
			*/
		}
		
	}
}

