using System;
using System.Collections.Generic;

using SMGCore.EventSys;
using UnityEngine;
using Voxels.Networking.Events;

namespace Voxels.Networking.Clientside {
	public class ClientChunkManager : ClientsideController<ClientChunkManager>, IChunkManager {
		public ClientChunkManager(ClientGameManager owner) : base(owner) { }

		Dictionary<Int3, Chunk> _chunks = new Dictionary<Int3, Chunk>();

		ChunkRendererPool      _renderPool        = new ChunkRendererPool();
		DestroyBlockEffectPool _destroyEffectPool = new DestroyBlockEffectPool();

		bool _enabled = false;
		int _sizeY    = 0;

		public int GetWorldHeight {
			get {
				return _sizeY * Chunk.CHUNK_SIZE_Y;
			}
		}

		public override void PostLoad() {
			base.PostLoad();
			_renderPool.Init();
			_destroyEffectPool.Init();

			EventManager.Subscribe<OnClientReceiveChunk>(this, OnChunkReceived);
		}

		public override void Update() {
			if ( !_enabled ) {
				return;
			}
			UpdateDirtyChunks();
		}

		public override void LateUpdate() {
			if ( !_enabled ) {
				return;
			}
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

		public override void Reset() {
			base.Reset();

			EventManager.Unsubscribe<OnClientReceiveChunk>(OnChunkReceived);
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

		public BlockData GetBlockIn(Vector3 pos) {
			var x = Mathf.FloorToInt(pos.x);
			var y = Mathf.FloorToInt(pos.y);
			var z = Mathf.FloorToInt(pos.z);
			return GetBlockIn(x, y, z);
		}

		public BlockData GetBlockIn(int x, int y, int z) {
			var chunk = GetChunkInCoords(x, y, z);
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

		public void PutBlock(Vector3 pos, BlockData block) {
			var x = Mathf.FloorToInt(pos.x);
			var y = Mathf.FloorToInt(pos.y);
			var z = Mathf.FloorToInt(pos.z);
			PutBlock(x, y, z, block);
		}

		public void PutBlock(int x, int y, int z, BlockData block, bool broadcast = true) {
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

			if ( broadcast ) {
				var cc = ClientController.Instance;
				cc.SendNetMessage(ClientPacketID.PutBlock, new C_PutBlockMessage() { Block = block, Put = true, X = x, Y = y, Z = z });
			}
		}

		public void DestroyBlock(int x, int y, int z, bool broadcast = true) {
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

			if ( broadcast ) {
				var cc = ClientController.Instance;
				cc.SendNetMessage(ClientPacketID.PutBlock, new C_PutBlockMessage() { Block = BlockData.Empty, Put = false, X = x, Y = y, Z = z });
			}
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
			var render = _renderPool.Get();
			render.name = string.Format("Chunk {0} {1}", x, z);
			render.transform.position = Vector3.zero;
			render.Setup(chunk);
			chunk.Renderer = render;
			chunk.ForceUpdateChunk();
			return chunk;
		}

		void DeInitChunk(Int3 index) {
			if ( !_chunks.ContainsKey(index) ) {
				return;
			}
			var chunk = _chunks[index];
			_renderPool.Return(chunk.Renderer);
			chunk.Renderer = null;
			_chunks.Remove(index);
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
		}

		void OnChunkReceived(OnClientReceiveChunk e) {
			if ( e.Data == null ) {
				return;
			}
			var d = e.Data;
			var index = new Int3(d.IndexX, d.IndexY, d.IndexZ);
			InitializeChunk(index, d);
		}

		public void ProcessServerBlockUpdate(BlockData block, int x, int y, int z) {
			if ( GetBlockIn(x, y, z) == block ) {
				return;
			}
			PutBlock(x, y, z, block, false);
		}

		public void ProcessServerBlockRemoval(int x, int y, int z) {
			if ( GetBlockIn(x,y,z).IsEmpty() ) {
				return;
			}
			DestroyBlock(x, y, z, false);
		}

		public void FinalizeInitLoad() {
			foreach ( var chunk in _chunks ) {
				chunk.Value.ForceUpdateChunk();
			}
			_enabled = true;
		}

	}
}

