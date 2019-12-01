using UnityEngine;

namespace Voxels.Networking.Serverside {
	public sealed class TeleportChatCommand : ChatCommand {
		public override string Keyword {
			get {
				return "tp";
			}
		}

		public override bool OpOnly {
			get {
				return false;
			}
		}

		public override string ProcessCommand(ClientState sender, string[] commandWords) {


			if ( commandWords.Length < 4 ) {
				return "<color=\"red\">Error! Too few arguments</color>";
			}

			if (
				float.TryParse(commandWords[1], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var x) &&
				float.TryParse(commandWords[2], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var y) &&
				float.TryParse(commandWords[3], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var z) ) {

				var pc = ServerPlayerEntityManager.Instance;
				var playerEntity = pc.GetPlayerByOwner(sender);
				var pos = new Vector3(x, y, z);
				var flags = PosUpdateOptions.Teleport;
				PosUpdateOptionsHelper.Set(ref flags, PosUpdateOptions.Force);
				pc.BroadcastPlayerPosUpdate(sender, pos, playerEntity.CompressedPitch, playerEntity.CompressedYaw, flags);

				return "<color=\"blue\">Teleported.</color>";
			}
			return "<color=\"red\">Error. Wrong argumetns</color>";


		}
	}
}
