using System.IO;

namespace Voxels {
	public static class ChunkSerializer {
		public static int Serialize(ChunkData data, BinaryWriter writer, bool compress) {
			writer.Write(compress);
			writer.Write(data.IndexX);
			writer.Write(data.IndexY);
			writer.Write(data.IndexZ);
			writer.Write(data.Height);
			writer.Write(32768);
			writer.Write(data.Origin.x);
			writer.Write(data.Origin.y);
			writer.Write(data.Origin.z);
			var blockData = new byte[0];
			var uncompressed = ChunkHelper.ToByteArray(data.Blocks.Data, Chunk.CHUNK_SIZE_X * Chunk.CHUNK_SIZE_Z * Chunk.CHUNK_SIZE_Y);
			
			if ( compress ) {
				blockData = CLZF2.Compress(uncompressed);
			} else {
				blockData = uncompressed;
			}
			writer.Write(blockData.Length);
			writer.Write(blockData);
			return (int)writer.BaseStream.Position;
		}

		public static ChunkData Deserialize(BinaryReader reader) {
			var compressed = reader.ReadBoolean();
			var indexX     = reader.ReadInt32();
			var indexY     = reader.ReadInt32();
			var indexZ     = reader.ReadInt32();
			var height     = reader.ReadInt32();
			var blockCount = reader.ReadInt32();
			var originX    = reader.ReadSingle();
			var originY    = reader.ReadSingle();
			var originZ    = reader.ReadSingle();
			var dataLen    = reader.ReadInt32();
			byte[] data    = new byte[0];
			if ( compressed ) {
				data = CLZF2.Decompress(reader.ReadBytes(dataLen));
			} else {
				data = reader.ReadBytes(dataLen);
			}
			var blocks = ChunkHelper.FromByteArray(data, blockCount);
			var chunk = new ChunkData {
				Blocks = new BlockDataHolder(Chunk.CHUNK_SIZE_X, Chunk.CHUNK_SIZE_Y, Chunk.CHUNK_SIZE_Z, blocks),
				Height = height,
				IndexX = indexX,
				IndexY = indexY,
				IndexZ = indexZ,
				Origin = new UnityEngine.Vector3(originX, originY, originZ)
			};

			return chunk;
		}
	}
}
