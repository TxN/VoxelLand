using UnityEngine;

using Voxels.Utils;
using Voxels.Networking.Clientside;

namespace Voxels {
	public sealed class PlayerProxyAnimation : MonoBehaviour {

		public Vector2              LookAngleMinMax = new Vector2(-85, 85);
		public Animator             Anim            = null;
		public PlayerMovement       Owner           = null;
		public MovementInterpolator Interpolator    = null;

		public bool  IsGrounded = true;
		public bool  Swinging   = false;

		void Update() {
			Anim.SetBool ("Grounded",  IsGrounded);
			Anim.SetBool ("Swing",     Swinging);
			Anim.SetFloat("Speed",     Interpolator.HMoveSpeed * 2);
			Anim.SetFloat("AbsSpeed",  Interpolator.HMoveSpeed);
			var rawPitch = Owner.HeadPitch;
			if ( Mathf.Abs(rawPitch) < 10f ) {
				rawPitch = 0f;
			}
			Anim.SetFloat("LookAngle", MathUtils.Remap(rawPitch, LookAngleMinMax.y, LookAngleMinMax.x, 0.03f, 0.97f));
		}
	}
}
