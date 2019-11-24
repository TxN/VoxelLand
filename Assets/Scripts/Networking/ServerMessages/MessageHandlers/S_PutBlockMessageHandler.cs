using Voxels.Networking.Clientside;

using ZeroFormatter;

namespace Voxels.Networking {
	public class S_PutBlockMessageHandler : BaseServerMessageHandler {
		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<S_PutBlockMessage>(rawCommand);

			var cm = ClientChunkManager.Instance;

			if ( command.Put ) {
				cm.ProcessServerBlockUpdate(command.Block, command.X, command.Y, command.Z);
			} else {
				cm.ProcessServerBlockRemoval(command.X, command.Y, command.Z);
			}
		}
	}
}
