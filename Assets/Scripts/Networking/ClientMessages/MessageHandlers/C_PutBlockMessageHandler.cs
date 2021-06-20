using Voxels.Networking.Serverside;

using ZeroFormatter;

namespace Voxels.Networking {
	public class C_PutBlockMessageHandler : BaseClientMessageHandler {
		public override ClientPacketID CommandId {
			get {
				return ClientPacketID.PutBlock;
			}
		}

		public override void ProcessMessage(ClientState client, byte[] rawCommand) {
			base.ProcessMessage(client, rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<C_PutBlockMessage>(rawCommand);
			var cm = ServerChunkManager.Instance;

			if ( command.Put ) {
				var result = cm.PutBlock(command.X, command.Y, command.Z, command.Block);
				if ( !result ) {
					//rollback
					var block = cm.GetBlockIn(command.X, command.Y, command.Z);
					ServerController.Instance.SendNetMessage(client, ServerPacketID.PutBlock, new S_PutBlockMessage() {
						Block = block,
						Put = true,
						X = command.X,
						Y = command.Y,
						Z = command.Z
					});
				}
			} else {
				cm.DestroyBlock(command.X, command.Y, command.Z);
			}
		}
	}
}
