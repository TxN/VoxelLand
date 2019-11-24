using System;

using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Networking.Serverside;

using ZeroFormatter;

namespace Voxels.Networking {
	public class C_HandshakeMessageHandler : BaseClientMessageHandler {
		public override void ProcessMessage(ClientState client, byte[] rawCommand) {
			base.ProcessMessage(client, rawCommand);
			var server = ServerController.Instance;
			var command = ZeroFormatterSerializer.Deserialize<C_HandshakeMessage>(rawCommand);
			if ( !GameManager.Instance.Server.Initialized ) {
				ServerController.Instance.ForceDisconnectClient(client, "Server is starting!");
				return;
			}

			foreach ( var cli in server.Clients.Values ) {
				if ( cli.UserName == command.ClientName ) {
					ServerController.Instance.ForceDisconnectClient(client, string.Format("User with name {0} is already connected. Force disconnecting.", command.ClientName));
					return;
				}
			}
			client.UserName = command.ClientName;
			if ( command.ProtocolVersion != ServerController.ProtocolVersion) {
				ServerController.Instance.ForceDisconnectClient(client, string.Format("Wrong protocol version. Server: {0}, yours: {1}", ServerController.ProtocolVersion, command.ProtocolVersion));
				return;
			}
			
			client.ConnectionTime = DateTime.Now;
			client.CurrentState = CState.Initialize;
			EventManager.Fire(new OnClientConnected { ConnectionId = client.ConnectionID, State = client });
			UnityEngine.Debug.LogFormat("Server: client with name {0} connected.", client.UserName);
			ServerChatManager.Instance.BroadcastFromServer(ChatMessageType.Info, string.Format("{0} connected to the server.", command.ClientName));
			
		}
	}
}
