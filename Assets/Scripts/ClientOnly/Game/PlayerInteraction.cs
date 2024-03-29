using UnityEngine;

using Voxels.Networking;
using Voxels.Networking.Clientside;
using SMGCore.EventSys;
using Voxels.Events;

namespace Voxels {
	public sealed class PlayerInteraction : MonoBehaviour {
		public const int MAX_SIGHT_DISTANCE = 32;
		 
		public Vector3   CurrentInPos   { get; private set; } = Vector3.zero;
        public Vector3   CurrentOutPos  { get; private set; } = Vector3.zero;
        public BlockData BlockInSight   { get; private set; } = BlockData.Empty;
        public BlockData BlockOutSight  { get; private set; } = BlockData.Empty;

		public LayerMask EntityColMask;

		public Vector3 ViewDirection {
			get {
				return transform.TransformDirection(Vector3.forward);
			}
		}

		public Color32 PaintColor { get; set; } = Color.white;

		PlayerMovement _mover = null;

		void Awake() {
			_mover = GetComponentInParent<PlayerMovement>();
			EventManager.Subscribe<Event_ColorPicked>(this, OnColorPicked);
		}

		void Update() {
			var cm = ClientChunkManager.Instance;
			var dir = ViewDirection;
			var im = ClientInputManager.Instance;
			var isCast = ClientChunkManager.Instance.CollisionHelper.Cast(Utils.CastType.Solid | Utils.CastType.Passable, transform.position, dir, MAX_SIGHT_DISTANCE, out var castResult);
			if ( isCast ) {
				CurrentInPos  = castResult.HitPosition + dir * 0.03f;
				CurrentOutPos = castResult.HitPosition - dir * 0.015f;

				var chunk = cm.GetChunkInCoords(CurrentInPos);
				if ( chunk != null ) {
					var block = cm.GetBlockIn(CurrentInPos);
					BlockInSight = block;
					var outBlock = cm.GetBlockIn(CurrentOutPos);
					BlockOutSight = outBlock;
					if ( im.IsMovementEnabled ) {
						if ( Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonUp(1) ) {
							InteractWithBlock();
						} else if ( Input.GetMouseButtonUp(1) && CanPlaceBlock(CurrentOutPos) ) {
							var desc = ClientUIManager.Instance.Hotbar.SelectedBlock;
							cm.PutBlock(CurrentOutPos, new BlockData(desc.Type, desc.Subtype));
						} else if ( Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonUp(0) ) {
							PaintBlockInSight(PaintColor);
						} else if ( Input.GetMouseButtonUp(0) ) {
							cm.DestroyBlock(CurrentInPos);
						}
					}
				}
			} else {
				CurrentOutPos = Vector3.zero;
				CurrentInPos = Vector3.zero;
				BlockInSight = BlockData.Empty;
				BlockOutSight = BlockData.Empty;
			}

			if ( im.IsMovementEnabled && Input.GetKeyUp(KeyCode.N) ) {
				LaunchBlock();
			}
		}

		private void OnDestroy() {
			EventManager.Unsubscribe<Event_ColorPicked>(OnColorPicked);
		}

		bool HasBlockIn(Int3 pos ) {
			var block = ClientChunkManager.Instance.GetBlockIn(pos.X, pos.Y, pos.Z);
			var desc = StaticResources.BlocksInfo.GetBlockDescription(block.Type);
			return !block.IsEmpty() && !desc.IsSwimmable;
		}

		bool CanPlaceBlock(Vector3 pos ) {
			var player = ClientPlayerEntityManager.Instance.LocalPlayer;
			var mover = player.View.Mover;
			return !mover.IsVoxelOcuppied(pos);
		}

		void PaintBlockInSight(Color32 color) {
			var cm = ClientChunkManager.Instance;
			var blockIn = cm.GetBlockIn(CurrentInPos);
			if ( !blockIn.IsEmpty() ) {
				blockIn.AddColor = ColorUtils.ConvertTo565(color);
				cm.PutBlock(CurrentInPos, blockIn);
			}
		}

		void LaunchBlock() {
			var cc = ClientController.Instance;
			var desc = ClientUIManager.Instance.Hotbar.SelectedBlock;
			var look = _mover.CurrentLook;
			cc.SendNetMessage(ClientPacketID.PlayerAction, new C_PlayerActionMessage() {
				Action = PlayerActionType.Launch,
				PayloadInt = (int)desc.Type,
				LookYaw = look.y,
				LookPitch = look.x,
			});
		}

		void InteractWithBlock() {
			var cm = ClientChunkManager.Instance;
			var blockIn = cm.GetBlockIn(CurrentInPos);
			Debug.Log(string.Format("Interaction with {0}", blockIn.Type.ToString()));
			var cc = ClientController.Instance;

			var look = _mover.CurrentLook;
			cc.SendNetMessage(ClientPacketID.PlayerAction, new C_PlayerActionMessage() {
				Action = PlayerActionType.Use,
				PayloadInt = (int)blockIn.Type,
				LookYaw = look.y,
				LookPitch = look.x,
			});
		}

		void OnColorPicked(Event_ColorPicked e) {
			PaintColor = e.Color;
		}

	}
}

