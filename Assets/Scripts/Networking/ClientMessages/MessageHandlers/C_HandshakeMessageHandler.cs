using SMGCore.EventSys;
using Voxels.Networking.Events;

using ZeroFormatter;

namespace Voxels.Networking {
	public class C_HandshakeMessageHandler : BaseClientMessageHandler {
		public override void ProcessMessage(ClientState client, byte[] rawCommand) {
			base.ProcessMessage(client, rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<C_HandshakeMessage>(rawCommand);
			client.UserName = command.ClientName;
			if ( command.ProtocolVersion != ServerController.ProtocolVersion) {
				ServerController.Instance.ForceDisconnectClient(client, string.Format("Wrong protocol version. Server: {0}, yours: {1}", ServerController.ProtocolVersion, command.ProtocolVersion));
				return;
			}
			EventManager.Fire(new OnClientConnected { ConnectionId = client.ConnectionID });
		}
	}
}

