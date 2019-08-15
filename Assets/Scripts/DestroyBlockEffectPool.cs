using SMGCore;

namespace Voxels {
	public class DestroyBlockEffectPool : PrefabPool<DestroyBlockEffect> {
		public DestroyBlockEffectPool() {
			PresenterPrefabPath = "BlockDestroyParticle";
		}
	}
}
