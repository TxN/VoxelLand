namespace Voxels.Networking {
	[System.Flags]
	public enum PosUpdateOptions : byte {
		None     = 0,
		Teleport = 1,
		Force    = 2,
	}

	public enum PosUpdateType : byte {
		None = 0,
		PosRot = 1,
		Pos = 2,
		Rot = 3
	}

	public static class PosUpdateOptionsHelper {
		public static bool IsSet(this PosUpdateOptions flags, PosUpdateOptions flag) {
			return (flags & flag) != 0;
		}

		public static void Set(ref PosUpdateOptions flags, PosUpdateOptions flag) {
			flags = (flags | flag);
		}

		public static void Unset(PosUpdateOptions flags, PosUpdateOptions flag) {
			flags = (flags & (~flag));
		}
	}

}
