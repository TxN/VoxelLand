using UnityEngine;
using System.IO;

namespace Voxels {
	public static class ChunkSerializer {
		public static void Serialize(ChunkData data, BinaryWriter writer) {
			writer.Write(data.IndexX);
			writer.Write(data.IndexY);
			writer.Write(data.IndexZ);
			writer.Write(data.Height);
			writer.Write(data.Origin.x);
			writer.Write(data.Origin.y);
			writer.Write(data.Origin.z);
			writer.Write(data.Blocks.Length);

			var y = 0;
			for ( int i = 0; i < data.Blocks.Length; i += Chunk.CHUNK_SIZE_X * Chunk.CHUNK_SIZE_X ) {
				var local = i;
				for ( int z = 0; z < Chunk.CHUNK_SIZE_Z; z++ ) {
					for ( int x = 0; x < Chunk.CHUNK_SIZE_X; x++ ) {
						var block = data.Blocks[x,y,z];
						writer.Write((byte)block.Type);
						writer.Write(block.Subtype);
						writer.Write(block.SunLevel);
						writer.Write(block.LightLevel);
						writer.Write(block.AddColor);
						writer.Write(block.Metadata);
						writer.Write( (byte) data.Visibiltiy[x, y, z]);
						local++;
					}
				}
				y++;
			}
		}

		public static ChunkData Deserialize(BinaryReader reader) {
			var data = new ChunkData();
			data.IndexX = reader.ReadInt32();
			data.IndexY = reader.ReadInt32();
			data.IndexZ = reader.ReadInt32();
			data.Height = reader.ReadByte();
			data.Origin = new Vector3( reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle()) ;
			var count = reader.ReadInt32();

			data.Blocks     = new BlockData[Chunk.CHUNK_SIZE_X, Chunk.CHUNK_SIZE_Y, Chunk.CHUNK_SIZE_Z];
			data.Visibiltiy = new VisibilityFlags[Chunk.CHUNK_SIZE_X, Chunk.CHUNK_SIZE_Y, Chunk.CHUNK_SIZE_Z];

			var y = 0;
			for ( int i = 0; i < data.Blocks.Length; i += Chunk.CHUNK_SIZE_X * Chunk.CHUNK_SIZE_X ) {
				var local = i;
				for ( int z = 0; z < Chunk.CHUNK_SIZE_Z; z++ ) {
					for ( int x = 0; x < Chunk.CHUNK_SIZE_X; x++ ) {
						var block = new BlockData( (BlockType) reader.ReadByte(), reader.ReadByte());
						block.SunLevel = reader.ReadByte();
						block.LightLevel = reader.ReadByte();
						block.AddColor = reader.ReadUInt16();
						block.Metadata = reader.ReadUInt16();
						data.Blocks[x, y, z] = block;
						data.Visibiltiy[x, y, z] = (VisibilityFlags) reader.ReadByte();
						local++;

					}
				}
				y++;
			}

			return data;
		}
	}
}
