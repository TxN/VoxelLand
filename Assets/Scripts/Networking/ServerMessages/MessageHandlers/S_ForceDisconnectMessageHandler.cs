using UnityEngine;

using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Networking.Clientside;

using ZeroFormatter;

namespace Voxels.Networking {
	public class S_ForceDisconnectMessageHandler : BaseServerMessageHandler {

		public override ServerPacketID CommandId {
			get {
				return ServerPacketID.ForceDisconnect;
			}
		}

		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);

			var command = ZeroFormatterSerializer.Deserialize<S_ForceDisconnectMessage>(rawCommand);

			Debug.LogFormat("Force disconnected from server. Reason: '{0}'", command.Reason);
			var cc = ClientController.Instance;
			cc.ServerInfo.State = SState.Disconneted;
			EventManager.Fire(new OnForceDisconnectedFromServer { Reason = command.Reason });
		}

	}
}
