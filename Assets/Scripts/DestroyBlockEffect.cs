using System.Collections;

using UnityEngine;

using SMGCore;

namespace Voxels {
	public class DestroyBlockEffect : MonoBehaviour, IPoolItem {
		ParticleSystem         _pSystem     = null;
		ParticleSystemRenderer _pRenderer   = null;
		Material               _instanceMat = null;
		DestroyBlockEffectPool _owner       = null;
		ChunkManager           _cm          = null;

		bool _inited = false;

		public void PlayEffect(BlockData data, DestroyBlockEffectPool owner) {
			if ( !_inited ) {
				Init();
			}
			gameObject.SetActive(true);
			var desc = ChunkManager.Instance.Library.GetBlockDescription(data.Type);
			var tile = desc.Subtypes[data.Subtype].FaceTiles[0];
			_instanceMat.SetInt  ("_tilePosX", tile.X);
			_instanceMat.SetInt  ("_tilePosY", tile.Y);
			//_cm.GetBlockIn( new Vector3)
			//_instanceMat.SetFloat("_lightLevel", Mathf.Max(data.LightLevel, data.SunLevel) / 255f);
			_pSystem.Play();
		}

		public void DeInit() {
			_pSystem.Stop();
			gameObject.SetActive(false);
		}

		void Init() {
			_cm                 = ChunkManager.Instance;
			_pSystem            = GetComponent<ParticleSystem>();
			_pRenderer          = GetComponent<ParticleSystemRenderer>();
			_instanceMat        = new Material(_pRenderer.material);
			_pRenderer.material = _instanceMat;
			_inited             = true;
		}

		IEnumerator ReturnToPool() {
			yield return new WaitForSeconds(2f);
			if ( _owner != null ) {
				_owner.Return(this);
			}
		}
	}
}

