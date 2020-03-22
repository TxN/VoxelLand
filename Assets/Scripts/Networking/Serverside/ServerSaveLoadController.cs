using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using System;

using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Utils;
using Voxels.Networking.Utils;

using ZeroFormatter;
using LiteDB;


namespace Voxels.Networking.Serverside {
	public class ServerSaveLoadController : ServerSideController<ServerSaveLoadController> {
		public ServerSaveLoadController(ServerGameManager owner) : base(owner) { }

		const string SAVE_DATA_FILE_NAME = "chunks.list";

		const string SaveDirPath = "Save/";

		bool   _ioAlive  = false;
		Thread _ioThread = null;

		ConcurrentQueue<KeyValuePair<Int3, ChunkData>> _chunkSaveQueue = new ConcurrentQueue<KeyValuePair<Int3, ChunkData>>();
		ConcurrentQueue<Int3>                          _chunkLoadQueue = new ConcurrentQueue<Int3>();
		MainDataHolder                                 _saveData       = new MainDataHolder();

		LiteDatabase _db = null;

		public string SavePath {
			get {
				return string.Format("{0}{1}/", SaveDirPath, WorldOptions.WorldName);
			}
		}

		public string WorldSavePath {
			get {
				return string.Format("{0}{1}/World/", SaveDirPath, WorldOptions.WorldName);
			}
		}

		public override void Init() {
			base.Init();

			CustomTypeMappers.InitMappers();

			_saveData.ChunkLibrary = new HashSet<Int3>();

			_ioAlive = true;
			_ioThread = new Thread(IOThread) {
				Name = "Server IO",
				IsBackground = true
			};
			_ioThread.Start();

			var path = SavePath;
			if ( !Directory.Exists(path) ) {
				Directory.CreateDirectory(path);
			}
			if ( !Directory.Exists(WorldSavePath) ) {
				Directory.CreateDirectory(WorldSavePath);
			}
		}

		public override void Load() {
			base.Load();
			var loadedHolder = LoadSaveFile<MainDataHolder>(SAVE_DATA_FILE_NAME);
			if ( loadedHolder != null ) {
				_saveData = loadedHolder;
				_saveData.ChunkLibrary = new HashSet<Int3>();
				foreach ( var item in _saveData.ChunkArray ) {
					_saveData.ChunkLibrary.Add(item);
				}
			}
			_db = new LiteDatabase(@SavePath + "main.db");
		}

		public override void Save() {
			base.Save();
			_saveData.ChunkArray = _saveData.ChunkLibrary.ToArray(); //ZeroFormatter не хочет сериализовывать хешсет по какой-то причине, поэтому приходится делать вот так
			SaveFileToDisk(SAVE_DATA_FILE_NAME, _saveData);
		}

		public override void Reset() {
			base.Reset();
			_ioAlive = false;
			
			while ( _chunkSaveQueue.Count > 0 ) {
				if ( _chunkSaveQueue.Count > 0 ) {
					if ( _chunkSaveQueue.TryDequeue(out var result) ) {
						SaveChunkToDisk(result.Key, result.Value);
					}
				}
			}
			if ( _db != null ) {
				_db.Dispose();
				_db = null;
			}
			Save();
		}

		public bool HasChunkOnDisk(Int3 index) {
			return _saveData.ChunkLibrary.Contains(index);
		}

		public void SaveChunk(Int3 index, ChunkData data) {
			_chunkSaveQueue.Enqueue(new KeyValuePair<Int3, ChunkData>(index, data));
		}

		public void TryLoadChunk(Int3 index) {
			foreach ( var item in _chunkSaveQueue ) {
				if ( item.Key.Equals(index) ) {
					EventManager.Fire(new OnServerChunkLoadedFromDisk {
						Index = index,
						DeserializedChunk = new Chunk(item.Value)
					});
					return;
				}
			}
			_chunkLoadQueue.Enqueue(index);
		}

		public PlayerEntitySaveInfo GetPlayerInfo(string name) {
			var coll = _db.GetCollection<PlayerEntitySaveInfo>("players");
			var result = coll.FindOne(x => x.Name == name);
			return result;
		}

		public void UpdatePlayerInfo(PlayerEntitySaveInfo info) {
			if ( info == null || string.IsNullOrEmpty(info.Name) ) {
				throw new ArgumentNullException("Player info is null or has invalid name");
			}
			var coll = _db.GetCollection<PlayerEntitySaveInfo>("players");
			
			if ( !coll.Update(info) ) {
				coll.Insert(info);

			}
			coll.EnsureIndex(x => x.Name);

			//_db.Commit();
		}


		public T LoadSaveFile<T>(string name) where T: class {
			return LoadFile<T>(SavePath + name);
		}

		public void SaveFileToDisk<T>(string name, T file) where T : class {
			SaveFile<T>(SavePath + name, file);
		}

		void IOThread() {
			while (_ioAlive) {
				Thread.Sleep(10);
				if ( _ioAlive ) {
					SaveAndLoadChunksFromQueues();
				}				
			}
		}

		void SaveAndLoadChunksFromQueues() {
			if ( _chunkSaveQueue.Count > 0 ) {
				if ( _chunkSaveQueue.TryDequeue(out var result) ) {
					SaveChunkToDisk(result.Key, result.Value);
				}
			}
			if ( _chunkLoadQueue.Count > 0 ) {
				if ( _chunkLoadQueue.TryDequeue(out var result) ) {
					LoadChunkFromDisk(result);
				}
			}
		}

		T LoadFile<T>(string filePath) where T : class {
			if ( !File.Exists(filePath) ) {
				return null;
			}
			using ( var file = File.OpenRead(filePath) ) {
				using ( var reader = new BinaryReader(file) ) {
					var length = reader.ReadInt32();
					var obj = ZeroFormatterSerializer.Deserialize<T>(reader.ReadBytes(length));
					return obj;
				}
			}
		}

		void SaveFile<T>(string filePath, T obj) where T : class {
			using ( var file = File.Create(filePath) ) {
				using ( var chunkWriter = new BinaryWriter(file) ) {
					var data = ZeroFormatterSerializer.Serialize(obj);
					chunkWriter.Write(data.Length);
					chunkWriter.Write(data);
				}
			}
		}

		void SaveChunkToDisk(Int3 pos, ChunkData data) {
			var savePath = WorldSavePath;
			try {
				using ( var file = File.Create(savePath + pos.ToString()) ) {
					using ( var chunkWriter = new BinaryWriter(file) ) {
						ChunkSerializer.Serialize(data, chunkWriter, true);
					}
				}
			} catch (Exception e) {
				UnityEngine.Debug.LogError(e.ToString());
				_chunkSaveQueue.Enqueue(new KeyValuePair<Int3, ChunkData>(pos, data)); //Если по какой-то причине не получилось сохраниться на диск, то возвращаем чанк в конец очереди.
			}

			_saveData.ChunkLibrary.Add(pos);
		}

		void LoadChunkFromDisk(Int3 pos) {
			var savePath = WorldSavePath;
			using ( var file = File.OpenRead(savePath + pos.ToString())) {
				using ( var reader = new BinaryReader(file) ) {
					var data = ChunkSerializer.Deserialize(reader);
					Task.Factory.StartNew(() => { UnpackChunk(pos, data); });
				}
			}
		}

		void UnpackChunk(Int3 index, ChunkData data) {
			var stopwatch = System.Diagnostics.Stopwatch.StartNew();
			if ( data == null ) {
				return;
			}
			var result = new Chunk(data);
			EventManager.Fire(new OnServerChunkLoadedFromDisk {
				Index = index,
				DeserializedChunk = result
			});
		}
	}
}
