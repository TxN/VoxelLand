using UnityEngine;

namespace Voxels.Networking {
	public class S_JoinSuccessMessageHandler : BaseServerMessageHandler {
		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);
			Debug.Log("Client: successfully connected to server.");
			var cc = ClientController.Instance;
			cc.ServerInfo.State = SState.Connected;
		}
	}
}
