using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Networking.Serverside;

using ZeroFormatter;

namespace Voxels.Networking {
	public class C_PlayerUpdateMessageHandler : BaseClientMessageHandler {
		public override ClientPacketID CommandId {
			get {
				return ClientPacketID.PlayerUpdate;
			}
		}

		public override void ProcessMessage(ClientState client, byte[] rawCommand) {
			base.ProcessMessage(client, rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<C_PlayerUpdateMessage>(rawCommand);

			ServerPlayerEntityManager.Instance.BroadcastPlayerUpdate(client, command.PlayerInfo);
		}
	}
}
