using UnityEngine;

using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class S_SpawnEntityMessage : BaseMessage {
		[Index(1)]
		public virtual uint    UID      { get; set; }
		[Index(2)]
		public virtual string  TypeName { get; set; }
		[Index(3)]
		public virtual Vector3 Position { get; set; }
		[Index(4)]
		public virtual Byte3   Rotation { get; set; }
		[Index(5)]
		public virtual byte[]   State   { get; set; }
	}
}
