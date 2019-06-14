using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;

namespace Voxels {
	public struct HeightGenJob : IJobParallelFor {
		public int SizeX;
		public int SizeY;
		public int Seed;
		public float BaseScale;
		public NativeArray<byte> Height;

		public void Execute(int index) {
			var x = index / SizeX;
			var y = index % SizeY;

			var noise =  Mathf.PerlinNoise(x / (float) 32 + Seed, y / (float) 32 + Seed) * BaseScale * 0.5f;
			noise += Mathf.PerlinNoise(x / (float)64 + Seed - 3, y / (float)64 + Seed - 3) * BaseScale;
			noise += Mathf.PerlinNoise(x / (float)128 + Seed + 5, y / (float)128 + Seed + 5) * BaseScale * 2;
			noise += Mathf.PerlinNoise(x / (float)16 + Seed - 4, y / (float)16 + Seed - 8) * BaseScale * 0.25f;
			Height[index] = System.Convert.ToByte(noise);
		}
	}

	public class HeightGenSync {
		
	}
}