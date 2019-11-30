using UnityEngine;
using System.Collections.Generic;

using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Utils;

using JetBrains.Annotations;

namespace Voxels.Networking.Serverside {
	public class ServerSaveLoadController : ServerSideController<ServerPlayerEntityManager> {
		public ServerSaveLoadController(ServerGameManager owner) : base(owner) { }
	}
}