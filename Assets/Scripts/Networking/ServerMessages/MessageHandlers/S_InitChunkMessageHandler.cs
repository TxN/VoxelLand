using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Networking.Clientside;

using ZeroFormatter;

namespace Voxels.Networking {
	public class S_InitChunkMessageHandler : BaseServerMessageHandler {
		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);
			
			var command = ZeroFormatterSerializer.Deserialize<S_InitChunkMessage>(rawCommand);
			EventManager.Fire(new OnClientReceiveChunk() { RawMessage = command });
		}
	}
}
