namespace Voxels {
	public partial class Chunk {

		void UpdateVisibilityForNeighbors(int x, int y, int z, Chunk[] neighborChunks) {
			UpdateVisibilityAtBlock(x, y, z); // self
											  //Up
			if ( y < CHUNK_SIZE_Y - 1 ) {
				UpdateVisibilityAtBlock(x, y + 1, z);
			} else {
				var chunk = neighborChunks[0];
				if ( chunk != null ) {
					chunk.UpdateVisibilityAtBlockAndSetDirty(x, 0, z);
				}
			}
			//Down
			if ( y > 0 ) {
				UpdateVisibilityAtBlock(x, y - 1, z);
			} else {
				var chunk = neighborChunks[1];
				if ( chunk != null ) {
					chunk.UpdateVisibilityAtBlockAndSetDirty(x, CHUNK_SIZE_Y - 1, z);
				}
			}
			//Right
			if ( x < CHUNK_SIZE_X - 1 ) {
				UpdateVisibilityAtBlock(x + 1, y, z);
			} else {
				var chunk = neighborChunks[2];
				if ( chunk != null ) {
					chunk.UpdateVisibilityAtBlockAndSetDirty(0, y, z);
				}
			}
			//Left
			if ( x > 0 ) {
				UpdateVisibilityAtBlock(x - 1, y, z);
			} else {
				var chunk = neighborChunks[3];
				if ( chunk != null ) {
					chunk.UpdateVisibilityAtBlockAndSetDirty(CHUNK_SIZE_X - 1, y, z);
				}
			}
			//Forward
			if ( z < CHUNK_SIZE_Z - 1 ) {
				UpdateVisibilityAtBlock(x, y, z + 1);
			} else {
				var chunk = neighborChunks[4];
				if ( chunk != null ) {
					chunk.UpdateVisibilityAtBlockAndSetDirty(x, y, 0);
				}
			}
			//Backwards
			if ( z > 0 ) {
				UpdateVisibilityAtBlock(x, y, z - 1);
			} else {
				var chunk = neighborChunks[5];
				if ( chunk != null ) {
					chunk.UpdateVisibilityAtBlockAndSetDirty(x, y, CHUNK_SIZE_Z - 1);
				}
			}
		}

		void UpdateVisibilityAtBlockAndSetDirty(int x, int y, int z) {
			var prevFlag = _visibiltiy[x, y, z];
			UpdateVisibilityAtBlock(x, y, z);
			if ( prevFlag != _visibiltiy[x, y, z] ) {
				AddDirtyBlock(x, y, z);
			}
		}

		void UpdateVisibilityAtBlock(int x, int y, int z) {
			var block = _blocks[x, y, z];
			if ( block.IsEmpty() ) {
				_visibiltiy[x, y, z] = VisibilityFlags.None;
				return;
			}
			var neighbors = GetNeighborChunks();
			_visibiltiy[x, y, z] = GetBlockTranslucent(block.Type) ? CheckVisibilityTranslucent(x, y, z, neighbors) : CheckVisibilityOpaque(x, y, z, neighbors);
		}


		VisibilityFlags CheckVisibilityOpaque(int x, int y, int z, Chunk[] neighborChunks) {
			var flag = VisibilityFlags.None;
			//Up
			if ( y < CHUNK_SIZE_Y - 1 ) {
				if ( _library.IsLightPassBlock(_blocks[x, y + 1, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Up);
				}
			}
			//Down
			if ( y > 0 ) {
				if ( _library.IsLightPassBlock(_blocks[x, y - 1, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Down);
				}
			}
			//Right
			if ( x < CHUNK_SIZE_X - 1 ) {
				if ( _library.IsLightPassBlock(_blocks[x + 1, y, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Right);
				}
			} else {
				var chunk = neighborChunks[2];
				if ( chunk == null || _library.IsLightPassBlock(chunk._blocks[0, y, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Right);
				}
			}
			//Left
			if ( x > 0 ) {
				if ( _library.IsLightPassBlock(_blocks[x - 1, y, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Left);
				}
			} else {
				var chunk = neighborChunks[3];
				if ( chunk == null || _library.IsLightPassBlock(chunk._blocks[CHUNK_SIZE_X - 1, y, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Left);
				}
			}
			//Forward
			if ( z < CHUNK_SIZE_Z - 1 ) {
				if ( _library.IsLightPassBlock(_blocks[x, y, z + 1].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Forward);
				}
			}	else {
				var chunk = neighborChunks[4];
				if ( chunk == null || _library.IsLightPassBlock(chunk._blocks[x, y, 0].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Forward);
				}
			}
			//Backwards
			if ( z > 0 ) {
				if ( _library.IsLightPassBlock(_blocks[x, y, z - 1].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Backward);
				}
			} else {
				var chunk = neighborChunks[5];
				if ( chunk == null || _library.IsLightPassBlock(chunk._blocks[x, y, CHUNK_SIZE_Z - 1].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Backward);
				}
			}
			return flag;
		}

		VisibilityFlags CheckVisibilityTranslucent(int x, int y, int z, Chunk[] neighborChunks) {
			var flag = VisibilityFlags.None;
			//Up
			if ( y < CHUNK_SIZE_Y - 1 ) {
				if ( !_library.IsFullBlock(_blocks[x, y + 1, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Up);
				}
			}
			//Down
			if ( y > 0 ) {
				if ( !_library.IsFullBlock(_blocks[x, y - 1, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Down);
				}
			}
			//Right
			if ( x < CHUNK_SIZE_X - 1 ) {
				if ( !_library.IsFullBlock(_blocks[x + 1, y, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Right);
				}
			}	else {
				var chunk = neighborChunks[2];
				if ( chunk == null || !_library.IsFullBlock(chunk._blocks[0, y, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Right);
				}
			}
			//Left
			if ( x > 0 ) {
				if ( !_library.IsFullBlock(_blocks[x - 1, y, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Left);
				}
			} else {
				var chunk = neighborChunks[3];
				if ( chunk == null || !_library.IsFullBlock(chunk._blocks[CHUNK_SIZE_X - 1, y, z].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Left);
				}
			}
			//Forward
			if ( z < CHUNK_SIZE_Z - 1 ) {
				if ( !_library.IsFullBlock(_blocks[x, y, z + 1].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Forward);
				}
			} else {
				var chunk = neighborChunks[4];
				if ( chunk == null || !_library.IsFullBlock(chunk._blocks[x, y, 0].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Forward);
				}
			}
			//Backwards
			if ( z > 0 ) {
				if ( !_library.IsFullBlock(_blocks[x, y, z - 1].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Backward);
				}
			} else {
				var chunk = neighborChunks[5];
				if ( chunk == null || !_library.IsFullBlock(chunk._blocks[x, y, CHUNK_SIZE_Z - 1].Type) ) {
					VisibilityFlagsHelper.Set(ref flag, VisibilityFlags.Backward);
				}
			}
			return flag;
		}
	}
}
