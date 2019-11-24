using Voxels.Networking.Clientside;
using Voxels.Networking.Utils;

using ZeroFormatter;

namespace Voxels.Networking {
	public class S_WorldOptionsMessageHandler : BaseServerMessageHandler {
		public override void ProcessMessage(byte[] rawCommand) {
			base.ProcessMessage(rawCommand);
			var command = ZeroFormatterSerializer.Deserialize<S_WorldOptionsMessage>(rawCommand);

			WorldOptions.Seed = command.Seed;
			var wsc = ClientWorldStateController.Instance;
			wsc.SetTimeParameters(command.Time, command.TimeMultiplier);
			WorldOptions.DayLength = command.DayLength;
		}
	}
}
