using System.Collections.Generic;
using UnityEngine;
using EventSys;

namespace Voxels {
	public sealed class ChunkManager : MonoSingleton<ChunkManager> {
		public ResourceLibrary Library             = null;
		public Material        OpaqueMaterial      = null;
		public Material        TranslucentMaterial = null;
		public ChunkRenderer   ChunkRenderer       = null;

		public TilesetHelper TilesetHelper { get; private set; } = null;

		Dictionary<Int3, Chunk> _chunks = new Dictionary<Int3, Chunk>();
		int _sizeY = 0; 

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
		
		protected override void Awake() {
			base.Awake();
			_sizeY = 1;
			_chunks = new Dictionary<Int3, Chunk>();
			TilesetHelper = new TilesetHelper(Library.TileSize, Library.TilesetSize);
			BlockModelGenerator.PrepareGenerator(TilesetHelper);
			Library.GenerateBlockDescDict();
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
			var chunk = new Chunk(this, x, y, z, new Vector3(x * Chunk.CHUNK_SIZE_X, y * Chunk.CHUNK_SIZE_Y, z * Chunk.CHUNK_SIZE_Z));
			var render = Instantiate(ChunkRenderer, chunk.OriginPos, Quaternion.identity).GetComponent<ChunkRenderer>(); //TODO:Pooling
			render.name = string.Format("Chunk {0} {1}", x, z);
			render.transform.position = Vector3.zero;
			render.Setup(chunk);
			chunk.Renderer = render;
			_chunks[index] = chunk;
			return chunk;
		}

		void DeInitChunk(Int3 index) {
			if ( !_chunks.ContainsKey(index) ) {
				return;
			}
			var chunk = _chunks[index];
			Destroy(chunk.Renderer.gameObject);
			_chunks.Remove(index);
		}

		void LateUpdate() {
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

		public Chunk GetChunk(int x, int y, int z) {
			var key = new Int3(x, y, z);
			_chunks.TryGetValue(key, out var res);
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
			var fullChunksX = x / Chunk.CHUNK_SIZE_X;
			var fullChunksY = y / Chunk.CHUNK_SIZE_Y;
			var fullChunksZ = z / Chunk.CHUNK_SIZE_Z;
			//Debug.Log(fullChunksX + " " + fullChunksY + " " + fullChunksZ);
			return GetOrInitChunk(new Int3(fullChunksX, fullChunksY, fullChunksZ));
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
			chunk.RemoveBlock(inChunkX, inChunkY, inChunkZ);
		}
	}
}
