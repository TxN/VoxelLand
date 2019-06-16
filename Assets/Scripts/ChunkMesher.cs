using System.Collections.Generic;
using System.Threading;

using UnityEngine;

namespace Voxels {
	public enum BlockMeshType : byte {
		CollidedOpaque      = 0,
		PassableTranslucent = 1,
		CollidedTranslucent = 2,
		PassableOpaque      = 3,
	}

	public struct MesherBlockInput {
		public BlockData       Block;
		public Byte3           Position;
		public LightInfo       Lighting;
		public VisibilityFlags Visibility;
	}

	public sealed class ChunkMesher {
		public bool Busy  { get; private set; }
		public bool Ready { get; private set; }

		public List<MesherBlockInput> Blocks;

		GeneratableMesh _opaqueCollidedMesh      = null;
		GeneratableMesh _translucentPassableMesh = null;
		Vector3         _originPos               = Vector3.zero;
		ResourceLibrary _library                 = null;
		Thread          _curentThread            = null;

		public ChunkMesher(ResourceLibrary library, int chunkMeshCapacity, int capacity, Vector3 originPos) {
			_opaqueCollidedMesh      = new GeneratableMesh(chunkMeshCapacity);
			_translucentPassableMesh = new GeneratableMesh(chunkMeshCapacity / 8);
			_library                 = library;
			_originPos               = originPos;
			Blocks                   = new List<MesherBlockInput>(capacity);
		}

		public GeneratableMesh OpaqueCollidedMesh {
			get { return _opaqueCollidedMesh; }
		}

		public GeneratableMesh TranslucentPassableMesh {
			get { return _translucentPassableMesh; }
		}

		public void PrepareMesher() {
			_opaqueCollidedMesh.ClearData();
			_translucentPassableMesh.ClearData();
			Blocks.Clear();
		}

		public void StartAsyncMeshing() {
			if ( _curentThread != null && _curentThread.IsAlive ) {
				_curentThread.Abort();
			}
			Busy = true;
			_curentThread = new Thread(StartMeshing);
			_curentThread.Start();
		}

		void StartMeshing() {
			Ready = false;
			var stopwatch = System.Diagnostics.Stopwatch.StartNew();
			stopwatch.Start();
			var start = Blocks.Count - 1;
			for ( int i = start; i >= 0 ; i-- ) {
				var blockItem = Blocks[i];
				var rawPos    = blockItem.Position;
				var pos       = _originPos + new Vector3(rawPos.X, rawPos.Y, rawPos.Z);
				var desc      = _library.GetBlockDescription(blockItem.Block.Type);
				if ( desc.IsTranslucent ) {
					BlockModelGenerator.AddBlock(_translucentPassableMesh, desc,ref pos, ref blockItem);
				} else {
					BlockModelGenerator.AddBlock(_opaqueCollidedMesh, desc, ref pos, ref blockItem);
				}
			}
			Ready = true;
			Busy  = false;
			stopwatch.Stop();
			AddTime(stopwatch.Elapsed.TotalMilliseconds);
		}

		public void FinalizeBake() {
			_opaqueCollidedMesh.ClearMesh();
			_translucentPassableMesh.ClearMesh();
			_opaqueCollidedMesh.BakeMesh();
			_translucentPassableMesh.BakeMesh();
			Ready = false;
		}

		static double totalTime = 0d;
		public static int GenCount = 0;
		public static void AddTime(double time) {
			GenCount++;
			totalTime += time;
			//Debug.Log(string.Format("Cur:{0}, Av:{1}",time, totalTime / GenCount));
		}
		public static void PrintBenchmark() {
			Debug.Log(string.Format("Av:{0}", totalTime / GenCount));
		}
	}
}
