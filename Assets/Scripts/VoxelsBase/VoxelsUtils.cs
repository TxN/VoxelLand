using System;

using UnityEngine;
using Voxels.Utils;

namespace Voxels {
	public static class VoxelsUtils {
		public static bool IsSet(this CastType flags, CastType flag) {
			return (flags & flag) != 0;
		}
	}
}
