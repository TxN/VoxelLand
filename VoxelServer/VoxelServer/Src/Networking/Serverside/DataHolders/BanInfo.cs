using System;

using LiteDB;

namespace Voxels.Networking.Serverside {
	public sealed class BanInfo {
		[BsonId]
		public int      Id       { get; set; }
		public string   IP       { get; set; }
		public string   Name     { get; set; }
		public DateTime BanStart { get; set; }
		public DateTime BanEnd   { get; set; }
		public string   Reason   { get; set; }
	}
}
