using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Voxels.Networking.Clientside {
	public class DynamicEntityClientside : MonoBehaviour {
		public uint UID;

		MovementInterpolator _mover = null;

		public virtual string EntityType { get; }

		public virtual void Init() {
			_mover = GetComponent<MovementInterpolator>();
		}

		public virtual void DeInit() {

		}

		public virtual void DeserializeState(byte[] state) {

		}

		public void CallMethod(string methodName) {

		}

		public void SendRPCToServer(string methodName) {

		}

		public void UpdatePosition(PosUpdateType type, Vector3 pos, Quaternion rot) {
			_mover.UpdatePosition(type, pos, rot, false);
		}
	}
}