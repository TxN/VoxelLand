using UnityEngine;

using Voxels.Networking.Clientside;

namespace Voxels {
	public class SimpleVoxelMover : MonoBehaviour {
		public float MaxVSpeed = 20f;
		public float MoveSpeed = 6f;
		public float RotationSensivity = 2.5f;

		public float Gravity = 1f;

		public float Radius = 0.3f;
		public float UpHeight = 0.6f;
		public float DownHeight = 1f;

		public float JumpSpeed = 5f;

		Vector3 _velocity = Vector3.zero;
		Vector3 _moveVector = Vector3.zero;
		IChunkManager _chunkManager = null;

		Vector2 _curRot = Vector2.zero;

		private void Start() {
			_chunkManager = ClientChunkManager.Instance;
		}

		private void Update() {
			var im = ClientInputManager.Instance;
			float inputX = Input.GetAxis("Horizontal");
			float inputY = im.GetInputAxisVertical();
			var jump = im.GetJumpButton();

			var movementEnabled = im.IsMovementEnabled;


			var inputVector = Vector3.zero;
			if ( ClientInputManager.Instance.IsMovementEnabled ) {
				inputVector = new Vector3(inputX, 0, inputY);
				var rotation = _curRot += new Vector2( 0,Input.GetAxis("Mouse X") * RotationSensivity);
				transform.eulerAngles = rotation;
			}

			_velocity.y -= Gravity * Time.deltaTime;


			var downCast = VoxelsUtils.Cast(transform.position, Vector3.down, DownHeight, IsBlockSolid, out var downCastResult);
			if ( downCast ) {
				transform.position = new Vector3(transform.position.x, downCastResult.HitPosition.y + DownHeight - 0.01f, transform.position.z);
				_velocity.y = 0;
			} else {
				jump = false;
			}

			var upCast = VoxelsUtils.Cast(transform.position, Vector3.up, UpHeight, IsBlockSolid, out var upCastResult);
			if ( upCast ) {
				transform.position = new Vector3(transform.position.x, upCastResult.HitPosition.y - UpHeight - 0.01f, transform.position.z);
				_velocity.y = 0;
			}

			if ( jump ) {
				_velocity.y = JumpSpeed;
			}

			var resultMoveVector = inputVector * Time.deltaTime * MoveSpeed;

			var yDist = _velocity.y * Time.deltaTime;
			if ( yDist < 0 ) {
				 if ( VoxelsUtils.Cast(transform.position, Vector3.down, DownHeight + yDist, IsBlockSolid, out var fallCastResult) ) {
					var nearBlockDist = Vector3.Distance(transform.position, fallCastResult.HitPosition);
					resultMoveVector.y = Mathf.Max(yDist, -nearBlockDist);
				 } else {
					resultMoveVector.y = yDist;
				 }
			} else if ( yDist > 0 ) {
				if ( VoxelsUtils.Cast(transform.position, Vector3.up, UpHeight + yDist, IsBlockSolid, out var jumpCastResult) ) {
					var nearBlockDist = Vector3.Distance(transform.position, jumpCastResult.HitPosition);
					resultMoveVector.y = Mathf.Min(yDist, nearBlockDist);
				} else {
					resultMoveVector.y = yDist;
				}
			}
			
			

			transform.Translate(resultMoveVector);
		}


		bool IsBlockSolid(Int3 index) {
			var lib = VoxelsStatic.Instance.Library;
			var block = _chunkManager.GetBlockIn(index.X, index.Y, index.Z);
			return !lib.GetBlockDescription(block.Type).IsPassable;
		}


	}
}

