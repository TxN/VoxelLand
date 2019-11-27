using System.Collections;
using System.Collections.Generic;

using Unity.Jobs;
using UnityEngine;

using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Networking.Utils;

namespace Voxels.Networking.Serverside {
	public class ServerWorldStateController : ServerSideController<ServerWorldStateController> {
		public ServerWorldStateController(ServerGameManager owner) : base(owner) { }

		ResourceLibrary _library = null;

		public float WorldTime {
			get; private set;
		}

		public float TimeScale { get; private set; } = 1f;


		public float TimeTotalDays {
			get {
				var days = WorldTime / WorldOptions.DayLength;
				return days;
			}
		}

		public float DayPercent {
			get {
				var days  = WorldTime / WorldOptions.DayLength;
				return TimeTotalDays - DaysPassed;
			}
		}

		public int DaysPassed {
			get {
				var days  = WorldTime / WorldOptions.DayLength;
				var whole = Mathf.FloorToInt(days);
				return whole;
			}
		}

		public int DayNumber {
			get {
				var days = WorldTime / WorldOptions.DayLength;
				var whole = Mathf.FloorToInt(days);
				return whole;
			}
		}

		public float AmbientLightIntensity {
			get {
				return _library.AmbientLightIntensity.Evaluate(DayPercent);
			}
		}

		public void SetDayTime(float dayPercent) {
			var whole = Mathf.FloorToInt(dayPercent);
			dayPercent = dayPercent - whole;

			var newDay = DaysPassed + 1;
			WorldTime  = (newDay + dayPercent) * WorldOptions.DayLength;
			SendToClient();
		}

		public override void Init() {
			base.Init();
			_library = VoxelsStatic.Instance.Library;
		}

		public override void Load() {
			base.Load();
			//TODO:Load from save
		}

		public override void Update() {
			base.Update();
			WorldTime += Time.deltaTime * TimeScale;
		}

		public void SendToClient(ClientState state = null) {
			var command = new S_WorldOptionsMessage() {
				Seed           = WorldOptions.Seed,
				DayLength      = WorldOptions.DayLength,
				Time           = WorldTime,
				TimeMultiplier = TimeScale
			};
			if ( state == null ) {
				ServerController.Instance.SendToAll(ServerPacketID.WorldOptions, command);
			} else {
				ServerController.Instance.SendNetMessage(state, ServerPacketID.WorldOptions, command);
			}
		}
	}
}