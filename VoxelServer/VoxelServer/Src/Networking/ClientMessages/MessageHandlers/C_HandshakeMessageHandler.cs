using System;

using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Networking.Serverside;

using ZeroFormatter;

namespace Voxels.Networking {
	public class C_HandshakeMessageHandler : BaseClientMessageHandler {
		public override ClientPacketID CommandId {
			get {
				return ClientPacketID.Identification;
			}
		}

		public override void ProcessMessage(ClientState client, byte[] rawCommand) {
			base.ProcessMessage(client, rawCommand);
			var server = ServerController.Instance;
			var command = ZeroFormatterSerializer.Deserialize<C_HandshakeMessage>(rawCommand);
			if ( !GameManager.Instance.Server.Initialized ) {
				server.ForceDisconnectClient(client, "Server is starting!");
				return;
			}
			if ( command.ProtocolVersion != ServerController.ProtocolVersion ) {
				server.ForceDisconnectClient(client, string.Format("Wrong protocol version. Server: {0}, yours: {1}", ServerController.ProtocolVersion, command.ProtocolVersion));
				return;
			}
			if ( server.IsClientBanned(client.IpAdress, client.UserName, out var ban) ) {
				server.ForceDisconnectClient(client, string.Format("You are banned until {0} due to: {1}", ban.BanEnd.ToShortDateString(), ban.Reason));
				return;
			}

			foreach ( var cli in server.Clients.Values ) {
				if ( cli.UserName == command.ClientName ) {
					server.ForceDisconnectClient(client, string.Format("User with name {0} is already connected. Force disconnecting.", command.ClientName));
					return;
				}
			}

			if ( !server.TryAuthenticate(client, command.ClientName, command.Password, out var isNew) ) {
				server.ForceDisconnectClient(client, "Wrong password!");
				return;
			}
					   			
			client.ConnectionTime = DateTime.Now;
			client.CurrentState = CState.Initialize;
			EventManager.Fire(new OnClientConnected { ConnectionId = client.ConnectionID, State = client });
			DebugOutput.LogFormat("Server: client with name {0} connected.", client.UserName);
			ServerChatManager.Instance.BroadcastFromServer(ChatMessageType.Info, string.Format("{0} connected to the server.", command.ClientName));
			
		}
	}
}
