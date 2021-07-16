using System.Collections;

using UnityEngine;

using SMGCore;

namespace Voxels {
	public class DestroyBlockEffect : PoolItem {
		ParticleSystem         _pSystem       = null;
		ParticleSystemRenderer _pRenderer     = null;
		Material               _instanceMat   = null;
		DestroyBlockEffectPool _owner         = null;
		VoxelLightingReceiver  _lightDetector = null;

		bool _inited = false;

		public void PlayEffect(BlockData data, DestroyBlockEffectPool owner) {
			if ( !_inited ) {
				Init();
			}
			gameObject.SetActive(true);
			var desc = VoxelsStatic.Instance.Library.GetBlockDescription(data.Type);
			if ( desc.Subtypes.Count == 0 ) {
				Return();
				return;
			}
			var tile = desc.Subtypes[data.Subtype].FaceTiles[0];
			_instanceMat.SetInt  ("_tilePosX", tile.X);
			_instanceMat.SetInt  ("_tilePosY", tile.Y);
			StartCoroutine(Show());
		}

		public override void DeInit() {
			_pSystem.Stop();
			gameObject.SetActive(false);
		}

		void Init() {
			_pSystem            = GetComponent<ParticleSystem>();
			_pRenderer          = GetComponent<ParticleSystemRenderer>();
			_lightDetector      = GetComponent<VoxelLightingReceiver>();
			_instanceMat        = new Material(_pRenderer.material);
			_pRenderer.material = _instanceMat;
			_inited             = true;
		}

		IEnumerator Show() {
			yield return new WaitForSeconds(0.06f);
			_instanceMat.SetFloat("_lightLevel", _lightDetector.GetLightLevel() / 255f);
			_pSystem.Play();
			StartCoroutine(ReturnToPool());

		}

		void Return() {
			if ( _owner != null ) {
				_owner.Return(this);
			}
		}

		IEnumerator ReturnToPool() {
			yield return new WaitForSeconds(2f);
			Return();
		}
	}
}
