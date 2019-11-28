using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using SMGCore.EventSys;
using Voxels.Networking.Utils;
using Voxels.Networking.Events;

namespace Voxels.Networking.Serverside {

	public class PlayerChunkLoadState {
		public bool         PlayerInited   = false;
		public ClientState  Client         = null;
		public PlayerEntity Entity         = null;
		public Queue<Int3>  SendQueue      = new Queue<Int3>();
		public List<Int3>   SentChunks     = new List<Int3>(256);
		public Queue<Int3>  LoadGenQueue   = new Queue<Int3>(256);
		public List<Int3>   ChunksToUnload = new List<Int3>(32);
	}


	public sealed class ServerChunkManager : ServerSideController<ServerChunkManager>, IChunkManager {
		public ServerChunkManager(ServerGameManager owner) : base(owner) { }

		Dictionary<ClientState, Queue<Int3>> _clientsLoadQueue = new Dictionary<ClientState, Queue<Int3>>();

		Dictionary<ClientState, PlayerChunkLoadState> _playerStates = new Dictionary<ClientState, PlayerChunkLoadState>();

		Queue<Int3> _loadQueue = new Queue<Int3>(128);

		Dictionary<Int3, Chunk> _chunks = new Dictionary<Int3, Chunk>();
		HashSet<Int3>          _library = new HashSet<Int3>();
		int                    _sizeY   = 1;

		public override void Load() {
			base.Load();
			//TODO: load library
		}

		public override void PostLoad() {
			base.PostLoad();
			EventManager.Subscribe<OnServerChunkGenerated>    (this, OnChunkGenerated);
			EventManager.Subscribe<OnServerChunkGenQueueEmpty>(this, OnGenerationFinished);
			EventManager.Subscribe<OnClientDisconnected>      (this, OnPlayerLeft);
			EventManager.Subscribe<OnClientConnected>         (this, OnPlayerJoin);

			Owner.AddToInitQueue(this);

			LoadGenWorld();
		}

		public override void Reset() {
			base.Reset();
			EventManager.Unsubscribe<OnServerChunkGenerated>    (OnChunkGenerated);
			EventManager.Unsubscribe<OnServerChunkGenQueueEmpty>(OnGenerationFinished);
			EventManager.Unsubscribe<OnClientConnected>         (OnPlayerJoin);
			EventManager.Unsubscribe<OnClientDisconnected>      (OnPlayerLeft);
		}

		public override void Update() {
			if ( _loadQueue.Count > 0 ) {
				//LoadChunk(_saveLoadList.Dequeue()); //TODO!
			}
			UpdateDirtyChunks();


			foreach ( var item in _playerStates ) {
				UpdateClientQueues(item.Value);
			}		
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

			ServerController.Instance.SendToAll(ServerPacketID.PutBlock, new S_PutBlockMessage() {
				Block = block,
				 Put = true,
				 X = x,
				 Y = y,
				 Z = z
			});
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

			ServerController.Instance.SendToAll(ServerPacketID.PutBlock, new S_PutBlockMessage() {
				Block = BlockData.Empty,
				Put = false,
				X = x,
				Y = y,
				Z = z
			});
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
					new Chunk(this, x, y, z, new Vector3(x * Chunk.CHUNK_SIZE_X, y * Chunk.CHUNK_SIZE_Y, z * Chunk.CHUNK_SIZE_Z), true) :
					new Chunk(this, data, true);
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
			lg.ClearQueue();
			lg.ImmediateMode = true;
			var dim = (WorldOptions.ChunkLoadRadius - 1) * 2;
			ChunkHelper.Spiral(dim, dim, GenOrLoad);
			Debug.LogFormat("Initial world generation. Chunks to load: {0}", lg.QueueCount);
			lg.RunGenRoutine();
			lg.ImmediateMode = false;
		}

		void GenOrLoad(int x, int z) {
			var lg = ServerLandGenerator.Instance;
			var newPos = new Int3(x, 0, z);
			if ( GetChunk(newPos) != null ) {
				return;
			}
			if ( !_library.Contains(newPos) ) {
				lg.AddToQueue(newPos, false);
			}	else {
				_loadQueue.Enqueue(newPos);
			}
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

		void CreateSendQueue(PlayerChunkLoadState state) {
			Vector3 spawnPoint = ServerPlayerEntityManager.Instance.GetSpawnPosition(state.Client);
			var centerChunk = ChunkHelper.GetChunkIdFromCoords(spawnPoint);

			var queue = state.LoadGenQueue;

			var dim = (WorldOptions.ChunkLoadRadius - 1) * 2;
			ChunkHelper.Spiral(dim, dim, (x, z) => {
				queue.Enqueue(centerChunk.Add(x, 0, z));
			});
		}

		void UpdateClientQueues(PlayerChunkLoadState state) {
			while ( state.LoadGenQueue.Count > 0 ) {
				var c = state.LoadGenQueue.Dequeue();
				state.SendQueue.Enqueue(c);
				var chunk = GetChunk(c);
				if ( chunk == null ) {
					GenOrLoad(c.X, c.Z);
					break;
				}				
			}

			if ( state.SendQueue.Count > 0 ) {
				var c = state.SendQueue.Peek();
				var chunk = GetChunk(c);
				if ( chunk != null ) {
					state.SentChunks.Add(c);
					state.SendQueue.Dequeue();
					SendChunkToClient(state.Client, chunk.GetData());
				}
			}

			if ( state.SendQueue.Count == 0 && !state.PlayerInited ) {
				state.PlayerInited = true;
				FinalizeClientWorldInitialization(state.Client);
			}
		}

		#region CHUNK_LOAD_LIST_MANAGEMENT
	/*	void RefreshChunkGenQueueForClient(ClientState client) {
			_chunkLoadList.Clear();
			_saveLoadList.Clear();
			ViewPosition.y = 0;
			var originPos = GetChunkIdFromCoords(ViewPosition);
			//корявый способ, но пока так
			for ( int r = 0; r < LOAD_RADIUS; r++ ) {
				for ( int x = -r; x < r; x++ ) {
					for ( int z = -r; z < r; z++ ) {
						var newPos = originPos.Add(x, 0, z);
						if ( GetChunk(newPos) == null ) {
							if ( !_library.Contains(newPos) ) {
								_chunkLoadList.Add(originPos.Add(x, 0, z));
							}
							else {
								_saveLoadList.Enqueue(originPos.Add(x, 0, z));
							}

						}

					}
				}
			}
			LandGenerator.Instance.RefreshQueue(_chunkLoadList.ToList());
		}
		*/
		#endregion



		void SendChunkToClient(ClientState client, ChunkData data) {
			ServerController.Instance.SendNetMessage(client, ServerPacketID.ChunkInit, new S_InitChunkMessage() { Chunk = data }, true);
		}

		void FinalizeClientWorldInitialization(ClientState client) {
			client.CurrentState = CState.Connected;
			ServerController.Instance.SendNetMessage(client, ServerPacketID.LoadFinalize, new S_LoadFinalizeMessage());
			EventManager.Fire(new OnServerReadyToSpawnNewPlayer { ConnectionId = client.ConnectionID, State = client });
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
			Owner.RemoveFromInitQueue(this);
			Debug.Log("Generation finished");
			//TODO: trigger finish prepare
		}

		void OnPlayerJoin(OnClientConnected e) {
			Debug.LogFormat("Player {0} joined. Starting to send world info.", e.State.UserName);

			var state = new PlayerChunkLoadState() {
				Client       = e.State,
				PlayerInited = false
			};
			_playerStates.Add(e.State, state);

			CreateSendQueue(state);
			var wsc = ServerWorldStateController.Instance; //TODO: Move to world state controller
			wsc.SendToClient(e.State);
		}

		void OnPlayerLeft(OnClientDisconnected e) {
			if ( _clientsLoadQueue.TryGetValue(e.State, out var q) ) {
				_clientsLoadQueue.Remove(e.State);
			}
			if ( _playerStates.TryGetValue(e.State, out var s) ) {
				_playerStates.Remove(e.State);
			}
		}
	}
}
