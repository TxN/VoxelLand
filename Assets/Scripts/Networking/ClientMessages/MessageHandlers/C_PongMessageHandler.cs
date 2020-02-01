namespace Voxels.Networking.Serverside {
	public class C_PongMessageHandler : BaseClientMessageHandler {

		public override ClientPacketID CommandId {
			get {
				return ClientPacketID.Pong;
			}
		}

		public override void ProcessMessage(ClientState client, byte[] rawCommand) {
			base.ProcessMessage(client, rawCommand);
			client.LastPongTime = System.DateTime.Now;
		}
	}
}

