namespace Voxels.Networking {
	public class C_PongMessageHandler : BaseClientMessageHandler {
		public override void ProcessMessage(ClientState client, byte[] rawCommand) {
			base.ProcessMessage(client, rawCommand);
			client.LastPongTime = System.DateTime.Now;
		}
	}
}

