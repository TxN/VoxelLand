using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using SMGCore.EventSys;
using Voxels.Networking.Utils;
using Voxels.Networking.Events;

namespace Voxels.Networking.Serverside {
	public sealed class ServerChunkManager : ServerSideController<ServerChunkManager>, IChunkManager {
		public ServerChunkManager(ServerGameManager owner) : base(owner) { }

		Queue<Int3>             _saveLoadList  = new Queue<Int3>(128);

		Dictionary<Int3, Chunk> _chunks = new Dictionary<Int3, Chunk>();
		HashSet<Int3>          _library = new HashSet<Int3>();
		int                    _sizeY   = 0;

		public override void Load() {
			base.Load();
			//TODO: load library
		}

		public override void PostLoad() {
			base.PostLoad();
			EventManager.Subscribe<OnServerChunkGenerated>    (this, OnChunkGenerated);
			EventManager.Subscribe<OnServerChunkGenQueueEmpty>(this, OnGenerationFinished);

			LoadGenWorld();
		}

		public override void Reset() {
			base.Reset();
			EventManager.Unsubscribe<OnServerChunkGenerated>    (OnChunkGenerated);
			EventManager.Unsubscribe<OnServerChunkGenQueueEmpty>(OnGenerationFinished);
		}

		public override void Update() {
			if ( _saveLoadList.Count > 0 ) {
				//LoadChunk(_saveLoadList.Dequeue()); //TODO!
			}
			UpdateDirtyChunks();
		}

		public int GetWorldHeight {
			get {
				return _sizeY * Chunk.CHUNK_SIZE_Y;
			}
		}

		public int GatherNeighbors(Int3 index) {
			var res = 0;
			var x = index.X;
			var y = index.Y;
			var z = index.Z;
			if ( GetChunk(x + 1, y, z) != null ) {
				res += 4;
			}
			if ( GetChunk(x - 1, y, z) != null ) {
				res += 8;
			}
			if ( GetChunk(x, y, z + 1) != null ) {
				res += 1;
			}
			if ( GetChunk(x, y, z - 1) != null ) {
				res += 2;
			}
			return res;
		}

		public Chunk GetChunk(int x, int y, int z) {
			var key = new Int3(x, y, z);
			_chunks.TryGetValue(key, out var res);
			return res;
		}

		public Chunk GetChunk(Int3 pos) {
			_chunks.TryGetValue(pos, out var res);
			return res;
		}

		public Chunk GetChunkInCoords(Vector3 pos) {
			var posX = Mathf.FloorToInt(pos.x);
			var posY = Mathf.FloorToInt(pos.y);
			var posZ = Mathf.FloorToInt(pos.z);
			return GetChunkInCoords(posX, posY, posZ);
		}

		public Chunk GetChunkInCoords(int x, int y, int z) {
			var fullChunksX = Mathf.FloorToInt(x / (float)Chunk.CHUNK_SIZE_X);
			var fullChunksY = Mathf.FloorToInt(y / (float)Chunk.CHUNK_SIZE_Y);
			var fullChunksZ = Mathf.FloorToInt(z / (float)Chunk.CHUNK_SIZE_Z);
			return GetChunk(new Int3(fullChunksX, fullChunksY, fullChunksZ));
		}

		public Chunk GetOrInitChunkInCoords(int x, int y, int z) {
			var fullChunksX = Mathf.FloorToInt(x / (float)Chunk.CHUNK_SIZE_X);
			var fullChunksY = Mathf.FloorToInt(y / (float)Chunk.CHUNK_SIZE_Y);
			var fullChunksZ = Mathf.FloorToInt(z / (float)Chunk.CHUNK_SIZE_Z);
			return GetOrInitChunk(new Int3(fullChunksX, fullChunksY, fullChunksZ));
		}

		public void DestroyBlock(Vector3 pos) {
			var x = Mathf.FloorToInt(pos.x);
			var y = Mathf.FloorToInt(pos.y);
			var z = Mathf.FloorToInt(pos.z);
			DestroyBlock(x, y, z);
		}

		public void PutBlock(Vector3 pos, BlockData block) {
			var x = Mathf.FloorToInt(pos.x);
			var y = Mathf.FloorToInt(pos.y);
			var z = Mathf.FloorToInt(pos.z);
			PutBlock(x, y, z, block);
		}

		public void PutBlock(int x, int y, int z, BlockData block) {
			var chunk = GetChunkInCoords(x, y, z);
			if ( chunk == null ) {
				return;
			}
			var inChunkX = x % Chunk.CHUNK_SIZE_X;
			var inChunkY = y % Chunk.CHUNK_SIZE_Y;
			var inChunkZ = z % Chunk.CHUNK_SIZE_Z;
			if ( inChunkX < 0 ) {
				inChunkX = Chunk.CHUNK_SIZE_X + inChunkX;
			}
			if ( inChunkZ < 0 ) {
				inChunkZ = Chunk.CHUNK_SIZE_Z + inChunkZ;
			}
			chunk.PutBlock(inChunkX, inChunkY, inChunkZ, block);
			//TODO: send put block network event
		}

		public void DestroyBlock(int x, int y, int z) {
			var chunk = GetChunkInCoords(x, y, z);
			if ( chunk == null ) {
				return;
			}
			var inChunkX = x % Chunk.CHUNK_SIZE_X;
			var inChunkY = y % Chunk.CHUNK_SIZE_Y;
			var inChunkZ = z % Chunk.CHUNK_SIZE_Z;
			if ( inChunkX < 0 ) {
				inChunkX = Chunk.CHUNK_SIZE_X + inChunkX;
			}
			if ( inChunkZ < 0 ) {
				inChunkZ = Chunk.CHUNK_SIZE_Z + inChunkZ;
			}
			chunk.RemoveBlock(inChunkX, inChunkY, inChunkZ);
			//TODO: send remove block network event;
		}

		Chunk GetOrInitChunk(Int3 index) {
			if ( _chunks.TryGetValue(index, out var res) ) {
				return res;
			}
			return InitializeChunk(index);
		}

		Chunk InitializeChunk(Int3 index, ChunkData data = null) {
			if ( _chunks.ContainsKey(index) ) {
				DeInitChunk(index);
			}
			var x = index.X;
			var y = index.Y;
			var z = index.Z;
			var chunk = data == null ?
					new Chunk(this, x, y, z, new Vector3(x * Chunk.CHUNK_SIZE_X, y * Chunk.CHUNK_SIZE_Y, z * Chunk.CHUNK_SIZE_Z), false) :
					new Chunk(this, data, false);
			_chunks[index] = chunk;
			_library.Add(index);
			return chunk;
		}

		void DeInitChunk(Int3 index) {
			if ( !_chunks.ContainsKey(index) ) {
				return;
			}
			var chunk = _chunks[index];
			_chunks.Remove(index);
		}

		void LoadGenWorld() {
			var lg = ServerLandGenerator.Instance;
			lg.ImmediateMode = true;
			var chunkGenList = new List<Int3>();
			var originPos = Int3.Zero;
			for ( int r = 0; r < WorldOptions.ChunkLoadRadius; r++ ) {
				for ( int x = -r; x < r; x++ ) {
					for ( int z = -r; z < r; z++ ) {
						var newPos = originPos.Add(x, 0, z);
						if ( GetChunk(newPos) == null ) {
							if ( !_library.Contains(newPos) ) {
								chunkGenList.Add(originPos.Add(x, 0, z));
							}
							else {
								_saveLoadList.Enqueue(originPos.Add(x, 0, z));
							}
						}

					}
				}
			}
			Debug.LogFormat("Initial world generation. Chunks to load: {0}", chunkGenList.Count);
			lg.RefreshQueue(chunkGenList.ToList());
			lg.ImmediateMode = false;
		}

		void UpdateDirtyChunks() {
			foreach ( var chunkPair in _chunks ) {
				var chunk = chunkPair.Value;
				if ( chunk != null && chunk.Dirty ) {
					chunk.UpdateChunk();
				}
			}

			foreach ( var chunkPair in _chunks ) { //second pass to spread light correctly
				var chunk = chunkPair.Value;
				if ( chunk != null ) {
					chunk.UpdateLightLevel();
				}
			}

			foreach ( var chunkPair in _chunks ) {
				var chunk = chunkPair.Value;
				if ( chunk != null && chunk.NeedRebuildGeometry ) {
					chunk.UpdateGeometry();
				}
			}
		}

		void OnChunkGenerated(OnServerChunkGenerated e) {
			var c = e.WorldCoords;
			var chunk = GetOrInitChunkInCoords(c.X, c.Y, c.Z);
			if ( chunk != null ) {
				chunk.SetAllBlocks(e.Blocks, e.MaxHeight);
				ServerLandGenerator.Instance.PostProcessGeneration(chunk, e.Heightmap, e.WaterLevel);
			}
		}

		void OnGenerationFinished(OnServerChunkGenQueueEmpty e) {
			//TODO: trigger finish prepare
		}
	}
}
