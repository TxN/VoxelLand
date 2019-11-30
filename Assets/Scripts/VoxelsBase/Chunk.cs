using System.Collections.Generic;

using UnityEngine;

using SMGCore.EventSys;
using Voxels.Events;

namespace Voxels {
	public sealed class Chunk {
		public const int CHUNK_SIZE_X                         = 16;
		public const int CHUNK_SIZE_Y                         = 128;
		public const int CHUNK_SIZE_Z                         = 16;
		public const int CHUNK_MESH_CAPACITY                  = 16384;
		public const int MAX_DIRTY_BLOCKS_BEFORE_FULL_REBUILD = 128;
		public const int LIGHT_SOURCES_CAPACITY               = 64;
		public const int LIGHT_FALLOF_VALUE                   = 16;
		public const int MAX_SUNLIGHT_VALUE                   = 255;
		public const int MESHER_CAPACITY                      = 2048;

		public ChunkRenderer Renderer   { get; set; }
		public Vector3 OriginPos        { get; }
		public bool Dirty               { get; private set; } = false;
		public bool NeedRebuildGeometry { get; set; }         = false;
		public Int3 Index {
			get {
				return new Int3(_indexX, _indexY, _indexZ);
			}
		}

		IChunkManager       _owner           = null;
		IChunkMesher        _mesher          = null;
		ResourceLibrary    _library          = null;

		int     _indexX                      = 0;
		int     _indexY                      = 0;
		int     _indexZ                      = 0;
		bool    _needUpdateVisibilityAll     = true;
		int     _maxNonEmptyY                = 0;
		int     _loadedNeighbors             = 0;
		bool    _fullyInited                 = false;

		VisibilityFlagsHolder _visibiltiy      = null;
		BlockDataHolder      _blocks           = null;
		List<Int3>           _dirtyBlocks      = new List<Int3>(MAX_DIRTY_BLOCKS_BEFORE_FULL_REBUILD);
		Queue<Int3>          _lightAddQueue    = new Queue<Int3>        (LIGHT_SOURCES_CAPACITY);
		Queue<LightRemNode>  _lightRemQueue    = new Queue<LightRemNode>(LIGHT_SOURCES_CAPACITY);
		Queue<Int3>          _sunlightAddQueue = new Queue<Int3>        (CHUNK_SIZE_X * CHUNK_SIZE_Y);
		Queue<LightRemNode>  _sunlightRemQueue = new Queue<LightRemNode>(LIGHT_SOURCES_CAPACITY);

		public Chunk(ChunkData data) {
			var b = data.Blocks;
			_visibiltiy   = new VisibilityFlagsHolder(CHUNK_SIZE_X, CHUNK_SIZE_Y, CHUNK_SIZE_Z);
			_blocks       = new BlockDataHolder(b.SizeX, b.SizeY, b.SizeZ, b.Data);
			OriginPos     = data.Origin;
			_indexX       = data.IndexX;
			_indexY       = data.IndexY;
			_indexZ       = data.IndexZ;
			_maxNonEmptyY = data.Height;
		}

		public void FinishInitClientChunk(IChunkManager owner) {
			_owner = owner;
			_library = VoxelsStatic.Instance.Library;
			_mesher = new ChunkMesher(_library, CHUNK_MESH_CAPACITY, MESHER_CAPACITY, OriginPos);
			_loadedNeighbors = _owner.GatherNeighbors(new Int3(_indexX, _indexY, _indexZ));
			if ( _loadedNeighbors == 15 ) {				
				_fullyInited = true;
			}
			ForceUpdateChunk();
		}

		public void FinishInitServerChunk(IChunkManager owner) {
			_owner = owner;
			_library = VoxelsStatic.Instance.Library;
			_mesher = new EmptyChunkMesher();
		}

		public Chunk(IChunkManager owner, ChunkData data, bool isServerChunk) {
			_owner = owner;
			var b = data.Blocks;
			_visibiltiy   = new VisibilityFlagsHolder(CHUNK_SIZE_X, CHUNK_SIZE_Y, CHUNK_SIZE_Z);
			_blocks       = new BlockDataHolder(b.SizeX, b.SizeY, b.SizeZ, b.Data);
			OriginPos     = data.Origin;
			_indexX       = data.IndexX;
			_indexY       = data.IndexY;
			_indexZ       = data.IndexZ;
			_maxNonEmptyY = data.Height;
			_library      = VoxelsStatic.Instance.Library;

			if ( isServerChunk ) {
				_mesher = new EmptyChunkMesher();
			} else {
				_mesher = new ChunkMesher(_library, CHUNK_MESH_CAPACITY, MESHER_CAPACITY, OriginPos);
			}

			_loadedNeighbors = _owner.GatherNeighbors(new Int3(_indexX, _indexY, _indexZ));
			if ( _loadedNeighbors == 15 ) {
				ForceUpdateChunk();
				_fullyInited = true;
			}
		}

		public Chunk(IChunkManager owner, int x, int y, int z, Vector3 originPos, bool isServerChunk) {
			_owner        = owner;
			_visibiltiy   = new VisibilityFlagsHolder(CHUNK_SIZE_X, CHUNK_SIZE_Y, CHUNK_SIZE_Z);
			_blocks       = new BlockDataHolder      (CHUNK_SIZE_X, CHUNK_SIZE_Y, CHUNK_SIZE_Z);
			OriginPos     = originPos;
			_indexX       = x;
			_indexY       = y;
			_indexZ       = z;
			_library      = VoxelsStatic.Instance.Library;

			if ( isServerChunk ) {
				_mesher = new EmptyChunkMesher();
			} else {
				_mesher = new ChunkMesher(_library, CHUNK_MESH_CAPACITY, MESHER_CAPACITY, originPos);
			}

			_loadedNeighbors = _owner.GatherNeighbors(new Int3(_indexX, _indexY, _indexZ));
			if ( _loadedNeighbors == 15 ) {
				ForceUpdateChunk();
				_fullyInited = true;
			}
		}

		public ChunkData GetData() {
			return new ChunkData() { Blocks = _blocks, Height = (byte)_maxNonEmptyY, IndexX = _indexX, IndexY = _indexY, IndexZ = _indexZ, Origin = OriginPos };
		}

		public void SetAllBlocks(BlockData[] blocks, int maxY) {
			_maxNonEmptyY = maxY;
			_blocks.Data = blocks;
			InitSunlight();
		}

		public bool MesherWorkComplete {
			get {
				return _mesher.Ready;
			}
		}

		public GeneratableMesh OpaqueCollidedMesh {
			get {
				return _mesher.OpaqueCollidedMesh;
			}
		}

		public GeneratableMesh OpaquePassableMesh {
			get {
				return _mesher.OpaquePassableMesh;
			}
		}

		public GeneratableMesh TranslucentPassableMesh {
			get {
				return _mesher.TranslucentPassableMesh;
			}
		}

		public float GetDistance(Vector3 pos) {
			pos.y = 0;
			return Vector3.Distance(pos, OriginPos);
		}

		public void OnChunkLoaded(Int3 loadedChunk) {
			if ( _fullyInited ) {
				return;
			}
			_loadedNeighbors |= IsNeighbor(loadedChunk);
			if ( _loadedNeighbors == 15 ) {
				ForceUpdateChunk();
				_fullyInited = true;
			}
		}

		int IsNeighbor(Int3 coords) {
			var x = coords.X;
			var y = coords.Y;
			var z = coords.Z;
			if ( x == _indexX && _indexZ + 1 == z ) {
				return 1;
			}
			if ( x == _indexX && _indexZ - 1 == z ) {
				return 2;
			}
			if ( _indexX + 1 == x && z == _indexZ ) {
				return 4;
			}
			if ( _indexX - 1 == x && z == _indexZ ) {
				return 8;
			}
			return 0;
		}

		public void UnloadChunk() {
			Renderer = null;
			_mesher.DeInit();
		}

		#region LightCalculation

		public void EnqueueToLightAdd(Int3 node) {
			Dirty = true;
			_lightAddQueue.Enqueue(node);
		}

		public void EnqueueToLightRem(LightRemNode node) {
			Dirty = true;
			_lightRemQueue.Enqueue(node);
		}

		public void EnqueueToSunlightAdd(Int3 node) {
			Dirty = true;
			_sunlightAddQueue.Enqueue(node);
		}

		public void EnqueueToSunlightRem(LightRemNode node) {
			Dirty = true;
			_sunlightRemQueue.Enqueue(node);
		}

		public void InitSunlight() {
			_sunlightAddQueue.Clear();
			_sunlightRemQueue.Clear();
			
			for ( int x = 0; x < CHUNK_SIZE_X; x++ ) {
				for ( int z = 0; z < CHUNK_SIZE_Z; z++ ) {					
					var block = _blocks[x, _maxNonEmptyY, z];
					block.SunLevel = MAX_SUNLIGHT_VALUE;
					_blocks[x, _maxNonEmptyY, z] = block;
					_sunlightAddQueue.Enqueue(new Int3(x, _maxNonEmptyY, z));
				}
			}
		}

		public void UpdateLightLevel() {
			if ( _sunlightAddQueue.Count == 0 && _sunlightRemQueue.Count == 0 && _lightAddQueue.Count == 0 && _lightRemQueue.Count == 0 ) {
				return;
			}
			var neighbors = GetNeighborChunks();
			NeedRebuildGeometry = true;

			while (_sunlightRemQueue.Count > 0 ) {
				var elem = _sunlightRemQueue.Dequeue();
				PropagateSunDarknessToNeighbors(neighbors, elem);
			}

			while (_sunlightAddQueue.Count > 0 ) {
				var elem = _sunlightAddQueue.Dequeue();
				PropagateSunLightToNeighbors(neighbors, elem);
			}


			while (_lightRemQueue.Count > 0 ) {
				var elem = _lightRemQueue.Dequeue();
				PropagateDarknessToNeighbors(neighbors, elem);
			}

			while ( _lightAddQueue.Count > 0 ) {
				var elem = _lightAddQueue.Dequeue();
				PropagateLightToNeighbors(neighbors, elem);
			}
		}

		void PropagateDarknessToNeighbors(Chunk[] neighborChunks, LightRemNode pos) {
			var x = pos.X;
			var y = pos.Y;
			var z = pos.Z;
			var l = pos.Light;
			//Up
			if ( y < CHUNK_SIZE_Y - 1 ) {
				if ( !HasFullOpaqueBlockAt(x, y + 1, z) ) {
					var blockLight = _blocks[x, y + 1, z].LightLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block = _blocks[x, y + 1, z];
						block.LightLevel = 0;
						_blocks[x, y + 1, z] = block;
						_lightRemQueue.Enqueue(new LightRemNode(x, y + 1, z, blockLight));
					} else if ( blockLight >= l ) {
						_lightAddQueue.Enqueue(new Int3(x, y + 1, z));
					}
				}
			} else {
				var chunk = neighborChunks[0];
				if ( chunk != null && !chunk.HasFullOpaqueBlockAt(x, 0, z) ) {
					var blockLight = chunk._blocks[x, 0, z].LightLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block = chunk._blocks[x, 0, z];
						block.LightLevel = 0;
						chunk._blocks[x, 0, z] = block;
						chunk.EnqueueToLightRem(new LightRemNode(x, 0, z, blockLight));
					} else if ( blockLight >= l ) {
						chunk.EnqueueToLightAdd(new Int3(x, 0, z));
					}
				}
			}
			//Down
			if ( y > 0 ) {
				if ( !HasFullOpaqueBlockAt(x, y - 1, z) ) {
					var blockLight = _blocks[x, y - 1, z].LightLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block = _blocks[x, y - 1, z];
						block.LightLevel = 0;
						_blocks[x, y - 1, z] = block;
						_lightRemQueue.Enqueue(new LightRemNode(x, y - 1, z, blockLight));
					} else if ( blockLight >= l ) {
						_lightAddQueue.Enqueue(new Int3(x, y - 1, z));
					}
				}
			}
			//Right
			if ( x < CHUNK_SIZE_X - 1 ) {
				if ( !HasFullOpaqueBlockAt(x + 1, y, z) ) {
					var blockLight = _blocks[x + 1, y, z].LightLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block = _blocks[x + 1, y, z];
						block.LightLevel = 0;
						_blocks[x + 1, y, z] = block;
						_lightRemQueue.Enqueue(new LightRemNode(x + 1, y, z, blockLight));
					} else if ( blockLight >= l ) {
						_lightAddQueue.Enqueue(new Int3(x + 1, y, z));
					}
				}
			} else {
				var chunk = neighborChunks[2];
				if ( chunk != null && !chunk.HasFullOpaqueBlockAt(0, y, z) ) {
					var blockLight = chunk._blocks[0, y, z].LightLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block = chunk._blocks[0, y, z];
						block.LightLevel = 0;
						chunk._blocks[0, y, z] = block;
						chunk.EnqueueToLightRem(new LightRemNode(0, y, z, blockLight));
					} else if ( blockLight >= l ) {
						chunk.EnqueueToLightAdd(new Int3(0, y, z));
					}
				}
			}
			//Left
			if ( x > 0 ) {
				if ( !HasFullOpaqueBlockAt(x - 1, y, z) ) {
					var blockLight = _blocks[x - 1, y, z].LightLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block = _blocks[x - 1, y, z];
						block.LightLevel = 0;
						_blocks[x - 1, y, z] = block;
						_lightRemQueue.Enqueue(new LightRemNode(x - 1, y, z, blockLight));
					} else if ( blockLight >= l ) {
						_lightAddQueue.Enqueue(new Int3(x - 1, y, z));
					}
				}
			} else {
				var chunk = neighborChunks[3];
				if ( chunk != null && !chunk.HasFullOpaqueBlockAt(CHUNK_SIZE_X - 1, y, z) ) {
					var blockLight = chunk._blocks[CHUNK_SIZE_X - 1, y, z].LightLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block = chunk._blocks[CHUNK_SIZE_X - 1, y, z];
						block.LightLevel = 0;
						chunk._blocks[CHUNK_SIZE_X - 1, y, z] = block;
						chunk.EnqueueToLightRem(new LightRemNode(CHUNK_SIZE_X - 1, y, z, blockLight));
					} else if ( blockLight >= l ) {
						chunk.EnqueueToLightAdd(new Int3(CHUNK_SIZE_X - 1, y, z));
					}
				}
			}
			//Forward
			if ( z < CHUNK_SIZE_Z - 1 ) {
				if ( !HasFullOpaqueBlockAt(x, y, z + 1) ) {
					var blockLight = _blocks[x, y, z + 1].LightLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block = _blocks[x, y, z + 1];
						block.LightLevel = 0;
						_blocks[x, y, z + 1] = block;
						_lightRemQueue.Enqueue(new LightRemNode(x, y, z + 1, blockLight));
					} else if ( blockLight >= l ) {
						_lightAddQueue.Enqueue(new Int3(x, y, z + 1));
					}
				}
			} else {
				var chunk = neighborChunks[4];
				if ( chunk != null && !chunk.HasFullOpaqueBlockAt(x, y, 0) ) {
					var blockLight = chunk._blocks[x, y, 0].LightLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block = chunk._blocks[x, y, 0];
						block.LightLevel = 0;
						chunk._blocks[x, y, 0] = block;
						chunk.EnqueueToLightRem(new LightRemNode(x, y, 0, blockLight));
					} else if ( blockLight >= l ) {
						chunk.EnqueueToLightAdd(new Int3(x, y, 0));
					}
				}
			}
			//Backwards
			if ( z > 0 ) {
				if ( !HasFullOpaqueBlockAt(x, y, z - 1) ) {
					var blockLight = _blocks[x, y, z - 1].LightLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block = _blocks[x, y, z - 1];
						block.LightLevel = 0;
						_blocks[x, y, z - 1] = block;
						_lightRemQueue.Enqueue(new LightRemNode(x, y, z - 1, blockLight));
					} else if ( blockLight >= l ) {
						_lightAddQueue.Enqueue(new Int3(x, y, z - 1));
					}
				}
			} else {
				var chunk = neighborChunks[5];
				if ( chunk != null && !chunk.HasFullOpaqueBlockAt(x, y, CHUNK_SIZE_Z - 1) ) {
					var blockLight = chunk._blocks[x, y, CHUNK_SIZE_Z - 1].LightLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block = chunk._blocks[x, y, CHUNK_SIZE_Z - 1];
						block.LightLevel = 0;
						chunk._blocks[x, y, CHUNK_SIZE_Z - 1] = block;
						chunk.EnqueueToLightRem(new LightRemNode(x, y, CHUNK_SIZE_Z - 1, blockLight));
					} else if ( blockLight >= l ) {
						chunk.EnqueueToLightAdd(new Int3(x, y, CHUNK_SIZE_Z - 1));
					}
				}
			}
		}

		void PropagateLightToNeighbors(Chunk[] neighborChunks, Int3 pos) {
			var x = pos.X;
			var y = pos.Y;
			var z = pos.Z;
			var oLight   = _blocks[x, y, z].LightLevel;
			var l = (byte) Mathf.Clamp(oLight - LIGHT_FALLOF_VALUE, 0, 255);
			if ( l == 0 ) {
				return;
			}
			//Up
			if ( y < CHUNK_SIZE_Y - 1 ) {
				if ( !HasFullOpaqueBlockAt(x, y+1,z) ) {
					var blockLight = _blocks[x, y + 1, z].LightLevel;
					if ( l > blockLight ) {
						var block = _blocks[x, y + 1, z];
						block.LightLevel = l;
						_blocks[x, y + 1, z] = block;
						_lightAddQueue.Enqueue(new Int3(x, y + 1, z));
					}
				}
			} else {
				var chunk = neighborChunks[0];
				if ( chunk != null  && !chunk.HasFullOpaqueBlockAt(x, 0, z)) {
					var blockLight = chunk._blocks[x, 0, z].LightLevel;
					if ( l > blockLight ) {
						var block = chunk._blocks[x, 0, z];
						block.LightLevel = l;
						chunk._blocks[x, 0, z] = block;
						chunk.EnqueueToLightAdd(new Int3(x, 0, z));
					}	
				}
			}
			//Down
			if ( y > 0 ) {
				if ( !HasFullOpaqueBlockAt(x, y - 1, z) ) {
					var blockLight = _blocks[x, y - 1, z].LightLevel;
					if ( l > blockLight ) {
						var block = _blocks[x, y - 1, z];
						block.LightLevel = l;
						_blocks[x, y - 1, z] = block;
						_lightAddQueue.Enqueue(new Int3(x, y - 1, z));
					}
				}
			}
			//Right
			if ( x < CHUNK_SIZE_X - 1 ) {
				if ( !HasFullOpaqueBlockAt(x + 1, y, z) ) {
					var blockLight = _blocks[x + 1, y, z].LightLevel;
					if (l > blockLight ) {
						var block = _blocks[x + 1, y, z];
						block.LightLevel = l;
						_blocks[x + 1, y, z] = block;
						_lightAddQueue.Enqueue(new Int3(x + 1, y, z));
					}
				}
			} else {
				var chunk = neighborChunks[2];
				if ( chunk != null && !chunk.HasFullOpaqueBlockAt(0, y, z) ) {
					var blockLight = chunk._blocks[0, y, z].LightLevel;
					if ( l> blockLight ) {
						var block = chunk._blocks[0, y, z];
						block.LightLevel = l;
						chunk._blocks[0, y, z] = block;
						chunk.EnqueueToLightAdd(new Int3(0, y, z));
					}
				}
			}
			//Left
			if ( x > 0 ) {
				if ( !HasFullOpaqueBlockAt(x - 1, y, z) ) {
					var blockLight = _blocks[x - 1, y, z].LightLevel;
					if ( l > blockLight ) {
						var block = _blocks[x - 1, y, z];
						block.LightLevel = l;
						_blocks[x - 1, y, z] = block;
						_lightAddQueue.Enqueue(new Int3(x - 1, y, z));
					}
				}
			} else {
				var chunk = neighborChunks[3];
				if ( chunk != null && !chunk.HasFullOpaqueBlockAt(CHUNK_SIZE_X - 1, y, z) ) {
					var blockLight = chunk._blocks[CHUNK_SIZE_X - 1, y, z].LightLevel;
					if ( l > blockLight ) {
						var block = chunk._blocks[CHUNK_SIZE_X - 1, y, z];
						block.LightLevel = l;
						chunk._blocks[CHUNK_SIZE_X - 1, y, z] = block;
						chunk.EnqueueToLightAdd(new Int3(CHUNK_SIZE_X - 1, y, z));
					}
				}
			}
			//Forward
			if ( z < CHUNK_SIZE_Z - 1 ) {
				if ( !HasFullOpaqueBlockAt(x, y, z + 1) ) {
					var blockLight = _blocks[x, y, z + 1].LightLevel;
					if ( l > blockLight ) {
						var block = _blocks[x, y, z + 1];
						block.LightLevel = l;
						_blocks[x, y, z + 1] = block;
						_lightAddQueue.Enqueue(new Int3(x, y, z + 1));
					}
				}
			} else {
				var chunk = neighborChunks[4];
				if ( chunk != null && !chunk.HasFullOpaqueBlockAt(x, y, 0) ) {
					var blockLight = chunk._blocks[x, y, 0].LightLevel;
					if ( l > blockLight ) {
						var block = chunk._blocks[x, y, 0];
						block.LightLevel = l;
						chunk._blocks[x, y, 0] = block;
						chunk.EnqueueToLightAdd(new Int3(x, y, 0));
					}	
				}
			}
			//Backwards
			if ( z > 0 ) {
				if ( !HasFullOpaqueBlockAt(x, y, z - 1) ) {
					var blockLight = _blocks[x, y, z - 1].LightLevel;
					if ( l > blockLight ) {
						var block = _blocks[x, y, z - 1];
						block.LightLevel = l;
						_blocks[x, y, z - 1] = block;
						_lightAddQueue.Enqueue(new Int3(x, y, z - 1));
					}
				}
			} else {
				var chunk = neighborChunks[5];
				if ( chunk != null && !chunk.HasFullOpaqueBlockAt(x, y, CHUNK_SIZE_Z - 1) ) {
					var blockLight = chunk._blocks[x, y, CHUNK_SIZE_Z - 1].LightLevel;
					if ( l > blockLight ) {
						var block = chunk._blocks[x, y, CHUNK_SIZE_Z - 1];
						block.LightLevel = l;
						chunk._blocks[x, y, CHUNK_SIZE_Z - 1] = block;
						chunk.EnqueueToLightAdd(new Int3(x, y, CHUNK_SIZE_Z - 1));
					}
				}
			}
		}

		void PropagateSunLightToNeighbors(Chunk[] neighborChunks, Int3 pos) {
			var x = pos.X;
			var y = pos.Y;
			var z = pos.Z;
			var oLight = _blocks[x, y, z].SunLevel;
			var l = (byte)Mathf.Clamp(oLight - LIGHT_FALLOF_VALUE, 0, 255);
			if ( l == 0 ) {
				return;
			}
			//Up
			if ( y < CHUNK_SIZE_Y - 1 ) {
				if ( _library.IsLightPassBlock(_blocks[x, y + 1, z].Type) ) {
					var blockLight = _blocks[x, y + 1, z].SunLevel;
					if ( l > blockLight ) {
						var block = _blocks[x, y + 1, z];
						block.SunLevel = l;
						_blocks[x, y + 1, z] = block;
						_sunlightAddQueue.Enqueue(new Int3(x, y + 1, z));
					}
				}
			} else {
				var chunk = neighborChunks[0];
				if ( chunk != null && _library.IsLightPassBlock(chunk._blocks[x, 0, z].Type) ) {
					var blockLight = chunk._blocks[x, 0, z].SunLevel;
					if ( l > blockLight ) {
						var block = chunk._blocks[x, 0, z];
						block.SunLevel = l;
						chunk._blocks[x, 0, z] = block;
						chunk.EnqueueToSunlightAdd(new Int3(x, 0, z));
					}
				}
			}
			//Down
			if ( y > 0 ) {
				if ( _library.IsLightPassBlock(_blocks[x, y - 1, z].Type) ) {
					var blockLight = _blocks[x, y - 1, z].SunLevel;
					if ( l > blockLight ) {
						var nLight = oLight == MAX_SUNLIGHT_VALUE ? oLight : l;
						var block = _blocks[x, y - 1, z];
						block.SunLevel = nLight;
						_blocks[x, y - 1, z] = block;
						_sunlightAddQueue.Enqueue(new Int3(x, y - 1, z));
					}
				}
			}
			//Right
			if ( x < CHUNK_SIZE_X - 1 ) {
				if ( _library.IsLightPassBlock(_blocks[x + 1, y, z].Type) ) {
					var blockLight = _blocks[x + 1, y, z].SunLevel;
					if ( l > blockLight ) {

						var block = _blocks[x + 1, y, z];
						block.SunLevel = l;
						_blocks[x + 1, y, z] = block;
						_sunlightAddQueue.Enqueue(new Int3(x + 1, y, z));
					}
				}
			} else {
				var chunk = neighborChunks[2];
				if ( chunk != null && _library.IsLightPassBlock(chunk._blocks[0, y, z].Type) ) {
					var blockLight = chunk._blocks[0, y, z].SunLevel;
					if ( l > blockLight ) {
						var block = chunk._blocks[0, y, z];
						block.SunLevel = l;
						chunk._blocks[0, y, z] = block;
						chunk.EnqueueToSunlightAdd(new Int3(0, y, z));
					}
				}
			}
			//Left
			if ( x > 0 ) {
				if ( _library.IsLightPassBlock(_blocks[x - 1, y, z].Type) ) {
					var blockLight = _blocks[x - 1, y, z].SunLevel;
					if ( l > blockLight ) {
						var block =_blocks[x - 1, y, z];
						block.SunLevel = l;
						_blocks[x - 1, y, z] = block;
						_sunlightAddQueue.Enqueue(new Int3(x - 1, y, z));
					}
				}
			} else {
				var chunk = neighborChunks[3];
				if ( chunk != null && _library.IsLightPassBlock(chunk._blocks[CHUNK_SIZE_X - 1, y, z].Type) ) {
					var blockLight = chunk._blocks[CHUNK_SIZE_X - 1, y, z].SunLevel;
					if ( l > blockLight ) {
						var block = chunk._blocks[CHUNK_SIZE_X - 1, y, z];
						block.SunLevel = l;
						chunk._blocks[CHUNK_SIZE_X - 1, y, z] = block;
						chunk.EnqueueToSunlightAdd(new Int3(CHUNK_SIZE_X - 1, y, z));
					}
				}
			}
			//Forward
			if ( z < CHUNK_SIZE_Z - 1 ) {
				if ( _library.IsLightPassBlock(_blocks[x, y, z + 1].Type) ) {
					var blockLight = _blocks[x, y, z + 1].SunLevel;
					if ( l > blockLight ) {
						var block = _blocks[x, y, z + 1];
						block.SunLevel = l;
						_blocks[x, y, z + 1] = block;
						_sunlightAddQueue.Enqueue(new Int3(x, y, z + 1));
					}
				}
			} else {
				var chunk = neighborChunks[4];
				if ( chunk != null && _library.IsLightPassBlock(chunk._blocks[x, y, 0].Type) ) {
					var blockLight = chunk._blocks[x, y, 0].SunLevel;
					if ( l > blockLight ) {
						var block = chunk._blocks[x, y, 0];
						block.SunLevel = l;
						chunk._blocks[x, y, 0] = block;
						chunk.EnqueueToSunlightAdd(new Int3(x, y, 0));
					}
				}
			}
			//Backwards
			if ( z > 0 ) {
				if ( _library.IsLightPassBlock(_blocks[x, y, z - 1].Type) ) {
					var blockLight = _blocks[x, y, z - 1].SunLevel;
					if ( l > blockLight ) {
						var block =_blocks[x, y, z - 1];
						block.SunLevel = l;
						_blocks[x, y, z - 1] = block;
						_sunlightAddQueue.Enqueue(new Int3(x, y, z - 1));
					}
				}
			} else {
				var chunk = neighborChunks[5];
				if ( chunk != null && _library.IsLightPassBlock(chunk._blocks[x, y, CHUNK_SIZE_Z - 1].Type) ) {
					var blockLight = chunk._blocks[x, y, CHUNK_SIZE_Z - 1].SunLevel;
					if ( l > blockLight ) {
						var block = chunk._blocks[x, y, CHUNK_SIZE_Z - 1];
						block.SunLevel = l;
						chunk._blocks[x, y, CHUNK_SIZE_Z - 1] = block;
						chunk.EnqueueToSunlightAdd(new Int3(x, y, CHUNK_SIZE_Z - 1));
					}
				}
			}
		}

		void PropagateSunDarknessToNeighbors(Chunk[] neighborChunks, LightRemNode pos) {
			var x = pos.X;
			var y = pos.Y;
			var z = pos.Z;
			var l = pos.Light;
			//Up
			if ( y < CHUNK_SIZE_Y - 1 ) {
				if ( !HasFullOpaqueBlockAt(x, y + 1, z) ) {
					var blockLight = _blocks[x, y + 1, z].SunLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block = _blocks[x, y + 1, z];
						block.SunLevel = 0;
						_blocks[x, y + 1, z] = block;
						_sunlightRemQueue.Enqueue(new LightRemNode(x, y + 1, z, blockLight));
					}
					else if ( blockLight >= l ) {
						_sunlightAddQueue.Enqueue(new Int3(x, y + 1, z));
					}
				}
			} else {
				var chunk = neighborChunks[0];
				if ( chunk != null && !chunk.HasFullOpaqueBlockAt(x, 0, z) ) {
					var blockLight = chunk._blocks[x, 0, z].SunLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block = chunk._blocks[x, 0, z];
						block.SunLevel = 0;
						chunk._blocks[x, 0, z] = block;
						chunk.EnqueueToSunlightRem(new LightRemNode(x, 0, z, blockLight));
					}
					else if ( blockLight >= l ) {
						chunk.EnqueueToSunlightAdd(new Int3(x, 0, z));
					}
				}
			}
			//Down
			if ( y > 0 ) {
				if ( !HasFullOpaqueBlockAt(x, y - 1, z) ) {
					var blockLight = _blocks[x, y - 1, z].SunLevel;
					if ( blockLight > 0 && blockLight < l  || blockLight == MAX_SUNLIGHT_VALUE ) {
						var block = _blocks[x, y - 1, z];
						block.SunLevel = 0;
						_blocks[x, y - 1, z] = block;
						_sunlightRemQueue.Enqueue(new LightRemNode(x, y - 1, z, blockLight));
					}
					else if ( blockLight >= l ) {
						_sunlightAddQueue.Enqueue(new Int3(x, y - 1, z));
					}
				}
			}
			//Right
			if ( x < CHUNK_SIZE_X - 1 ) {
				if ( !HasFullOpaqueBlockAt(x + 1, y, z) ) {
					var blockLight = _blocks[x + 1, y, z].SunLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block =_blocks[x + 1, y, z];
						block.SunLevel = 0;
						_blocks[x + 1, y, z] = block;
						_sunlightRemQueue.Enqueue(new LightRemNode(x + 1, y, z, blockLight));
					}
					else if ( blockLight >= l ) {
						_sunlightAddQueue.Enqueue(new Int3(x + 1, y, z));
					}
				}
			} else {
				var chunk = neighborChunks[2];
				if ( chunk != null && !chunk.HasFullOpaqueBlockAt(0, y, z) ) {
					var blockLight = chunk._blocks[0, y, z].SunLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block = chunk._blocks[0, y, z];
						block.SunLevel = 0;
						chunk._blocks[0, y, z] = block;
						chunk.EnqueueToSunlightRem(new LightRemNode(0, y, z, blockLight));
					}
					else if ( blockLight >= l ) {
						chunk.EnqueueToSunlightAdd(new Int3(0, y, z));
					}
				}
			}
			//Left
			if ( x > 0 ) {
				if ( !HasFullOpaqueBlockAt(x - 1, y, z) ) {
					var blockLight = _blocks[x - 1, y, z].SunLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block = _blocks[x - 1, y, z];
						block.SunLevel = 0;
						_blocks[x - 1, y, z] = block;
						_sunlightRemQueue.Enqueue(new LightRemNode(x - 1, y, z, blockLight));
					}
					else if ( blockLight >= l ) {
						_sunlightAddQueue.Enqueue(new Int3(x - 1, y, z));
					}
				}
			} else {
				var chunk = neighborChunks[3];
				if ( chunk != null && !chunk.HasFullOpaqueBlockAt(CHUNK_SIZE_X - 1, y, z) ) {
					var blockLight = chunk._blocks[CHUNK_SIZE_X - 1, y, z].SunLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block = chunk._blocks[CHUNK_SIZE_X - 1, y, z];
						block.SunLevel = 0;
						chunk._blocks[CHUNK_SIZE_X - 1, y, z] = block;
						chunk.EnqueueToSunlightRem(new LightRemNode(CHUNK_SIZE_X - 1, y, z, blockLight));
					}
					else if ( blockLight >= l ) {
						chunk.EnqueueToSunlightAdd(new Int3(CHUNK_SIZE_X - 1, y, z));
					}
				}
			}
			//Forward
			if ( z < CHUNK_SIZE_Z - 1 ) {
				if ( !HasFullOpaqueBlockAt(x, y, z + 1) ) {
					var blockLight = _blocks[x, y, z + 1].SunLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block =_blocks[x, y, z + 1];
						block.SunLevel = 0;
						_blocks[x, y, z + 1] = block;
						_sunlightRemQueue.Enqueue(new LightRemNode(x, y, z + 1, blockLight));
					}
					else if ( blockLight >= l ) {
						_sunlightAddQueue.Enqueue(new Int3(x, y, z + 1));
					}
				}
			} else {
				var chunk = neighborChunks[4];
				if ( chunk != null && !chunk.HasFullOpaqueBlockAt(x, y, 0) ) {
					var blockLight = chunk._blocks[x, y, 0].SunLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block = chunk._blocks[x, y, 0];
						block.SunLevel = 0;
						chunk._blocks[x, y, 0] = block;
						chunk.EnqueueToSunlightRem(new LightRemNode(x, y, 0, blockLight));
					}
					else if ( blockLight >= l ) {
						chunk.EnqueueToSunlightAdd(new Int3(x, y, 0));
					}
				}
			}
			//Backwards
			if ( z > 0 ) {
				if ( !HasFullOpaqueBlockAt(x, y, z - 1) ) {
					var blockLight = _blocks[x, y, z - 1].SunLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block = _blocks[x, y, z - 1];
						block.SunLevel = 0;
						_sunlightRemQueue.Enqueue(new LightRemNode(x, y, z - 1, blockLight));
					}
					else if ( blockLight >= l ) {
						_sunlightAddQueue.Enqueue(new Int3(x, y, z - 1));
					}
				}
			} else {
				var chunk = neighborChunks[5];
				if ( chunk != null && !chunk.HasFullOpaqueBlockAt(x, y, CHUNK_SIZE_Z - 1) ) {
					var blockLight = chunk._blocks[x, y, CHUNK_SIZE_Z - 1].SunLevel;
					if ( blockLight > 0 && blockLight < l ) {
						var block = chunk._blocks[x, y, CHUNK_SIZE_Z - 1];
						block.SunLevel = 0;
						chunk._blocks[x, y, CHUNK_SIZE_Z - 1] = block;
						chunk.EnqueueToSunlightRem(new LightRemNode(x, y, CHUNK_SIZE_Z - 1, blockLight));
					}
					else if ( blockLight >= l ) {
						chunk.EnqueueToSunlightAdd(new Int3(x, y, CHUNK_SIZE_Z - 1));
					}
				}
			}
		}

		#endregion

		public void UpdateGeometry() {
			if ( _mesher.Busy ) {
				return;
			}
			_mesher.PrepareMesher();
			var neighbors = GetNeighborChunks();
			var blockList = _mesher.Blocks;
			if ( blockList == null ) {
				NeedRebuildGeometry = false;
				return;
			}

			var maxVal = (_maxNonEmptyY + 1) * CHUNK_SIZE_X * CHUNK_SIZE_Z;
			var divY = CHUNK_SIZE_X * CHUNK_SIZE_Z;
			var divz = CHUNK_SIZE_X;
			for ( int i = 0; i < maxVal; i++ ) {
				var block = _blocks[i];
				if ( block.IsEmpty() || _visibiltiy[i] == VisibilityFlags.None ) {
					continue;
				}
				var y = i / divY;
				var t = i % divY;
				var z = t / divz;
				var x = t % divz;
				blockList.Add(new MesherBlockInput() {
					Block = block,
					Position = new Byte3(x, y, z),
					Lighting = GetLightForBlock(x, y, z, neighbors),
					Visibility = _visibiltiy[i]
				});
			}
			_mesher.StartAsyncMeshing();
			NeedRebuildGeometry = false;
		}

		public void FinalizeMeshUpdate() {
			_mesher.FinalizeBake();
			EventManager.Fire(new Event_ChunkMeshUpdate() { UpdatedChunk = this });
		}

		public void UpdateVisibilityAll() {
			_dirtyBlocks.Clear();
			_needUpdateVisibilityAll = false;
			if ( _mesher is EmptyChunkMesher ) {
				return;
			}
			NeedRebuildGeometry = true;
			var neighbors = GetNeighborChunks();

			var maxVal = (_maxNonEmptyY + 1) * CHUNK_SIZE_X * CHUNK_SIZE_Z;
			var divY = CHUNK_SIZE_X * CHUNK_SIZE_Z;
			var divz = CHUNK_SIZE_X;
			for ( int i = 0; i < maxVal; i++ ) {
				if ( _blocks[i].IsEmpty() ) {
					_visibiltiy[i] = VisibilityFlags.None;
					continue;
				}
				var y = i / divY;
				var t = i % divY;
				var z = t / divz;
				var x = t % divz;
				_visibiltiy[i] = _library.IsTranslucentBlock(_blocks[i].Type) ? CheckVisibilityTranslucent(x, y, z, neighbors) : CheckVisibilityOpaque(x, y, z, neighbors);
			}
		}

		public void UpdateChunk() {
			UpdateVisibilityForDirtyBlocks();
			UpdateLightLevel();
		}

		public void ForceUpdateChunk() {
			_needUpdateVisibilityAll = true;
			UpdateChunk();
		}

		public void UpdateVisibilityForDirtyBlocks() {
			if ( _needUpdateVisibilityAll ) {
				UpdateVisibilityAll();
			} else {
				var neighbors = GetNeighborChunks();
				foreach ( var block in _dirtyBlocks ) {
					UpdateVisibilityForNeighbors(block.X, block.Y, block.Z, neighbors);
				}
			}
			_dirtyBlocks.Clear();
			Dirty = false;
			NeedRebuildGeometry = true;
		}

		#region VisibilityCalculation
		public void UpdateVisibilityForNeighbors(int x, int y, int z, Chunk[] neighborChunks) {
			UpdateVisibilityAtBlock(x, y, z); // self
			//Up
			if ( y < CHUNK_SIZE_Y - 1 ) {
				UpdateVisibilityAtBlock(x, y + 1, z);
			} else {
				var chunk = neighborChunks[0];
				if ( chunk != null ) {
					chunk.UpdateVisibilityAtBlockAndSetDirty(x, 0, z);
				}
			}
			//Down
			if ( y > 0 ) {
				UpdateVisibilityAtBlock(x, y - 1, z);
			} else {
				var chunk = neighborChunks[1];
				if ( chunk != null ) {
					chunk.UpdateVisibilityAtBlockAndSetDirty(x, CHUNK_SIZE_Y - 1, z);
				}
			}
			//Right
			if ( x < CHUNK_SIZE_X - 1 ) {
				UpdateVisibilityAtBlock(x + 1, y, z);
			} else {
				var chunk = neighborChunks[2];
				if ( chunk != null ) {
					chunk.UpdateVisibilityAtBlockAndSetDirty(0, y, z);
				}
			}
			//Left
			if ( x > 0 ) {
				UpdateVisibilityAtBlock(x - 1, y, z);
			} else {
				var chunk = neighborChunks[3];
				if ( chunk != null ) {
					chunk.UpdateVisibilityAtBlockAndSetDirty(CHUNK_SIZE_X - 1, y, z);
				}
			}
			//Forward
			if ( z < CHUNK_SIZE_Z - 1 ) {
				UpdateVisibilityAtBlock(x, y, z + 1);
			} else {
				var chunk = neighborChunks[4];
				if ( chunk != null ) {
					chunk.UpdateVisibilityAtBlockAndSetDirty(x, y, 0);
				}
			}
			//Backwards
			if ( z > 0 ) {
				UpdateVisibilityAtBlock(x, y, z - 1);
			} else {
				var chunk = neighborChunks[5];
				if ( chunk != null ) {
					chunk.UpdateVisibilityAtBlockAndSetDirty(x, y, CHUNK_SIZE_Z - 1);
				}
			}
		}

		void UpdateVisibilityAtBlockAndSetDirty(int x, int y, int z) {
			var prevFlag = _visibiltiy[x,y,z];
			UpdateVisibilityAtBlock(x, y, z);
			if ( prevFlag != _visibiltiy[x,y,z] ) {
				AddDirtyBlock(x, y, z);
			}
		}

		void UpdateVisibilityAtBlock(int x, int y, int z) {
			var block = _blocks[x,y,z];
			if ( block.IsEmpty() ) {
				_visibiltiy[x, y, z] = VisibilityFlags.None;
				return;
			}
			var neighbors = GetNeighborChunks();
			_visibiltiy[x, y, z] = GetBlockTranslucent(block.Type) ? CheckVisibilityTranslucent(x, y, z, neighbors) : CheckVisibilityOpaque(x, y, z, neighbors);			
		}

		VisibilityFlags CheckVisibilityOpaque(int x, int y, int z, Chunk[] neighborChunks) {
			var flag = VisibilityFlags.None;
			//Up
			if ( y < CHUNK_SIZE_Y - 1 ) {
				if ( _library.IsLightPassBlock(_blocks[x, y  + 1, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Up);
				}				
			}
			//Down
			if ( y > 0 ) {
				if ( _library.IsLightPassBlock(_blocks[x, y - 1, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Down);
				}
			}
			//Right
			if ( x < CHUNK_SIZE_X - 1 ) {
				if ( _library.IsLightPassBlock(_blocks[x + 1, y, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Right);
				}
			} else {
				var chunk = neighborChunks[2];
				if ( chunk == null || _library.IsLightPassBlock(chunk._blocks[0, y, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Right);
				}
			}
			//Left
			if ( x > 0 ) {
				if ( _library.IsLightPassBlock(_blocks[x - 1, y, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Left);
				}
			} else {
				var chunk = neighborChunks[3];
				if ( chunk == null || _library.IsLightPassBlock(chunk._blocks[CHUNK_SIZE_X - 1, y, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Left);
				}
			}
			//Forward
			if ( z < CHUNK_SIZE_Z - 1 ) {
				if ( _library.IsLightPassBlock(_blocks[x, y, z + 1].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Forward);
				}
			} else {
				var chunk = neighborChunks[4];
				if ( chunk == null || _library.IsLightPassBlock(chunk._blocks[x, y, 0].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Forward);
				}
			}
			//Backwards
			if ( z > 0 ) {
				if ( _library.IsLightPassBlock(_blocks[x, y, z - 1].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Backward);
				}
			} else {
				var chunk = neighborChunks[5];
				if ( chunk == null || _library.IsLightPassBlock(chunk._blocks[x, y, CHUNK_SIZE_Z -1].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Backward);
				}
			}
			return flag;
		}

		VisibilityFlags CheckVisibilityTranslucent(int x, int y, int z, Chunk[] neighborChunks) {
			var flag = VisibilityFlags.None;
			//Up
			if ( y < CHUNK_SIZE_Y - 1 ) {
				if ( !_library.IsFullBlock(_blocks[x, y + 1, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Up);
				}
			}
			//Down
			if ( y > 0 ) {
				if ( !_library.IsFullBlock(_blocks[x, y - 1, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Down);
				}
			}
			//Right
			if ( x < CHUNK_SIZE_X - 1 ) {
				if ( !_library.IsFullBlock(_blocks[x + 1, y, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Right);
				}
			} else {
				var chunk = neighborChunks[2];
				if ( chunk == null || !_library.IsFullBlock(chunk._blocks[0, y, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Right);
				}
			}
			//Left
			if ( x > 0 ) {
				if ( !_library.IsFullBlock(_blocks[x - 1, y, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Left);
				}
			} else {
				var chunk = neighborChunks[3];
				if ( chunk == null || !_library.IsFullBlock(chunk._blocks[CHUNK_SIZE_X - 1, y, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Left);
				}
			}
			//Forward
			if ( z < CHUNK_SIZE_Z - 1 ) {
				if ( !_library.IsFullBlock(_blocks[x, y, z + 1].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Forward);
				}
			} else {
				var chunk = neighborChunks[4];
				if ( chunk == null || !_library.IsFullBlock(chunk._blocks[x, y, 0].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Forward);
				}
			}
			//Backwards
			if ( z > 0 ) {
				if ( !_library.IsFullBlock(_blocks[x, y, z - 1].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Backward);
				}
			} else {
				var chunk = neighborChunks[5];
				if ( chunk == null || !_library.IsFullBlock(chunk._blocks[x, y, CHUNK_SIZE_Z - 1].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Backward);
				}
			}
			return flag;
		}
		#endregion

		LightInfo GetLightForBlock(int x, int y, int z, Chunk[] neighborChunks) {
			var res = new LightInfo();
			//Up
			if ( y < CHUNK_SIZE_Y - 1 ) {
				var block = _blocks[x, y + 1, z];
				res.SunUp = block.SunLevel;
				res.OUp   = block.LightLevel;
			}
			//Down
			if ( y > 0 ) {
				var block = _blocks[x, y - 1, z];
				res.SunDown = block.SunLevel;
				res.ODown   = block.LightLevel;
			}
			//Right
			if ( x < CHUNK_SIZE_X - 1 ) {
				var block = _blocks[x + 1, y, z];
				res.SunRight = block.SunLevel;
				res.ORight   = block.LightLevel;
			} else {
				var chunk = neighborChunks[2];
				if ( chunk != null ) {
					var block = chunk._blocks[0, y, z];
					res.SunRight = block.SunLevel;
					res.ORight   = block.LightLevel;
				}
			}
			//Left
			if ( x > 0 ) {
				var block = _blocks[x - 1, y, z];
				res.SunLeft = block.SunLevel;
				res.OLeft   = block.LightLevel;
			} else {
				var chunk = neighborChunks[3];
				if ( chunk != null ) {
					var block = chunk._blocks[CHUNK_SIZE_X - 1, y, z];
					res.SunLeft = block.SunLevel;
					res.OLeft   = block.LightLevel;
				}
			}
			//Forward
			if ( z < CHUNK_SIZE_Z - 1 ) {
				var block = _blocks[x, y, z + 1];
				res.SunForward = block.SunLevel;
				res.OForward   = block.LightLevel;
			} else {
				var chunk = neighborChunks[4];
				if ( chunk != null ) {
					var block = chunk._blocks[x, y, 0];
					res.SunForward = block.SunLevel;
					res.OForward   = block.LightLevel;
				}
			}
			//Backwards
			if ( z > 0 ) {
				var block = _blocks[x, y, z - 1];
				res.SunBackward = block.SunLevel;
				res.OBackward   = block.LightLevel;
			} else {
				var chunk = neighborChunks[5];
				if ( chunk != null ) {
					var block = chunk._blocks[x, y, CHUNK_SIZE_Z - 1];
					res.SunBackward = block.SunLevel;
					res.OBackward   = block.LightLevel;
				}
			}
			return res;
		}

		public bool HasBlockAt(int x, int y, int z) {
			return !_blocks[x, y, z].IsEmpty();
		}

		public bool HasFullOpaqueBlockAt(int x, int y, int z) {
			var type = _blocks[x, y, z].Type;
			return !GetBlockTranslucent(type) && GetBlockFull(type);
		}

		public bool HasTranslucentOrNonFullBlockAt(int x, int y, int z) {
			return _library.IsLightPassBlock(_blocks[x, y, z].Type);
		}

		public bool HasFullBlockAt(int x, int y, int z) {
			if ( HasBlockAt(x, y, z) ) {
				return GetBlockFull(_blocks[x, y, z].Type);
			}
			return false;
		}

		//Unsafe version, only for fast block setting in worldgen
		public void PutBlockUnsafe(int x, int y, int z, BlockData block ) {
			var checkY = y + 1;
			_maxNonEmptyY = checkY > _maxNonEmptyY ? checkY : _maxNonEmptyY;
			if ( _library.IsEmissiveBlock(block.Type) ) {
				block.LightLevel = _library.GetBlockDescription(block.Type).LightLevel;
				_lightAddQueue.Enqueue(new Int3(x, y, z));
			}
			_blocks[x, y, z] = block;
		}

		public void PutBlock(int x, int y, int z, BlockData block) {
			var checkY = y + 1;
			_maxNonEmptyY = (checkY) > _maxNonEmptyY ? checkY : _maxNonEmptyY;
			var oldBlock = _blocks[x, y, z];
			var oldLight    = oldBlock.LightLevel;
			var oldSunlight = oldBlock.SunLevel;	
			if ( _library.IsEmissiveBlock(block.Type) ) {
				block.LightLevel = _library.GetBlockDescription(block.Type).LightLevel;
				_lightAddQueue.Enqueue(new Int3(x, y, z));
			}
			if ( !_library.IsLightPassBlock(block.Type) ) {
				if ( oldLight > 0 ) {
					_lightRemQueue.Enqueue(new LightRemNode(x, y, z, oldLight));
				}
				if ( oldSunlight > 0 ) {
					_sunlightRemQueue.Enqueue(new LightRemNode(x, y, z, oldSunlight));
				}
			} else {
				block.LightLevel = oldLight;
				block.SunLevel = oldSunlight;
			}
			_blocks[x, y, z] = block;
			AddDirtyBlock(x, y, z);
		}

		public BlockData GetBlock(int x, int y, int z) {
			if ( x<0 || y <0 || z < 0 ) {
				return BlockData.Empty;
			}
			return _blocks[x, y, z];
		}

		public void RemoveBlock(int x, int y, int z) {
			var nl = GetLightForBlock(x, y, z, GetNeighborChunks());
			
			var oldLight     = _blocks[x, y, z].LightLevel;
			var oldSunlight  = _blocks[x, y, z].SunLevel;
			_blocks[x, y, z] = BlockData.Empty;
			var block = _blocks[x, y, z];
			block.LightLevel = (byte) Mathf.Clamp(Mathf.Max(nl.OBackward, nl.OForward, nl.OLeft, nl.ORight, nl.OUp, nl.ODown) - LIGHT_FALLOF_VALUE, 0, 255);
			_blocks[x, y, z] = block;
			_lightAddQueue.Enqueue(new Int3(x, y, z));
			_lightRemQueue.   Enqueue(new LightRemNode(x, y, z, oldLight));
			_sunlightRemQueue.Enqueue(new LightRemNode(x, y, z, oldSunlight));
			AddDirtyBlock(x, y, z);
		}

		void AddDirtyBlock(int x, int y, int z) {
			Dirty = true;
			if ( _needUpdateVisibilityAll || _dirtyBlocks.Count >= MAX_DIRTY_BLOCKS_BEFORE_FULL_REBUILD ) {
				_needUpdateVisibilityAll = true;
				return;
			}
			_dirtyBlocks.Add(new Int3(x, y, z));
		}

		public void SetDirtyAll() {
			Dirty = true;
			_needUpdateVisibilityAll = true;
		}

		BlockDescription GetBlockDescription(BlockType type) {
			return _library.GetBlockDescription(type);
		}

		bool GetBlockTranslucent(BlockType type) {
			return _library.IsTranslucentBlock(type);
		}

		bool GetBlockFull(BlockType type) {
			return _library.IsFullBlock(type);
		}

		bool GetBlockEmissive(BlockType type) {
			return _library.IsEmissiveBlock(type);
		}

		bool GetBlockLightPass(BlockType type) {
			return _library.IsLightPassBlock(type);
		}

		Chunk[] GetNeighborChunks() {
			var neighbors = new Chunk[6];
			neighbors[0] = _owner.GetChunk(_indexX, _indexY + 1, _indexZ);
			neighbors[1] = _owner.GetChunk(_indexX, _indexY - 1, _indexZ);
			neighbors[2] = _owner.GetChunk(_indexX + 1, _indexY, _indexZ);
			neighbors[3] = _owner.GetChunk(_indexX - 1, _indexY, _indexZ);
			neighbors[4] = _owner.GetChunk(_indexX, _indexY, _indexZ + 1);
			neighbors[5] = _owner.GetChunk(_indexX, _indexY, _indexZ - 1);
			return neighbors;
		}
	}
}
