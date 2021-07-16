using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Voxels.Utils;

using ZeroFormatter;

namespace Voxels.Networking.Serverside {

	public class VoxelMoverServerside {
		const float GRAVITY          = 10f;
		const float POS_MIN_DELTA    = 0.05f;
		const float ANG_MIN_DELTA    = 2f;
		const float MAX_SWIM_SPEED   = 4f;

		public float Radius     = 0.5f;
		public float UpHeight   = 0.6f;
		public float DownHeight = 1f;
		public float JumpSpeed  = 6f;
		public bool  Buoyant    = true;
		public bool  AirControl = false;
		public bool  FreeMove   = true;

		Vector3 _velocity       = Vector3.zero;
		Vector3 _lastSentPos    = Vector3.zero;
		Vector3 _lastSentRot    = Vector3.zero;
		IChunkManager _chunkManager = null;
		DynamicEntityServerside _owner = null;

		public Vector3    MoveVector     { get; set; }
		public float      MaxMoveSpeed   { get; set; } = 5f;
		public Vector3    Velocity       { get { return _velocity; } }
		public Vector3    Position       { get; set; }
		public Quaternion Rotation       { get; set; }
		public bool       GravityEnabled { get; set; } = true;

		public Vector3 RotationEuler {
			get {
				return Rotation.eulerAngles;
			}
			set {
				Rotation = Quaternion.Euler(value);
			}
		}

		public VoxelMoverServerside(DynamicEntityServerside owner) {
			_chunkManager = ServerChunkManager.Instance;
			_owner = owner;
		}

		public bool NeedSendUpdate {
			get {
				return NeedSyncPosition || NeedSyncRotation;
			}
		}

		public Byte3 PackedRotation {
			get {
				var rot = RotationEuler;
				return MathUtils.PackRotation(rot);
			}
		}

		bool NeedSyncPosition {
			get {
				var moveDelta = Position - _lastSentPos;
				return moveDelta.magnitude > POS_MIN_DELTA;
			}
		}

		bool NeedSyncRotation {
			get {
				var rotDelta = Vector3.Distance(RotationEuler, _lastSentRot);
				return rotDelta > ANG_MIN_DELTA;
			}
			
		}
		public bool IsGrounded {
			get {
				return VoxelsUtils.Cast(Position, Vector3.down, DownHeight + 0.01f, IsBlockSolid, out var downCastResult);
			}
		}

		public bool IsInWater {
			get {
				return StaticResources.BlocksInfo.GetBlockDescription(_chunkManager.GetBlockIn(Position).Type).IsSwimmable;
			}
		}

		public byte[] GetPosUpdateMessage(out PosUpdateType type) {
			var p = NeedSyncPosition;
			var r = NeedSyncRotation;
			type = PosUpdateType.None;
			if ( p && r ) {
				type = PosUpdateType.PosRot;
				var c = new S_UpdateEntityPosRotMessage { CommandID = (byte) PosUpdateType.PosRot, Position = Position, Rotation = PackedRotation, UID = _owner.UID };
				return ZeroFormatterSerializer.Serialize(c);
			}
			if ( p ) {
				type = PosUpdateType.Pos;
				var c = new S_UpdateEntityPosMessage { CommandID = (byte)PosUpdateType.Pos, Position = Position, UID = _owner.UID };
				return ZeroFormatterSerializer.Serialize(c);
			}
			if ( r ) {
				type = PosUpdateType.Rot;
				var c = new S_UpdateEntityRotMessage { CommandID = (byte)PosUpdateType.Rot, Rotation = PackedRotation, UID = _owner.UID };
				return ZeroFormatterSerializer.Serialize(c);
			}
			return null;
		}

		public void Jump() {
			var canJump = IsGrounded || (IsInWater && Buoyant);
			if ( canJump ) {
				Position += new Vector3(0, 0.1f, 0);
				_velocity.y = JumpSpeed;
			}
		}

		public void UpdateSent() {
			_lastSentRot = RotationEuler;
			_lastSentPos = Position;
		}

		public bool IsVoxelOcuppied(Vector3 worldPos) {
			worldPos += new Vector3(0.5f, 0.5f, 0.5f);
			var bottomCheckPos = Position - new Vector3(0, DownHeight * 0.7f, 0);
			var upCheckPos     = Position + new Vector3(0, UpHeight * 0.85f, 0);

			return (Vector3.Distance(worldPos, bottomCheckPos) < 0.5f + Radius) || (Vector3.Distance(worldPos, upCheckPos) < 0.5f + Radius);
		}

		public void Move(Vector3 localDirection, float speedMul) {
			var dir = Rotation * localDirection;
			MoveVector = dir * speedMul;
		}

		public void OverrideVelocity(Vector3 velocity) {
			_velocity = velocity;
		}
		
		public void Update() {
			var tickTime = ServerDynamicEntityController.TICK_TIME;
			var inWater = IsInWater;
			var moveFlag = (AirControl || IsGrounded || inWater) && FreeMove;
			if ( moveFlag ) {
				_velocity.x = MoveVector.x;
				_velocity.z = MoveVector.z;
				MoveVector = Vector3.ClampMagnitude(MoveVector, MaxMoveSpeed);
			}

			if ( GravityEnabled && (!Buoyant || !inWater) ) {
				_velocity.y -= GRAVITY * tickTime;
			} else if ( moveFlag ) {
				_velocity.y = MoveVector.y;
			}

			if ( inWater ) {
				_velocity = Vector3.ClampMagnitude(_velocity, MAX_SWIM_SPEED);

				if ( Buoyant ) {
					_velocity.y += 1f * tickTime;
				} else {
					_velocity.y -= GRAVITY * tickTime * 0.3f;
				}
			}

			var resultMoveVector = Vector3.zero;

			var yDist = _velocity.y * tickTime;
			if ( yDist < 0 ) {
				var check = CheckHorizontalPoints(Vector3.down, Radius - yDist, out var downDist);
				resultMoveVector.y = check ? Mathf.Max(yDist, -(downDist - Radius)) : yDist;
				_velocity.y = check ? 0 : _velocity.y;
			} else if ( yDist > 0 ) {
				var check = CheckHorizontalPoints(Vector3.up, Radius + yDist, out var upDist);
				resultMoveVector.y = check ? Mathf.Min(yDist, upDist - Radius) : yDist;
				_velocity.y = check ? 0 : _velocity.y;
			}

			var xDist = _velocity.x * tickTime;
			if ( xDist < 0 ) {
				resultMoveVector.x = CheckHorizontalPoints(Vector3.left, Radius - xDist, out var leftDist) ? Mathf.Max(xDist, -(leftDist - Radius)) : xDist;
			} else if ( xDist > 0 ) {
				resultMoveVector.x = CheckHorizontalPoints(Vector3.right, Radius + xDist, out var rightDist) ? Mathf.Min(xDist, rightDist - Radius) : xDist;
			}

			var zDist = _velocity.z * tickTime;
			if ( zDist < 0 ) {
				resultMoveVector.z = CheckHorizontalPoints(Vector3.back, Radius - zDist, out var backDist) ? Mathf.Max(zDist, -(backDist - Radius)) : zDist;
			} else if ( zDist > 0 ) {
				resultMoveVector.z = CheckHorizontalPoints(Vector3.forward, Radius + zDist, out var fwdDist) ? Mathf.Min(zDist, fwdDist - Radius) : zDist;
			}

			Position += resultMoveVector;
		}

		bool CheckHorizontalPoints(Vector3 direcion, float distance, out float minDistance) {
			var bottomCheckPos = Position + new Vector3(0, -DownHeight + Radius, 0);
			var upCheckPos = Position + new Vector3(0, UpHeight - Radius, 0);
			minDistance = 0f;
			var a = VoxelsUtils.Cast(bottomCheckPos, direcion, distance, IsBlockSolid, out var bottomCastResult);
			var b = VoxelsUtils.Cast(upCheckPos, direcion, distance, IsBlockSolid, out var upCastResult);
			if ( a || b ) {
				var upD = Vector3.Distance(upCheckPos, upCastResult.HitPosition);
				var dnD = Vector3.Distance(bottomCheckPos, bottomCastResult.HitPosition);
				minDistance = Mathf.Min(upD, dnD);
				return true;
			}
			return false;
		}

		bool IsBlockSolid(Int3 index) {
			var lib = StaticResources.BlocksInfo;
			var block = _chunkManager.GetBlockIn(index.X, index.Y, index.Z);
			return !lib.GetBlockDescription(block.Type).IsPassable;
		}

		public BlockData CurrentBlock( ) {
			return _chunkManager.GetBlockIn(Position);
		}
	}
}
