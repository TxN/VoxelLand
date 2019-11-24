using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Networking.Serverside;

using ZeroFormatter;


namespace Voxels.Networking {
	public class C_PutBlockMessageHandler : BaseClientMessageHandler {
		public override void ProcessMessage(ClientState client, byte[] rawCommand) {
			base.ProcessMessage(client, rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<C_PutBlockMessage>(rawCommand);
			var cm = ServerChunkManager.Instance;

			if ( command.Put ) {
				cm.PutBlock(command.X, command.Y, command.Z, command.Block);
			} else {
				cm.DestroyBlock(command.X, command.Y, command.Z);
			}
		}
	}
}
