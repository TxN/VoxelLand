using UnityEngine;

using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class NetworkedEntity {
		[Index(0)]
		public virtual int UID { get; set; }

		public void Create() {
			if ( !GameManager.Instance.IsServer ) {
				return;
			}
		}

		public void Destroy() {
			if ( !GameManager.Instance.IsServer ) {
				return;
			}
		}
	}
}

