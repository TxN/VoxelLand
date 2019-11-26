using UnityEngine;

namespace Voxels.Events {
	public struct Event_ChunkUpdate {
		public Chunk UpdatedChunk;
	}

	public struct Event_ChunkMeshUpdate {
		public Chunk UpdatedChunk;
	}

	public struct Event_ChunkLoaded {
		public Chunk LoadedChunk;
		public Int3  Coordinates;
	}

	public struct Event_BlockPreviewUpdated {
		public BlockData Block;
		public Texture2D Texture;
	}

	public struct Event_ControlLockChanged {
		public bool IsEnabled;

		public Event_ControlLockChanged(bool flag) {
			IsEnabled = flag;
		}
	}
}
