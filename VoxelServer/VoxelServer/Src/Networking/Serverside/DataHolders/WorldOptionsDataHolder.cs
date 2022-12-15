using System.Collections.Generic;

using ZeroFormatter;


namespace Voxels.Networking.Serverside {
	[ZeroFormattable]
	public class WorldOptionsDataHolder {
		[Index(0)]
		public virtual int   Seed                { get; set; }
		[Index(1)]
		public virtual int   ChunkLoadRadius     { get; set; }
		[Index(2)]
		public virtual int   MaxLoadRadius       { get; set; }
		[Index(3)]
		public virtual int   ChunkUnloadDistance { get; set; }
		[Index(4)]
		public virtual int   UselessChunksMaxAge { get; set; }
		[Index(5)]
		public virtual float DayLength           { get; set; }
		[Index(6)]
		public virtual float WorldTime           { get; set; }
		[Index(7)]
		public virtual float TimeMultiplier      { get; set; }
	}
}
