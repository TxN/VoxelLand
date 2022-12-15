using System.Collections.Generic;

using UnityEngine;

using Voxels.Networking.Clientside;

namespace Voxels {
	public class SimpleVoxelMover : MonoBehaviour {
		public float MaxVSpeed = 20f;
		public float MoveSpeed = 6f;
		public float SprintSpeed = 9f;
		public float RotationSensivity = 2.5f;

		public float Gravity = 1f;

		public float Radius = 0.3f;
		public float UpHeight = 0.6f;
		public float DownHeight = 1f;

		public float JumpSpeed = 5f;

		Vector3       _velocity     = Vector3.zero;
		IChunkManager _chunkManager = null;

		Vector2 _curRot = Vector2.zero;

		public float CurMoveSpeed {
			get {
				return Input.GetKey(KeyCode.LeftShift) ?  SprintSpeed : MoveSpeed;
			}
		}

		public bool IsGrounded {
			get {
				return _chunkManager.CollisionHelper.Cast(Utils.CastType.AnySolid, transform.position, Vector3.down, DownHeight + 0.05f, out var downCastResult);
			}
		}

		public bool IsInWater {
			get {
				return StaticResources.BlocksInfo.GetBlockDescription(_chunkManager.GetBlockIn(transform.position).Type)?.IsSwimmable ?? false;
			}
		}

		public bool IsUnderwater {
			get {
				return StaticResources.BlocksInfo?.GetBlockDescription((_chunkManager?.GetBlockIn(transform.position + (Vector3.up * 0.4f)) ?? BlockData.Empty).Type)?.IsSwimmable ?? false;
			}
		}

		public bool IsVoxelOcuppied(Vector3 worldPos) {
			worldPos += new Vector3(0.5f, 0.5f, 0.5f);
			var bottomCheckPos = transform.position - new Vector3(0, DownHeight * 0.7f, 0);
			var upCheckPos = transform.position + new Vector3(0, UpHeight * 0.85f, 0);

			return (Vector3.Distance(worldPos, bottomCheckPos) < 0.5f + Radius) || (Vector3.Distance(worldPos, upCheckPos) < 0.5f + Radius);
		}

		void Start() {
			_chunkManager = ClientChunkManager.Instance;
		}

		void Update() {
			var im = ClientInputManager.Instance;
			float inputX = im.GetInputAxisHorizontal();
			float inputY = im.GetInputAxisVertical();
			var jump = im.GetJumpButton();

			var inputVector = Vector3.zero;
			if ( ClientInputManager.Instance.IsMovementEnabled ) {
				inputVector = new Vector3(inputX, 0, inputY);
				var rotation = _curRot += new Vector2(0, Input.GetAxis("Mouse X") * RotationSensivity);
				transform.eulerAngles = rotation;
			}
			if ( jump && (IsGrounded || IsInWater) ) {
				_velocity.y = JumpSpeed;
			}

			inputVector = transform.TransformDirection(inputVector);

			_velocity.x = inputVector.x * CurMoveSpeed;
			_velocity.y -= Gravity * Time.deltaTime;
			_velocity.z = inputVector.z * CurMoveSpeed;

			var resultMoveVector = Vector3.zero;

			var yDist = _velocity.y * Time.deltaTime;
			if ( yDist < 0 ) {
				var check = CheckHorizontalPoints(Vector3.down, Radius - yDist, out var downDist);
				resultMoveVector.y = check ? Mathf.Max(yDist, -(downDist - Radius)) : yDist;
				_velocity.y = check ? 0 : _velocity.y;
			} else if ( yDist > 0 ) {
				var upCheckPos = transform.position + new Vector3(0, UpHeight - Radius, 0);
				var ch = _chunkManager.CollisionHelper;
				var b = ch.Cast(Utils.CastType.Solid, upCheckPos, Vector3.up, Radius + yDist, out var upCastResult);
				var upD = Vector3.Distance(upCheckPos, upCastResult.HitPosition);

				resultMoveVector.y = b ? Mathf.Min(yDist, upD - Radius) : yDist;
				//_velocity.y = check ? 0 : _velocity.y;
			}

			var xDist = _velocity.x * Time.deltaTime;
			if ( xDist < 0 ) {
				resultMoveVector.x = CheckHorizontalPoints(Vector3.left, Radius - xDist, out var leftDist) ? Mathf.Max(xDist, -(leftDist - Radius)) : xDist;
			} else if ( xDist > 0 ) {
				resultMoveVector.x = CheckHorizontalPoints(Vector3.right, Radius + xDist, out var rightDist) ? Mathf.Min(xDist, rightDist - Radius) : xDist;
			}

			var zDist = _velocity.z * Time.deltaTime;
			if ( zDist < 0 ) {
				resultMoveVector.z = CheckHorizontalPoints(Vector3.back, Radius - zDist, out var backDist) ? Mathf.Max(zDist, -(backDist - Radius)) : zDist;
			} else if ( zDist > 0 ) {
				resultMoveVector.z = CheckHorizontalPoints(Vector3.forward, Radius + zDist, out var fwdDist) ? Mathf.Min(zDist, fwdDist - Radius) : zDist;
			}

			transform.Translate(resultMoveVector, Space.World);
		}


		bool CheckHorizontalPoints(Vector3 direcion, float distance, out float minDistance) {
			var bottomCheckPos = transform.position + new Vector3(0, - DownHeight + Radius, 0);
			var upCheckPos = transform.position + new Vector3(0, UpHeight - Radius, 0);
			minDistance = 0f;
			var ch = _chunkManager.CollisionHelper;
			var a = ch.Cast(Utils.CastType.Solid, bottomCheckPos, direcion, distance, out var bottomCastResult);
			var b = ch.Cast(Utils.CastType.Solid, upCheckPos, direcion, distance, out var upCastResult);
			if ( a || b ) {
				var upD = Vector3.Distance(upCheckPos, upCastResult.HitPosition);
				var dnD = Vector3.Distance(bottomCheckPos, bottomCastResult.HitPosition);
				minDistance = Mathf.Min(upD, dnD);
				return true;
			}
			return false;
		}
	}
}

