using UnityEngine;

using Voxels.Utils;

using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class PlayerEntity {
		[IgnoreFormat]
		public Serverside.ClientState   Owner = null;
		[Index(0)]
		public virtual ushort  ConId      { get; set; }
		[Index(1)]
		public virtual string  PlayerName { get; set; }
		[Index(2)]
		public virtual Vector3 Position   { get; set; }
		[Index(3)]
		public virtual Vector2 LookDir    { get; set; }

		[IgnoreFormat]
		public byte CompressedPitch {
			get {
				return (byte)Mathf.RoundToInt(MathUtils.Remap(LookDir.x, 0, 360, 0, 255));
			}
		}

		[IgnoreFormat]
		public byte CompressedYaw {
			get {
				return (byte)Mathf.RoundToInt(MathUtils.Remap(LookDir.y, 0, 360, 0, 255));
			}
		}
	}
}
