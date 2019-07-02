using UnityEngine;
using Unity.Jobs;
using Unity.Collections;
using Unity.Burst;

namespace Voxels {
	[BurstCompile]
	public struct HeightGenJob : IJobParallelFor {
		public int SizeX;
		public int SizeY;
		public int OffsetX;
		public int OffsetY;
		public int Seed;
		public float BaseScale;

		[WriteOnly]
		public NativeArray<byte> Height;

		public void Execute(int index) {
			var x = OffsetX + ( index / SizeX);
			var y = OffsetY + (index % SizeY);

			var noise =  Mathf.PerlinNoise(x / (float) 32 + Seed, y / (float) 32 + Seed) * BaseScale * 0.5f;
			noise += Mathf.PerlinNoise(x / (float)64 + Seed - 3, y / (float)64 + Seed - 3) * BaseScale;
			noise += Mathf.PerlinNoise(x / (float)128 + Seed + 5, y / (float)128 + Seed + 5) * BaseScale * 2;
			noise += Mathf.PerlinNoise(x / (float)16 + Seed - 4, y / (float)16 + Seed - 8) * BaseScale * 0.25f;
			Height[index] = System.Convert.ToByte(noise);
		}
	}

	[BurstCompile]
	public struct ChunkGenJob  : IJobParallelFor {
		public int SizeH;
		public int SizeY;
		public int Seed;
		public int SeaLevel;
		public Unity.Mathematics.Random Random;

		[ReadOnly]
		public NativeArray<byte> HeightMap;

		[WriteOnly]
		public NativeArray<BlockData> Blocks;
		public void Execute(int index) {
			var dh = SizeH * SizeH;
			var y = index / dh;
			var h = index % dh;
			var x = h % SizeH;
			var z = h / SizeH;
			var height = HeightMap[(x) * SizeH + z];
			var stoneHeight = (int)(height * 0.8f);

			var rnd8pct = Random.NextUInt(0, 12) < 1 ? true : false;
			var rnd3pct = Random.NextUInt(0, 30) < 1 ? true : false;

			if ( y == 0 ) {
				Blocks[y * dh + z * SizeH + x] = new BlockData(BlockType.Bedrock, 0);
				return;
			}
			if ( y < stoneHeight ) {
				Blocks[y * dh + z * SizeH + x] = new BlockData(BlockType.Stone, 0);
			} else if ( y < height ){
				Blocks[y * dh + z * SizeH + x] = new BlockData(BlockType.Dirt, 0);
				return;
			} else if ( y == height ) {
				if ( y > SeaLevel ) {
					Blocks[y * dh + z * SizeH + x] = new BlockData(BlockType.Grass, 0);
				} else {
					Blocks[y * dh + z * SizeH + x] = new BlockData(BlockType.Sand, 0);
				}
				
			} else if ( y > height && y < SeaLevel ) {
				Blocks[y * dh + z * SizeH + x] = new BlockData() {
					Type = BlockType.WaterStill,
					SunLevel = (byte) (225 - (SeaLevel - y) * 10),
					AddColor = 65535,
				};
			} else if (y == height + 1 && rnd8pct && y > SeaLevel ) {
				Blocks[y * dh + z * SizeH + x] = new BlockData() {
					Type = BlockType.Weed,
					SunLevel = 255,
					AddColor = 65535,
				};
			} else if ( y == height + 1 && rnd3pct && y > SeaLevel ) {
				Blocks[y * dh + z * SizeH + x] = new BlockData() {
					Type = BlockType.Shrub,
					Subtype  = (byte) Random.NextInt(0, 3),
					SunLevel = 255,
					AddColor = 65535,
				};
			} else if ( y > height  || (!rnd8pct && y > height)) {
				Blocks[y * dh + z * SizeH + x] = new BlockData() {
					SunLevel = 255
				};
			}
		}
	}
}