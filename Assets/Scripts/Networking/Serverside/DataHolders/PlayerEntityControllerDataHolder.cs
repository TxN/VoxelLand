using System.Collections.Generic;

using UnityEngine;

using LiteDB;

namespace Voxels.Networking.Serverside {

	public sealed class PlayerEntitySaveInfo {
		[BsonId]
		public string          Name         { get; set; }
		public Vector3         SpawnPoint   { get; set; }
		public Vector3         HomePoint    { get; set; }
		public Vector3         LastSavedPos { get; set; }
		public string          UsedSkinName { get; set; }
		public List<BlockData> Inventory    { get; set; }
	}
}

