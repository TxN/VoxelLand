using System.Collections.Generic;

using UnityEngine;

using SMGCore;
using SMGCore.EventSys;
using Voxels.Events;

namespace Voxels {
	public sealed class ChunkManager : MonoSingleton<ChunkManager> {
		public ResourceLibrary   Library             = null;
		public Material          OpaqueMaterial      = null;
		public Material          TranslucentMaterial = null;

		public TilesetHelper TilesetHelper { get; private set; } = null;

		Dictionary<Int3, Chunk> _chunks = new Dictionary<Int3, Chunk>();
		int                     _sizeY  = 0;

		List<Int3>        _chunkLoadList = new List<Int3>(128);
		ChunkRendererPool _renderPool    = new ChunkRendererPool();
		public const int LOAD_RADIUS   = 6;
		public const int UNLOAD_DISTANCE = 16 * 10;

		public int GetWorldHeight {
			get {
				return _sizeY * Chunk.CHUNK_SIZE_Y;
			}
		}

		public List<Chunk> GetAllChunks {
			get {
				var list = new List<Chunk>(_chunks.Count);
				foreach ( var chunk in _chunks ) {
					list.Add(chunk.Value);
				}
				return list;
			}
		}

		public Vector3 ViewPosition = Vector3.zero;
		
		protected override void Awake() {
			base.Awake();
			_sizeY = 1;
			_chunks = new Dictionary<Int3, Chunk>();
			TilesetHelper = new TilesetHelper(Library.TileSize, Library.TilesetSize);
			BlockModelGenerator.PrepareGenerator(TilesetHelper);
			Library.GenerateBlockDescDict();
			_renderPool.Init();
		}

		public Chunk GetOrInitChunk(Int3 index) {
			if ( _chunks.TryGetValue(index, out var res) ) {
				return res;
			}
			return InitializeChunk(index);
		}

		Chunk InitializeChunk(Int3 index) {
			if ( _chunks.ContainsKey(index) ) {
				DeInitChunk(index);
			}
			var x = index.X;
			var y = index.Y;
			var z = index.Z;
			var chunk  = new Chunk(this, x, y, z, new Vector3(x * Chunk.CHUNK_SIZE_X, y * Chunk.CHUNK_SIZE_Y, z * Chunk.CHUNK_SIZE_Z));
			var render = _renderPool.Get();
			render.name = string.Format("Chunk {0} {1}", x, z);
			render.transform.position = Vector3.zero;
			render.Setup(chunk);
			chunk.Renderer = render;
			_chunks[index] = chunk;
			return chunk;
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

		void DeInitChunk(Int3 index) {
			if ( !_chunks.ContainsKey(index) ) {
				return;
			}
			var chunk = _chunks[index];
			Destroy(chunk.Renderer.gameObject);
			_chunks.Remove(index);
		}

		void Update() {

			foreach ( var chunkPair in _chunks ) {
				var chunk = chunkPair.Value;
				if ( chunk != null && chunk.Dirty ) {
					chunk.UpdateChunk();
					EventManager.Fire(new Event_ChunkUpdate() { UpdatedChunk = chunk });
				}
			}

			foreach ( var chunkPair in _chunks ) { //second pass to spread light correctly
				var chunk = chunkPair.Value;
				if ( chunk != null ) {
					chunk.UpdateLightLevel();
				}
			}
		}

		void LateUpdate() {
			UnloadFarChunks();
			RefreshChunkGenQueue();
			foreach ( var chunkPair in _chunks ) {
				var chunk = chunkPair.Value;
				if ( chunk != null && chunk.MesherWorkComplete ) {
					chunk.FinalizeMeshUpdate();
				}
			}

			foreach ( var chunkPair in _chunks ) {
				var chunk = chunkPair.Value;
				if ( chunk != null && chunk.NeedRebuildGeometry ) {
					chunk.UpdateGeometry();
				}
			}

		}

		void RefreshChunkGenQueue() {
			_chunkLoadList.Clear();
			ViewPosition.y = 0;
			var originPos = GetChunkIdFromCoords(ViewPosition);
			//корявый способ, но пока так
			for ( int r = 0; r < LOAD_RADIUS; r++ ) {
				for ( int x = -r; x < r; x++ ) {
					for ( int z = -r; z < r; z++ ) {
						var newPos = originPos.Add(x, 0, z);
						if ( GetChunk(newPos) == null ) {
							_chunkLoadList.Add(originPos.Add(x, 0, z));
						}
					}
				}
			}
			LandGenerator.Instance.RefreshQueue(_chunkLoadList);
		}

		void UnloadFarChunks() {
			var unloadList = new List<Int3>();
			foreach ( var chunkPair in _chunks ) {
				var chunk = chunkPair.Value;
				if ( chunk.GetDistance(ViewPosition) > UNLOAD_DISTANCE ) {
					unloadList.Add(chunkPair.Key);
				}
			}

			foreach ( var item in unloadList ) {
				UnloadChunk(item);
			}
		}

		void UnloadChunk(Int3 pos) {
			var chunk = GetChunk(pos);
			_renderPool.Return(chunk.Renderer);
			chunk.UnloadChunk();
			_chunks.Remove(pos);
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

		void UpdateVisibilityForChunk(Chunk chunk) {
			chunk.UpdateVisibilityAll();
		}

		public Chunk GetChunkInCoords( Vector3 pos) {
			var posX = Mathf.FloorToInt(pos.x);
			var posY = Mathf.FloorToInt(pos.y);
			var posZ = Mathf.FloorToInt(pos.z);
			return GetChunkInCoords(posX, posY, posZ);
		}

		public Chunk GetChunkInCoords(int x, int y, int z) {
			var fullChunksX = Mathf.FloorToInt( x / (float)Chunk.CHUNK_SIZE_X);
			var fullChunksY = Mathf.FloorToInt( y / (float)Chunk.CHUNK_SIZE_Y);
			var fullChunksZ = Mathf.FloorToInt( z / (float)Chunk.CHUNK_SIZE_Z);
			return GetChunk(new Int3(fullChunksX, fullChunksY, fullChunksZ));
		}

		public Chunk GetOrInitChunkInCoords(int x, int y, int z) {
			var fullChunksX = Mathf.FloorToInt(x / (float)Chunk.CHUNK_SIZE_X);
			var fullChunksY = Mathf.FloorToInt(y / (float)Chunk.CHUNK_SIZE_Y);
			var fullChunksZ = Mathf.FloorToInt(z / (float)Chunk.CHUNK_SIZE_Z);
			return GetOrInitChunk(new Int3(fullChunksX, fullChunksY, fullChunksZ));
		}

		public Int3 GetChunkIdFromCoords(Vector3 pos) {
			var posX = Mathf.FloorToInt(pos.x);
			var posY = Mathf.FloorToInt(pos.y);
			var posZ = Mathf.FloorToInt(pos.z);
			var fullChunksX = Mathf.FloorToInt(posX / (float)Chunk.CHUNK_SIZE_X);
			var fullChunksY = Mathf.FloorToInt(posY / (float)Chunk.CHUNK_SIZE_Y);
			var fullChunksZ = Mathf.FloorToInt(posZ / (float)Chunk.CHUNK_SIZE_Z);
			return new Int3(fullChunksX, fullChunksY, fullChunksZ);
		}


		public void PutBlock(Vector3 pos, BlockData block) {
			var x = Mathf.FloorToInt(pos.x);
			var y = Mathf.FloorToInt(pos.y);
			var z = Mathf.FloorToInt(pos.z);
			PutBlock(x, y, z, block);
		}

		public void PutBlock(int x, int y, int z, BlockData block ) {
			var chunk = GetChunkInCoords(x, y, z);
			if ( chunk== null ) {
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
		}

		public BlockData GetBlockIn(Vector3 pos) {
			var x = Mathf.FloorToInt(pos.x);
			var y = Mathf.FloorToInt(pos.y);
			var z = Mathf.FloorToInt(pos.z);
			return GetBlockIn(x,y,z);
		}

		public BlockData GetBlockIn(int x, int y, int z) {
			var chunk = GetChunkInCoords(x,y,z);
			if ( chunk == null ) {
				return BlockData.Empty;
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
			return chunk.GetBlock(inChunkX, inChunkY, inChunkZ);
		}

		public void DestroyBlock(Vector3 pos) {
			var x = Mathf.FloorToInt(pos.x);
			var y = Mathf.FloorToInt(pos.y);
			var z = Mathf.FloorToInt(pos.z);
			DestroyBlock(x, y, z);
		}

		public void DestroyBlock(int x, int y, int z) {
			var chunk = GetChunkInCoords(x,y,z);
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
		}
	}
}
