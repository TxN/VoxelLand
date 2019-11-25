using System.Collections.Generic;

using UnityEngine;

using Voxels.Networking.Clientside;

namespace Voxels {
	public sealed class PlayerProxyAppearance : MonoBehaviour {

		public Material              BaseMaterial  = null;
		public VoxelLightingReceiver LightReceiver = null;

		public List<Renderer> ModelParts = new List<Renderer>();

		Material              _material = null;

		void Start() {
			_material = Instantiate(BaseMaterial);
			foreach ( var part in ModelParts ) {
				part.material = _material;
			}
		}

		void Update() {
			var wsc = ClientWorldStateController.Instance;
			_material.SetFloat("_LightLevel", LightReceiver.GetLightLevel() / (float) 255);
		}
	}
}
