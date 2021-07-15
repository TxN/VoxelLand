using System.Collections.Generic;

using UnityEngine;

namespace Voxels {
	public sealed class VoxelLitEntity : VoxelLightingReceiver {
		public Material       BaseMaterial = null;
		public List<Renderer> ModelParts   = new List<Renderer>();

		Material _material = null;
		float _lerpLevel = 0f;

		void Start() {
			_material = Instantiate(BaseMaterial);
			foreach ( var part in ModelParts ) {
				part.material = _material;
			}
			_lerpLevel = GetLightLevel() / (float)255;
		}

		void Update() {
			_lerpLevel = Mathf.Lerp(_lerpLevel, GetLightLevel() / (float)255, 3f * Time.deltaTime);
			_material.SetFloat("_LightLevel", _lerpLevel);
		}
	}
}
