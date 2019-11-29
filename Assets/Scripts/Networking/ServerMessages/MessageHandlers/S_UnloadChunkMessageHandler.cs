using Voxels.Networking.Clientside;

using ZeroFormatter;

namespace Voxels.Networking {
	public class S_UnloadChunkMessageHandler : BaseServerMessageHandler {
		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<S_UnloadChunkMessage>(rawCommand);
			var cm = ClientChunkManager.Instance;
			var index = new Int3(command.X, command.Y, command.Z);
			cm.UnloadChunk(index);
		}
	}
}
