using System.IO;

using UnityEngine;

using ZeroFormatter;

namespace Voxels {
	public static class ChunkSerializer {
		public static void Serialize(ChunkData data, BinaryWriter writer, bool compress) {

			var uncompressed = ZeroFormatterSerializer.Serialize(data);
			var result = CLZF2.Compress(uncompressed);
			writer.Write(compress);
			writer.Write(result.Length);
			writer.Write(result);
			
		}

		public static ChunkData Deserialize(BinaryReader reader) {
			var compressed = reader.ReadBoolean();
			var length = reader.ReadInt32();
			if ( !compressed ) {
				var obj = ZeroFormatterSerializer.Deserialize<ChunkData>(reader.ReadBytes(length));
				return obj;
			}
			var data = CLZF2.Decompress(reader.ReadBytes(length));
			var uncomp = ZeroFormatterSerializer.Deserialize<ChunkData>(data);
			return uncomp;
		}
	}
}
