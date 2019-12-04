using System.Collections.Generic;

using UnityEngine;

using SMGCore.EventSys;
using Voxels.Events;
using Voxels.UI;

using JetBrains.Annotations;

namespace Voxels.Networking.Clientside {
	public sealed class ClientInputManager : ClientsideController<ClientInputManager> {
		public ClientInputManager(ClientGameManager owner) : base(owner) { }

		const string MOBILE_INPUT_FAB_PATH = "Client/MobileInput";

		HashSet<object> _movementLockHolders = new HashSet<object>();

		MobileInput _mobileInputUi = null;

		public bool IsMovementEnabled {
			get {
				return _movementLockHolders.Count == 0;
			}
		}

		public override void PostLoad() {
			base.PostLoad();
#if UNITY_ANDROID
			var mobileInputFab = Resources.Load(MOBILE_INPUT_FAB_PATH);
			var ui = ClientUIManager.Instance;
			_mobileInputUi = Object.Instantiate((GameObject)mobileInputFab, ui.MainCanvas.GetComponent<RectTransform>()).GetComponent<MobileInput>();
#endif
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
			} else {
				AddControlLock(holder);
			}
			return IsMovementEnabled;
		}

		public float GetInputAxisHorizontal() {
			if ( !IsMovementEnabled ) {
				return 0;
			}
			return Input.GetAxis("Horizontal");
		}

		public float GetInputAxisVertical() {
			if ( !IsMovementEnabled ) {
				return 0;
			}
			if ( _mobileInputUi ) {
				if ( _mobileInputUi.ForwardPressed ) {
					return 1f;
				}
				if ( _mobileInputUi.BackwardPressed ) {
					return -1f;
				}
			}
			return Input.GetAxis("Vertical");
		}

		public bool GetJumpButton() {
			if ( !IsMovementEnabled ) {
				return false;
			}
			if ( _mobileInputUi ) {
				return _mobileInputUi.JumpPressed;
			}
			return Input.GetKey(KeyCode.Space);
		}

	}
}