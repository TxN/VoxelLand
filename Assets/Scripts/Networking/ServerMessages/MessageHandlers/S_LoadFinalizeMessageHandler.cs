using Voxels.Networking.Clientside;

using ZeroFormatter;

namespace Voxels.Networking {
	public class S_LoadFinalizeMessageHandler : BaseServerMessageHandler {
		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<S_LoadFinalizeMessage>(rawCommand);

			//ClientChunkManager.Instance.FinalizeInitLoad();
		}
	}
}
