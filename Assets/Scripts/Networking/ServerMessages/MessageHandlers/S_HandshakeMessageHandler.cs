using UnityEngine;

using Voxels.Networking.Clientside;

using ZeroFormatter;

namespace Voxels.Networking {
	public class S_HandshakeMessageHandler : BaseServerMessageHandler {
		public override ServerPacketID CommandId {
			get {
				return ServerPacketID.Identification;
			}
		}

		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<S_HandshakeMessage>(rawCommand);

			var cc = ClientController.Instance;
			var serverInfo = cc.ServerInfo;
			serverInfo.ServerName = command.ServerName;
			serverInfo.Motd = command.MOTD;

			Debug.LogFormat("Received server '{0}' handshake.\nMotd: {1}", serverInfo.ServerName, serverInfo.Motd);
			cc.SendNetMessage(ClientPacketID.Identification, new C_HandshakeMessage { ClientName = cc.ClientName, Password = cc.Password, ProtocolVersion = ClientController.ProtocolVersion });
			ClientChatManager.Instance.AddReceivedMessage("", serverInfo.Motd, ChatMessageType.Raw);
		}
	}
}

