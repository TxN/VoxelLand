namespace Voxels.Networking {
	[System.Flags]
	public enum PosUpdateOptions : byte {
		None     = 0,
		Teleport = 1,
		Force    = 2,
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
