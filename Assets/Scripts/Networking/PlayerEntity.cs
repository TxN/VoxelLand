using UnityEngine;

using ZeroFormatter;

namespace Voxels.Networking {
	[ZeroFormattable]
	public class PlayerEntity {
		[IgnoreFormat]
		public ClientState   Owner = null;
		[IgnoreFormat]
		public PlayerMovement View = null;
		[Index(0)]
		public virtual string  PlayerName { get; set; }
		[Index(1)]
		public virtual Vector3 Position   { get; set; }
		[Index(2)]
		public virtual Vector2 LookDir    { get; set; }

		public static bool IsLocalPlayer(PlayerEntity entity) {
			if ( !GameManager.Instance.IsClient ) {
				return false;
			}
			var name = ClientController.Instance.ClientName;
			return entity.PlayerName == name;			
		}
	}
}
