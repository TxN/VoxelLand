using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
			var result = new byte[0];

			return result;
		}

		public virtual byte[] SerializeViewState() {
			var result = Array.Empty<byte>();

			return result;
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