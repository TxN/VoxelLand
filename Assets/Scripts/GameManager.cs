using UnityEngine;

using SMGCore;

namespace Voxels {
	public sealed class GameManager : MonoSingleton<GameManager> {
		public PlayerInteraction LocalPlayer = null;

		public bool PlayerControlEnabled {
			get {
				return true;
			}
		}
	}
}

