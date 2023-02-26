using System.Collections.Generic;

using UnityEngine;

namespace Voxels {
	public sealed class VoxelLitEntity : VoxelLightingReceiver {
		public Material       BaseMaterial = null;
		public List<Renderer> ModelParts   = new List<Renderer>();

		Material _material    = null;
		float _lerpAmbLevel   = 0f;
		float _lerpBlockLevel = 0f;

		void Start() {
			_material = Instantiate(BaseMaterial);
			foreach ( var part in ModelParts ) {
				part.material = _material;
			}
			_lerpAmbLevel = GetAmbientLightLevel() / (float)255;
			_lerpBlockLevel = GetBlockLightLevel() / (float)255;
		}

		void Update() {
			_lerpAmbLevel = Mathf.Lerp(_lerpAmbLevel, GetAmbientLightLevel() / (float)255, 3f * Time.deltaTime);
			_lerpBlockLevel = Mathf.Lerp(_lerpBlockLevel, GetBlockLightLevel() / (float)255, 3f * Time.deltaTime);
			_material.SetFloat("_LightLevel", _lerpBlockLevel);
			_material.SetFloat("_Daylight", _lerpAmbLevel);
		}
	}
}
