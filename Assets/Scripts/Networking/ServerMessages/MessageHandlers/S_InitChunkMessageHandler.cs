using System.IO;

using SMGCore.EventSys;
using Voxels.Networking.Events;

namespace Voxels.Networking {
	public class S_InitChunkMessageHandler : BaseServerMessageHandler {
		public override ServerPacketID CommandId {
			get {
				return ServerPacketID.ChunkInit;
			}
		}

		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);
			using ( var str = new MemoryStream(rawCommand) ) {
				using ( var reader = new BinaryReader(str) ) {
					var data = ChunkSerializer.Deserialize(reader);
					EventManager.Fire(new OnClientReceiveChunk() { Data = data });
				}
			}
		}
	}
}
