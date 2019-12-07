using System.Collections.Generic;

using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.Profiling;

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

	public sealed class ChunkMesher : IChunkMesher {
		public bool Busy  { get; private set; }
		public bool Ready { get; private set; }

		public List<MesherBlockInput> Blocks { get; private set; }

		GeneratableMesh _opaqueCollidedMesh      = null;
		GeneratableMesh _opaquePassableMesh      = null;
		GeneratableMesh _translucentPassableMesh = null;
		Vector3         _originPos               = Vector3.zero;
		ResourceLibrary _library                 = null;
		Task            _currentTask             = null;
		Chunk _targetChunk = null;

		public ChunkMesher(ResourceLibrary library, int chunkMeshCapacity, int capacity, Vector3 originPos) {
			_opaqueCollidedMesh      = new GeneratableMesh(chunkMeshCapacity);
			_translucentPassableMesh = new GeneratableMesh(chunkMeshCapacity / 8);
			_opaquePassableMesh      = new GeneratableMesh(chunkMeshCapacity / 8);
			_library                 = library;
			_originPos               = originPos;
			Blocks                   = new List<MesherBlockInput>(capacity);
		}

		public GeneratableMesh OpaqueCollidedMesh {
			get { return _opaqueCollidedMesh; }
		}

		public GeneratableMesh OpaquePassableMesh {
			get { return _opaquePassableMesh; }
		}

		public GeneratableMesh TranslucentPassableMesh {
			get { return _translucentPassableMesh; }
		}

		public void PrepareMesher() {
			_opaqueCollidedMesh.ClearData();
			_translucentPassableMesh.ClearData();
			_opaquePassableMesh.ClearData();
			Blocks.Clear();
		}

		public void InitData(Chunk data) {
			_targetChunk = data;
		}

		public void DeInit() {
			_opaqueCollidedMesh.Destroy();
			_translucentPassableMesh.Destroy();
			_opaquePassableMesh.Destroy();
		}

		public void StartAsyncMeshing() {
			if ( Busy ) {
				return;
			}
			Busy = true;
			_currentTask = Task.Factory.StartNew(StartMeshing);
		}

		void StartMeshing() {
			Profiler.BeginSample(string.Format("Chunk Meshing of {0} ", _targetChunk));
			Ready = false;
			var stopwatch = System.Diagnostics.Stopwatch.StartNew();
			stopwatch.Start();
			if ( _targetChunk == null ) {
				return;
			}
			_targetChunk.PrepareAsyncMeshing();
			var start = Blocks.Count - 1;
			for ( int i = start; i >= 0 ; i-- ) {
				var blockItem = Blocks[i];
				var rawPos    = blockItem.Position;
				var pos       = _originPos + new Vector3(rawPos.X, rawPos.Y, rawPos.Z);
				var desc      = _library.GetBlockDescription(blockItem.Block.Type);
				if ( desc.IsTranslucent ) {
					BlockModelGenerator.AddBlock(_translucentPassableMesh, desc,ref pos, ref blockItem);
				} else if ( !desc.IsPassable)  {
					BlockModelGenerator.AddBlock(_opaqueCollidedMesh, desc, ref pos, ref blockItem);
				} else {
					BlockModelGenerator.AddBlock(_opaquePassableMesh, desc, ref pos, ref blockItem);
				}
			}
			Ready = true;
			Busy  = false;
			stopwatch.Stop();
			Profiler.EndSample();
			AddTime(stopwatch.Elapsed.TotalMilliseconds);
		}

		public void FinalizeBake() {
			_opaqueCollidedMesh.ClearMesh();
			_translucentPassableMesh.ClearMesh();
			_opaquePassableMesh.ClearMesh();
			_opaqueCollidedMesh.BakeMesh();
			_translucentPassableMesh.BakeMesh();
			_opaquePassableMesh.BakeMesh();

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
