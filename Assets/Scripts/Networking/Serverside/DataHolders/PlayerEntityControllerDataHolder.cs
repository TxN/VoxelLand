using System.Collections.Generic;

using UnityEngine;

using ZeroFormatter;

namespace Voxels.Networking.Serverside {
	[ZeroFormattable]
	public class PlayerEntityControllerDataHolder {
		[Index(0)]
		public virtual PlayerEntitySaveInfo[] DataArray { get; set; }
	}

	[ZeroFormattable]
	public class PlayerEntitySaveInfo {
		[Index(0)]
		public virtual string          Name         { get; set; }
		[Index(1)]
		public virtual Vector3         SpawnPoint   { get; set; }
		[Index(2)]
		public virtual Vector3         HomePoint    { get; set; }
		[Index(3)]
		public virtual Vector3         LastSavedPos { get; set; }
		[Index(4)]
		public virtual string          UsedSkinName { get; set; }
		[Index(5)]
		public virtual List<BlockData> Inventory    { get; set; }

	}
}

