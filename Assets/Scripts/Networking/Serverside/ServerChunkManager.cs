using System.Collections.Generic;
using System.Collections.Concurrent;
using System.IO;

using UnityEngine;

using SMGCore.EventSys;
using Voxels.Networking.Utils;
using Voxels.Networking.Events;

namespace Voxels.Networking.Serverside {

	public class PlayerChunkLoadState {
		public bool          PlayerInited   = false;
		public ClientState   Client         = null;
		public PlayerEntity  Entity         = null;
		public Queue<Int3>   SendQueue      = new Queue<Int3>();
		public HashSet<Int3> SentChunks     = new HashSet<Int3>();
		public Queue<Int3>   LoadGenQueue   = new Queue<Int3>(256);
		public List<Int3>    ChunksToUnload = new List<Int3>(32);

		public void Destroy(Dictionary<Int3, int> usedChunks) {
			PlayerInited = false;
			Client = null;
			Entity = null;
			foreach ( var item in SentChunks ) {
				usedChunks[item] -= 1;
				if ( usedChunks[item] <= 0 ) {
					usedChunks.Remove(item);
				}
			}
			foreach ( var item in SendQueue ) {
				usedChunks[item] -= 1;
				if ( usedChunks[item] <= 0 ) {
					usedChunks.Remove(item);
				}
			}
		}
	}

	public class DebugDataHolder {
		public readonly Dictionary<Int3, Chunk> Chunks;
		public readonly Dictionary<Int3, int>   UsedChunks;
		public readonly Dictionary<Int3, float> UselessChunks;

		public DebugDataHolder(Dictionary<Int3, Chunk> chunks, Dictionary<Int3, int> usedChunks, Dictionary<Int3, float> uselessChunks ) {
			Chunks        = chunks;
			UsedChunks    = usedChunks;
			UselessChunks = uselessChunks;
		}
	}


	public sealed class ServerChunkManager : ServerSideController<ServerChunkManager>, IChunkManager {
		public ServerChunkManager(ServerGameManager owner) : base(owner) { }

		Dictionary<ClientState, PlayerChunkLoadState> _playerStates     = new Dictionary<ClientState, PlayerChunkLoadState>();
		Dictionary<Int3,int>                          _usedChunks       = new Dictionary<Int3, int>();
		Dictionary<Int3, float>                       _uselessChunks    = new Dictionary<Int3, float>();
		HashSet<Int3>                                 _requestedChunks  = new HashSet<Int3>();

		Dictionary<Int3, Chunk> _chunks         = new Dictionary<Int3, Chunk>();
		HashSet<Int3>          _keepaliveChunks = new HashSet<Int3>();
		int                    _sizeY   = 1;

		public override void Load() {
			base.Load();
		}

		public override void PostLoad() {
			base.PostLoad();
			EventManager.Subscribe<OnServerChunkGenerated>     (this, OnChunkGenerated);
			EventManager.Subscribe<OnServerChunkGenQueueEmpty> (this, OnGenerationFinished);
			EventManager.Subscribe<OnServerChunkLoadedFromDisk>(this, OnChunkLoadedFromDisk);
			EventManager.Subscribe<OnClientDisconnected>       (this, OnPlayerLeft);
			EventManager.Subscribe<OnClientConnected>          (this, OnPlayerJoin);
			EventManager.Subscribe<OnServerPlayerSpawn>        (this, OnPlayerSpawned);

			LoadGenWorldOrigin();
		}

		public override void Save() {
			base.Save();
			foreach ( var item in _chunks ) {
				ServerSaveLoadController.Instance.SaveChunk(item.Key, item.Value.GetData());
			}
		}

		public override void Reset() {
			base.Reset();
			EventManager.Unsubscribe<OnServerChunkGenerated>     (OnChunkGenerated);
			EventManager.Unsubscribe<OnServerChunkGenQueueEmpty> (OnGenerationFinished);
			EventManager.Unsubscribe<OnServerChunkLoadedFromDisk>(OnChunkLoadedFromDisk);
			EventManager.Unsubscribe<OnClientConnected>          (OnPlayerJoin);
			EventManager.Unsubscribe<OnServerPlayerSpawn>        (OnPlayerSpawned);
			EventManager.Unsubscribe<OnClientDisconnected>       (OnPlayerLeft);
		}

		public override void Update() {
			if ( _chunksToAdd.TryDequeue(out var pair) ) {
				_requestedChunks.Remove(pair.Key);
				_chunks.Add(pair.Key, pair.Value);
				pair.Value.FinishInitServerChunk(this);
			}

			UpdateDirtyChunks();

			foreach ( var item in _playerStates ) {
				UpdateClientQueues(item.Value);
			}		
		}

		public override void RareUpdate() {
			base.RareUpdate();
			foreach ( var item in _playerStates ) {
				UpdatePlayerVisibleChunks(item.Value);
			}
			UpdateUselessChunks();
		}

		DebugDataHolder _debugHolder = null;
		public DebugDataHolder DebugData {
			get {
				if ( _debugHolder == null ) {
					_debugHolder = new DebugDataHolder(_chunks, _usedChunks, _uselessChunks);
				}
				return _debugHolder;
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
			return GetChunk(key);
		}

		public Chunk GetChunk(Int3 pos) {
			if ( _uselessChunks.ContainsKey(pos) ) {
				_uselessChunks.Remove(pos);
			}
			if (_chunkUnloadSet.Contains(pos) ) {
				_chunkUnloadSet.Remove(pos);
			}
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

		public bool PutBlock(Vector3 pos, BlockData block) {
			var x = Mathf.FloorToInt(pos.x);
			var y = Mathf.FloorToInt(pos.y);
			var z = Mathf.FloorToInt(pos.z);
			return PutBlock(x, y, z, block);
		}

		public bool PutBlock(int x, int y, int z, BlockData block) {			
			var inChunkX = x % Chunk.CHUNK_SIZE_X;
			var inChunkY = y % Chunk.CHUNK_SIZE_Y;
			var inChunkZ = z % Chunk.CHUNK_SIZE_Z;
			if ( inChunkX < 0 ) {
				inChunkX = Chunk.CHUNK_SIZE_X + inChunkX;
			}
			if ( inChunkZ < 0 ) {
				inChunkZ = Chunk.CHUNK_SIZE_Z + inChunkZ;
			}
			var chunk = GetChunkInCoords(x, y, z);
			return PutBlock(inChunkX, inChunkY, inChunkZ, block, chunk);			
		}

		bool PutBlock(int inChunkX, int inChunkY, int inChunkZ, BlockData block, Chunk chunk) {
			if ( chunk == null ) {
				return false;
			}

			if ( TryPutBlock(chunk, inChunkX, inChunkY, inChunkZ, block) ) {
				var coords = chunk.LocalToGlobalCoordinates(inChunkX, inChunkY, inChunkZ);
				ServerController.Instance.SendToAll(ServerPacketID.PutBlock, new S_PutBlockMessage() {
					Block = block,
					Put = true,
					X = coords.X,
					Y = coords.Y,
					Z = coords.Z
				});
				return true;
			}
			return false;
		}

		bool TryPutBlock(Chunk chunk, int x, int y, int z, BlockData block) {
			var desc = StaticResources.BlocksInfo.GetBlockDescription(block.Type);
			if ( desc == null) {
				return false;
			}
			if ( desc.GravityAffected && y > 0 ) {
				var underBlock = chunk.GetBlock(x, y - 1, z);
				if ( underBlock.IsEmpty() ) {
					EntityHelper.SpawnFallingBlock(block, chunk.OriginPos + new Vector3(x + 0.5f, y, z + 0.5f), Vector3.zero);
					return false;
				}
			}
			chunk.PutBlock(x, y, z, block);
			OnBlockPut(chunk, block, desc, x, y, z);
			return true;
		}

		public void DestroyBlock(int x, int y, int z) {
			var chunk = GetChunkInCoords(x, y, z);	
			var inChunkX = x % Chunk.CHUNK_SIZE_X;
			var inChunkY = y % Chunk.CHUNK_SIZE_Y;
			var inChunkZ = z % Chunk.CHUNK_SIZE_Z;
			if ( inChunkX < 0 ) {
				inChunkX = Chunk.CHUNK_SIZE_X + inChunkX;
			}
			if ( inChunkZ < 0 ) {
				inChunkZ = Chunk.CHUNK_SIZE_Z + inChunkZ;
			}
			DestroyBlockInChunk(chunk, inChunkX, inChunkY, inChunkZ);
		}

		public void InteractWithBlockAt(Vector3 pos) {
			var block = GetBlockIn(pos);
			if ( block.IsEmpty() ) {
				return;
			}
			if ( BlockInteractor.InteractWithBlock(ref block, pos) ) {
				if ( block.IsEmpty() ) {
					DestroyBlock(pos);
				} else {
					PutBlock(pos, block);
				}
			}
		}

		void DestroyBlockInChunk(Chunk chunk, int inChunkX, int inChunkY, int inChunkZ) {
			if ( chunk == null ) {
				return;
			}
			chunk.RemoveBlock(inChunkX, inChunkY, inChunkZ);
			
			var coords = chunk.LocalToGlobalCoordinates(inChunkX, inChunkY, inChunkZ);
			//TODO: send updates only to players which have this chunk loaded
			ServerController.Instance.SendToAll(ServerPacketID.PutBlock, new S_PutBlockMessage() {
				Block = BlockData.Empty,
				Put = false,
				X = coords.X,
				Y = coords.Y,
				Z = coords.Z
			});
			OnRemoveBlockCheck(chunk, inChunkX, inChunkY, inChunkZ);
		}

		void OnRemoveBlockCheck(Chunk chunk, int x, int y, int z) {
			if ( y >= Chunk.CHUNK_SIZE_Y - 1 ) {
				return;
			}
			y++;
			var upperBlock = chunk.GetBlock(x, y, z);
			if ( upperBlock.IsEmpty() ) {
				return;
			}
			var desc = StaticResources.BlocksInfo.GetBlockDescription(upperBlock.Type);
			if ( desc == null ) {
				return;
			}
			if ( desc.GravityAffected ) {
				DestroyBlockInChunk(chunk, x, y, z);
				EntityHelper.SpawnFallingBlock(upperBlock, chunk.OriginPos + new Vector3(x + 0.5f, y, z + 0.5f), Vector3.zero);
				return;
			}
			if ( desc.IsSwimmable ) {
			
				PutBlock(x, y - 1, z, upperBlock, chunk);
				return;
			}
		}

		void OnBlockPut(Chunk chunk, BlockData block, BlockDescription blockDesc, int x, int y, int z) {
			if ( blockDesc.IsSwimmable && y > 0 ) {
				//water or lava, lets check if there's block underneath to fill
				var downBlock = chunk.GetBlock(x, y - 1, z);
				if ( downBlock.IsEmpty() ) {
					PutBlock(x, y - 1, z, block, chunk);
				}
			}
		}

		Chunk GetOrInitChunk(Int3 index) {
			return GetChunk(index) ?? InitializeChunk(index);
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
			//_library.Add(index); //TODO: add to library only after first save
			return chunk;
		}

		void DeInitChunk(Int3 index) {
			if ( !_chunks.ContainsKey(index) ) {
				return;
			}
			var chunk = _chunks[index];
			_chunks.Remove(index);
		}

		void LoadGenWorldOrigin() {
			var lg = ServerLandGenerator.Instance;
			lg.ClearQueue();
			lg.ImmediateMode = true;
			var dim = (WorldOptions.ChunkLoadRadius - 1) * 2;
			ChunkHelper.Spiral(dim, dim, GenOrLoad);
			ChunkHelper.Spiral(dim, dim, (x,y) => { _keepaliveChunks.Add(new Int3(x, 0, y)); });
			DebugOutput.LogFormat("Initial world generation. Chunks total: {0}, to generate: {1}", dim*dim, lg.QueueCount);
			if ( lg.QueueCount > 0 ) {
				Owner.AddToInitQueue(this);
			}
			lg.TryStartGeneration();
			lg.ImmediateMode = false;
		}

		void GenOrLoad(int x, int z) {
			GenOrLoad(x, z, false);
		}

		void GenOrLoad(int x, int z, bool run) {
			var lg = ServerLandGenerator.Instance;
			var newPos = new Int3(x, 0, z);
			if ( GetChunk(newPos) != null || _requestedChunks.Contains(newPos) ) {
				return;
			}
			var sl = ServerSaveLoadController.Instance;
			if ( !sl.HasChunkOnDisk(newPos) ) {
				lg.AddToQueue(newPos, run);
			} else {
				sl.TryLoadChunk(newPos);
			}
			_requestedChunks.Add(newPos);
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

		void CreateInitialSendQueue(PlayerChunkLoadState state) {
			Vector3 spawnPoint = ServerPlayerEntityManager.Instance.GetLastSavedPosition(state.Client);
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
				if ( !_usedChunks.ContainsKey(c) ) {
					_usedChunks.Add(c, 1);
				}
				else {
					_usedChunks[c] += 1;
				}

				if ( chunk == null ) {
					GenOrLoad(c.X, c.Z, true);
					break;
				}
			}

			if ( state.SendQueue.Count > 0 ) {
				var c = state.SendQueue.Dequeue();
				var chunk = GetChunk(c);
				if ( chunk != null ) {
					SendChunkToClient(state, chunk.GetData(), c);
				} else {
					state.SendQueue.Enqueue(c);
				}
			}

			if ( state.ChunksToUnload.Count > 0 ) {
				foreach ( var item in state.ChunksToUnload ) {
					UnloadChunkOnClient(state, item);
					_usedChunks[item] -= 1;
					if ( _usedChunks[item] <= 0 ) {
						_usedChunks.Remove(item);
					}
				}				
				state.ChunksToUnload.Clear();
			}

			if ( state.SendQueue.Count == 0 && !state.PlayerInited ) {
				state.PlayerInited = true;
				FinalizeClientWorldInitialization(state.Client);
			}
		}


		List<Int3> _tempVisList = new List<Int3>(256);
		void UpdatePlayerVisibleChunks(PlayerChunkLoadState state) {
			if (state.Entity == null ) {
				return;
			}
			state.ChunksToUnload.Clear();

			_tempVisList.Clear();
			var centerPos = ChunkHelper.GetChunkIdFromCoords(state.Entity.Position);

			var dim = (WorldOptions.MaxLoadRadius - 1) * 2;
			ChunkHelper.Spiral(dim, dim, (x,y) => { _tempVisList.Add(centerPos.Add(x, 0, y)); } );
			foreach ( var c in _tempVisList ) {
				if ( state.SentChunks.Contains(c) || state.SendQueue.Contains(c) || state.LoadGenQueue.Contains(c) ) {
					continue;
				}
				state.LoadGenQueue.Enqueue(c);
			}

			var maxLoadDistance = WorldOptions.ChunkUnloadDistance * WorldOptions.ChunkUnloadDistance;

			foreach ( var c in state.SentChunks ) {
				var dist = Int3.SquareDistanceFlat(centerPos, c);
				if ( dist > maxLoadDistance ) {
					state.ChunksToUnload.Add(c);
				}
			}
		}

		HashSet<Int3> _chunkUnloadSet = new HashSet<Int3>();
		void UpdateUselessChunks() {
			foreach ( var c in _chunks ) {
				var id = c.Key;
				if ( _usedChunks.ContainsKey(id) || _keepaliveChunks.Contains(id) ) {
					continue;
				}
				if ( ! _uselessChunks.ContainsKey(id) && !_chunkUnloadSet.Contains(id) ) {
					_uselessChunks.Add(id, ServerGameManager.Time);
				}
			}
			var maxAge = WorldOptions.UselessChunksMaxAge;
			var curTime = ServerGameManager.Time;
			foreach ( var c in _uselessChunks ) {
				if ( curTime - c.Value > maxAge ) {
					_chunkUnloadSet.Add(c.Key);
					ServerSaveLoadController.Instance.SaveChunk(c.Key, _chunks[c.Key].GetData());
				}
			}
			foreach ( var item in _chunkUnloadSet ) {
				_uselessChunks.Remove(item);
				DeInitChunk(item);
			}
			_chunkUnloadSet.Clear();
		}


		byte[] _chunkSendBuffer = new byte[65535];
		void SendChunkToClient(PlayerChunkLoadState state, ChunkData data, Int3 index) {
			state.SentChunks.Add(index);
			var blockCount = (data.Height + 1) * 16 * 16;

			using ( var str = new MemoryStream(_chunkSendBuffer) ) {
				using ( var writer = new BinaryWriter(str) ) {
					var count = ChunkSerializer.Serialize(data, writer, true);
					var dst = new byte[count];
					System.Array.Copy(_chunkSendBuffer, dst, count);
					ServerController.Instance.SendRawNetMessage(state.Client, ServerPacketID.ChunkInit, dst, false);
				}
			}
		}

		void UnloadChunkOnClient(PlayerChunkLoadState state, Int3 index) {
			state.SentChunks.Remove(index);
			ServerController.Instance.SendNetMessage(state.Client, ServerPacketID.ChunkUnload, new S_UnloadChunkMessage() { X = index.X, Y = index.Y, Z = index.Z });
		}

		void FinalizeClientWorldInitialization(ClientState client) {
			client.CurrentState = CState.Connected;
			ServerController.Instance.SendNetMessage(client, ServerPacketID.LoadFinalize, new S_LoadFinalizeMessage());
			EventManager.Fire(new OnServerReadyToSpawnNewPlayer { ConnectionId = client.ConnectionID, State = client });
		}

		void OnChunkGenerated(OnServerChunkGenerated e) {
			var c = e.ChunkData.WorldCoords;
			_requestedChunks.Remove(new Int3(c.X, c.Y, c.Z));
			var chunk = GetOrInitChunkInCoords(c.X, c.Y, c.Z);
			if ( chunk != null ) {
				chunk.SetAllBlocks(e.ChunkData.Blocks, e.ChunkData.MaxHeight);
				ServerLandGenerator.PostProcessGeneration(chunk, e.ChunkData.Heightmap, e.ChunkData.WaterLevel);
			}
		}

		void OnGenerationFinished(OnServerChunkGenQueueEmpty e) {
			Owner.RemoveFromInitQueue(this);
			//TODO: trigger finish prepare
		}

		ConcurrentQueue<KeyValuePair<Int3, Chunk>> _chunksToAdd = new ConcurrentQueue<KeyValuePair<Int3, Chunk>>();
		void OnChunkLoadedFromDisk(OnServerChunkLoadedFromDisk e) {
			_chunksToAdd.Enqueue(new KeyValuePair<Int3, Chunk>(e.Index, e.DeserializedChunk));
		}

		void OnPlayerJoin(OnClientConnected e) {
			DebugOutput.LogFormat("Player {0} joined. Starting to send world info.", e.State.UserName);

			var state = new PlayerChunkLoadState() {
				Client       = e.State,
				PlayerInited = false
			};
			_playerStates.Add(e.State, state);

			CreateInitialSendQueue(state);
			var wsc = ServerWorldStateController.Instance; //TODO: Move to world state controller
			wsc.SendToClient(e.State);
		}

		void OnPlayerSpawned(OnServerPlayerSpawn e) {
			if ( _playerStates.TryGetValue(e.Client, out var state) ) {
				state.Entity = e.Player;
			}
		}

		void OnPlayerLeft(OnClientDisconnected e) {
			if ( _playerStates.TryGetValue(e.State, out var s) ) {
				s.Destroy(_usedChunks);
				_playerStates.Remove(e.State);
			}
		}
	}
}
