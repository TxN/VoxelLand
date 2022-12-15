using System;

namespace Voxels.Networking.Serverside {
	public abstract class DynamicEntityServerside {
		public uint UID;
		public virtual string EntityType { get; }

		public VoxelMoverServerside Mover { get; }


		public DynamicEntityServerside() {
			Mover = new VoxelMoverServerside(this);
		}

		public abstract void Init();

		public virtual void DeserializeState(byte[] state) { }
		public virtual byte[] SerializeState() {
			return Array.Empty<byte>();
		}

		public virtual byte[] SerializeViewState() {
			return Array.Empty<byte>();
		}

		public void CallMethodOnClient(string methodName) {

		}

		public void SetPropOnClient(string propName, object value) {

		}

		public virtual void Tick() {
			Mover.Update();
		}

		public virtual void NetTick() {
			if ( Mover.NeedSendUpdate ) {
				//TODO: send position update
			}
		}
	}
}