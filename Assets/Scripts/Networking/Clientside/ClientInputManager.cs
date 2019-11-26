using System.Collections.Generic;

using UnityEngine;

using SMGCore.EventSys;
using Voxels.Events;
using Voxels.Utils;

using JetBrains.Annotations;

namespace Voxels.Networking.Clientside {
	public sealed class ClientInputManager : ClientsideController<ClientInputManager> {
		public ClientInputManager(ClientGameManager owner) : base(owner) { }

		HashSet<object> _movementLockHolders = new HashSet<object>();


		public bool IsMovementEnabled {
			get {
				return _movementLockHolders.Count == 0;
			}
		}


		public override void Reset() {
			base.Reset();
			_movementLockHolders.Clear();
		}

		public void AddControlLock(object holder) {
			var lastLock = IsMovementEnabled;
			_movementLockHolders.Add(holder);

			if ( lastLock != IsMovementEnabled ) {
				EventManager.Fire(new Event_ControlLockChanged(IsMovementEnabled));
			}
		}

		public void RemoveControlLock(object holder) {
			var lastLock = IsMovementEnabled;
			_movementLockHolders.Remove(holder);

			if ( lastLock != IsMovementEnabled ) {
				EventManager.Fire(new Event_ControlLockChanged(IsMovementEnabled));
			}
		}

		public bool AddOrRemoveControlLock(object holder) { //for toggling, returns pause state
			if ( _movementLockHolders.Contains(holder) ) {
				RemoveControlLock(holder);
			}
			else {
				AddControlLock(holder);
			}
			return IsMovementEnabled;
		}

	}
}