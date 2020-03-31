using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Voxels.Utils;

using ZeroFormatter;

namespace Voxels.Networking.Serverside {

	public class VoxelMoverServerside {
		const float GRAVITY          = 5f;
		const float POS_MIN_DELTA    = 0.05f;
		const float ANG_MIN_DELTA    = 2f;

		public float Radius     = 0.3f;
		public float UpHeight   = 0.6f;
		public float DownHeight = 1f;

		Vector3 _velocity       = Vector3.zero;
		Vector3 _lastSentPos    = Vector3.zero;
		Vector3 _lastSentRot    = Vector3.zero;
		IChunkManager _chunkManager = null;
		DynamicEntityServerside _owner = null;

		public Vector3    MoveVector     { get; set; }
		public Vector3    MaxMoveSpeed   { get; set; }
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

		public void Update() {
			var tickTime = ServerDynamicEntityController.TICK_TIME;

			_velocity.x = MoveVector.x * MaxMoveSpeed.x;			
			_velocity.z = MoveVector.z * MaxMoveSpeed.z;
			if ( GravityEnabled ) {
				_velocity.y -= GRAVITY * tickTime;
			} else {
				_velocity.y = MoveVector.y * MaxMoveSpeed.y;
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
			var lib = VoxelsStatic.Instance.Library;
			var block = _chunkManager.GetBlockIn(index.X, index.Y, index.Z);
			return !lib.GetBlockDescription(block.Type).IsPassable;
		}
	}
}
