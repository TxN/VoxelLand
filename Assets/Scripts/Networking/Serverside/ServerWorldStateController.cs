using UnityEngine;

using Voxels.Networking.Utils;

namespace Voxels.Networking.Serverside {
	public class ServerWorldStateController : ServerSideController<ServerWorldStateController> {
		public ServerWorldStateController(ServerGameManager owner) : base(owner) { }
		const string SAVE_DATA_FILE_NAME = "world.opts";

		BlockInfoProvider      _library      = null;
		WorldOptionsDataHolder _worldOptions = null;

		public float WorldTime {
			get { return _worldOptions.WorldTime; }
			set { _worldOptions.WorldTime = value; }
		}

		public float TimeScale { get { return _worldOptions.TimeMultiplier; } }

		public float TimeTotalDays {
			get {
				var days = WorldTime / DayLength;
				return days;
			}
		}

		public float DayPercent {
			get {
				return TimeTotalDays - DaysPassed;
			}
		}

		public int DaysPassed {
			get {
				var days  = WorldTime / DayLength;
				var whole = Mathf.FloorToInt(days);
				return whole;
			}
		}

		public int DayNumber {
			get {
				var days = WorldTime / DayLength;
				var whole = Mathf.FloorToInt(days);
				return whole;
			}
		}
		//TODO: daytime check
		/*
		public float AmbientLightIntensity {
			get {
				return _library.AmbientLightIntensity.Evaluate(DayPercent);
			}
		}
		*/
		public float DayLength {
			get { return _worldOptions.DayLength; }
		}

		public void SetDayTime(float dayPercent) {
			var whole = Mathf.FloorToInt(dayPercent);
			dayPercent = dayPercent - whole;

			var newDay = DaysPassed + 1;
			WorldTime  = (newDay + dayPercent) * DayLength;
			SendToClient();
		}

		public override void Init() {
			base.Init();
			_library = StaticResources.BlocksInfo;
		}

		public override void Load() {
			base.Load();
			_worldOptions = ServerSaveLoadController.Instance.LoadSaveFile<WorldOptionsDataHolder>(SAVE_DATA_FILE_NAME);
			if ( _worldOptions == null ) {
				CreateWorldOptions();
			}
			InitWorldOptions();
		}

		public override void Update() {
			base.Update();
			WorldTime += ServerGameManager.TickTimeSeconds * TimeScale;
		}

		public override void Save() {
			base.Save();
			ServerSaveLoadController.Instance.SaveFileToDisk(SAVE_DATA_FILE_NAME, _worldOptions);
		}

		public void SendToClient(ClientState state = null) {
			var command = new S_WorldOptionsMessage() {
				Seed           = _worldOptions.Seed,
				DayLength      = _worldOptions.DayLength,
				Time           = WorldTime,
				TimeMultiplier = TimeScale
			};
			if ( state == null ) {
				ServerController.Instance.SendToAll(ServerPacketID.WorldOptions, command);
			} else {
				ServerController.Instance.SendNetMessage(state, ServerPacketID.WorldOptions, command);
			}
		}

		void CreateWorldOptions() {
			_worldOptions = new WorldOptionsDataHolder {
				WorldTime = 0f,
				TimeMultiplier = 1f,
				Seed = WorldOptions.Seed,
				ChunkUnloadDistance = WorldOptions.ChunkUnloadDistance,
				ChunkLoadRadius = WorldOptions.ChunkLoadRadius,
				UselessChunksMaxAge = WorldOptions.UselessChunksMaxAge,
				MaxLoadRadius = WorldOptions.MaxLoadRadius,
				DayLength = WorldOptions.DayLength
			};
		}

		void InitWorldOptions() {
			WorldTime = _worldOptions.WorldTime;
			WorldOptions.ChunkLoadRadius = _worldOptions.ChunkLoadRadius;
			WorldOptions.ChunkUnloadDistance = _worldOptions.ChunkUnloadDistance;
			WorldOptions.UselessChunksMaxAge = _worldOptions.UselessChunksMaxAge;
			WorldOptions.Seed = _worldOptions.Seed;
			WorldOptions.MaxLoadRadius = _worldOptions.MaxLoadRadius;
		}
	}
}
