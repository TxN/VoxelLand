using UnityEngine;

namespace Voxels {
	public static class BlockModelGenerator {
		static TilesetHelper _helper             = null;
		static Vector2[][]   _fullTileUVCache    = null;
		static int           _fullTileCacheWidth = 32;

		public static void PrepareGenerator(TilesetHelper helper) {
			_helper = helper;
			var tileCount = helper.TileCount;
			var width = helper.TilesetWidthTiles;
			_fullTileCacheWidth = width;
			_fullTileUVCache = new Vector2[tileCount][];
			for ( byte x = 0; x < width; x++ ) {
				for ( byte y = 0; y < width; y++ ) {
					_fullTileUVCache[x + width * y] = CacheUVsForTile(new Byte2(x, y));
				}
			}
		}

		public static void AddBlock(GeneratableMesh meshInfo, BlockDescription desc, ref Vector3 rootPos, ref MesherBlockInput input) {
			if ( desc == null ) {
				return;
			}
			var data       = input.Block;
			var visibility = input.Visibility;
			var light      = input.Lighting;
			switch ( desc.ModelType ) {
				case BlockModelType.None:
					return;
				case BlockModelType.FullBlockSimple:
					GenerateFullBlockSimple(meshInfo, desc, data, rootPos, visibility, light);
					return;
				case BlockModelType.FullBlockComplex:
					GenerateFullBlockComplex(meshInfo, desc, data, rootPos, visibility, light);
					return;
				case BlockModelType.HalfBlockDown:
					GenerateHalfBlockDown(meshInfo, desc, data, rootPos, visibility, light);
					return;
				case BlockModelType.HalfBlockUp:
					return;
				case BlockModelType.Stairs:
					return;
				case BlockModelType.Plate:
					return;
				case BlockModelType.Grass:
					return;
				case BlockModelType.HorizontalPlane:
					GenerateHorizontalPlane(meshInfo, desc, data, rootPos, visibility);
					return;
				case BlockModelType.SmallerBlock:
					return;
				case BlockModelType.CrossedVPlanes:
					GenerateCrossedVPlanes(meshInfo, desc, data, rootPos, visibility);
					return;
				default:
					return;
			}
		}

		public static void GenerateCrossedVPlanes(GeneratableMesh meshInfo, BlockDescription desc, BlockData data, Vector3 rootPos, VisibilityFlags visibility) {
			var pointer   = meshInfo.Vertices.Count;
			var tile      = desc.Subtypes[Mathf.Clamp(data.Subtype, 0, desc.Subtypes.Count - 1)].FaceTiles[0];
			var calcColor = new Color32(data.SunLevel, data.LightLevel, 0, 0);
			AddPlane(meshInfo, _rotVertPlaneVerts_0, tile, rootPos, pointer, calcColor);
			pointer += 4;
			AddPlane(meshInfo, _rotVertPlaneVerts_1, tile, rootPos, pointer, calcColor);
			pointer += 4;
			AddPlaneInv(meshInfo, _rotVertPlaneVerts_0, _helper, tile, rootPos, pointer, calcColor);
			pointer += 4;
			AddPlaneInv(meshInfo, _rotVertPlaneVerts_1, _helper, tile, rootPos, pointer, calcColor);
			pointer += 4;
		}

		public static void GenerateFullBlockSimple(GeneratableMesh meshInfo, BlockDescription desc, BlockData data, Vector3 rootPos, VisibilityFlags visibility, LightInfo light) {
			var pointer = meshInfo.Vertices.Count;
			var tile    = desc.Subtypes[Mathf.Clamp(data.Subtype, 0, desc.Subtypes.Count - 1)].FaceTiles[0];
			var uvs     = GetCachedUVsForTile(tile);

			if ( VisibilityFlagsHelper.IsSet(visibility, VisibilityFlags.Backward) ) {
				var calcColor = new Color32(light.SunBackward, light.OBackward, 0, 0);
				AddPlaneWithUVs(meshInfo, _fullBlockBackSide, uvs, rootPos, pointer, calcColor);
				pointer += 4;
			}
			if ( VisibilityFlagsHelper.IsSet(visibility, VisibilityFlags.Forward) ) {
				var calcColor = new Color32(light.SunForward, light.OForward, 0, 0);
				AddPlaneWithUVs(meshInfo, _fullBlockFrontSide, uvs, rootPos, pointer, calcColor);
				pointer += 4;
			}
			if ( VisibilityFlagsHelper.IsSet(visibility, VisibilityFlags.Left) ) {
				var calcColor = new Color32(light.SunLeft, light.OLeft, 0, 0);
				AddPlaneWithUVs(meshInfo, _fullBlockLeftSide, uvs, rootPos, pointer, calcColor);
				pointer += 4;
			}
			if ( VisibilityFlagsHelper.IsSet(visibility, VisibilityFlags.Right) ) {
				var calcColor = new Color32(light.SunRight, light.ORight, 0, 0);
				AddPlaneWithUVs(meshInfo, _fullBlockRightSide, uvs, rootPos, pointer, calcColor);
				pointer += 4;
			}
			if ( VisibilityFlagsHelper.IsSet(visibility, VisibilityFlags.Up) ) {
				var calcColor = new Color32(light.SunUp, light.OUp, 0, 0);
				AddPlaneWithUVs(meshInfo, _fullBlockUpSide, uvs, rootPos, pointer, calcColor);
				pointer += 4;
			}
			if ( VisibilityFlagsHelper.IsSet(visibility, VisibilityFlags.Down) ) {
				var calcColor = new Color32(light.SunDown, light.ODown, 0, 0);
				AddPlaneWithUVs(meshInfo, _fullBlockDownSide, uvs, rootPos, pointer, calcColor);
				pointer += 4;
			}
		}

		public static void GenerateFullBlockComplex(GeneratableMesh meshInfo, BlockDescription desc, BlockData data, Vector3 rootPos, VisibilityFlags visibility, LightInfo light) {
			var pointer = meshInfo.Vertices.Count;
			var sub = desc.Subtypes[Mathf.Clamp(data.Subtype, 0, desc.Subtypes.Count - 1)];

			if ( VisibilityFlagsHelper.IsSet(visibility, VisibilityFlags.Backward) ) {
				var calcColor = new Color32(light.SunBackward, light.OBackward, 0, 0);
				AddPlane(meshInfo, _fullBlockBackSide, sub.FaceTiles[0], rootPos,  pointer, calcColor);
				pointer += 4;
			}
			if ( VisibilityFlagsHelper.IsSet(visibility, VisibilityFlags.Forward) ) {
				var calcColor = new Color32(light.SunForward, light.OForward, 0, 0);
				AddPlane(meshInfo, _fullBlockFrontSide, sub.FaceTiles[1], rootPos,  pointer,calcColor);
				pointer += 4;
			}
			if ( VisibilityFlagsHelper.IsSet(visibility, VisibilityFlags.Left) ) {
				var calcColor = new Color32(light.SunLeft, light.OLeft, 0, 0);
				AddPlane(meshInfo, _fullBlockLeftSide, sub.FaceTiles[2], rootPos,  pointer, calcColor);
				pointer += 4;
			}
			if ( VisibilityFlagsHelper.IsSet(visibility, VisibilityFlags.Right) ) {
				var calcColor = new Color32(light.SunRight, light.ORight, 0, 0);
				AddPlane(meshInfo, _fullBlockRightSide, sub.FaceTiles[3], rootPos,  pointer, calcColor);
				pointer += 4;
			}
			if ( VisibilityFlagsHelper.IsSet(visibility, VisibilityFlags.Up) ) {
				var calcColor = new Color32(light.SunUp, light.OUp, 0, 0);
				AddPlane(meshInfo, _fullBlockUpSide, sub.FaceTiles[4], rootPos, pointer, calcColor);
				pointer += 4;
			}
			if ( VisibilityFlagsHelper.IsSet(visibility, VisibilityFlags.Down) ) {
				var calcColor = new Color32(light.SunDown, light.ODown, 0, 0);
				AddPlane(meshInfo, _fullBlockDownSide, sub.FaceTiles[5], rootPos, pointer, calcColor);
				pointer += 4;
			}
		}

		public static void GenerateHalfBlockDown(GeneratableMesh meshInfo, BlockDescription desc, BlockData data, Vector3 rootPos, VisibilityFlags visibility, LightInfo light) {
			var pointer = meshInfo.Vertices.Count;
			var sub = desc.Subtypes[Mathf.Clamp(data.Subtype, 0, desc.Subtypes.Count - 1)];

			if ( VisibilityFlagsHelper.IsSet(visibility, VisibilityFlags.Backward) ) {
				var calcColor = new Color32(light.SunBackward, light.OBackward, 0, 0);
				AddPlane(meshInfo, _halfBlockDBackSide, sub.FaceTiles[0], rootPos, pointer, calcColor);
				pointer += 4;
			}
			if ( VisibilityFlagsHelper.IsSet(visibility, VisibilityFlags.Forward) ) {
				var calcColor = new Color32(light.SunForward, light.OForward, 0, 0);
				AddPlane(meshInfo, _halfBlockDFrontSide, sub.FaceTiles[1], rootPos, pointer, calcColor);
				pointer += 4;
			}
			if ( VisibilityFlagsHelper.IsSet(visibility, VisibilityFlags.Left) ) {
				var calcColor = new Color32(light.SunLeft, light.OLeft, 0, 0);
				AddPlane(meshInfo, _halfBlockDLeftSide, sub.FaceTiles[2], rootPos, pointer, calcColor);
				pointer += 4;
			}
			if ( VisibilityFlagsHelper.IsSet(visibility, VisibilityFlags.Right) ) {
				var calcColor = new Color32(light.SunRight, light.ORight, 0, 0);
				AddPlane(meshInfo, _halfBlockDRightSide, sub.FaceTiles[3], rootPos, pointer, calcColor);
				pointer += 4;
			}

			if ( VisibilityFlagsHelper.IsSet(visibility, VisibilityFlags.Up) ) {
				var calcColor = new Color32(light.SunUp, light.OUp, 0, 0);
				AddPlane(meshInfo, _halfBlockDUpside, sub.FaceTiles[4], rootPos, pointer, calcColor);
				pointer += 4;
			}
			if ( VisibilityFlagsHelper.IsSet(visibility, VisibilityFlags.Down) ) {
				var calcColor = new Color32(light.SunDown, light.ODown, 0, 0);
				AddPlane(meshInfo, _fullBlockDownSide, sub.FaceTiles[5], rootPos, pointer, calcColor);
				pointer += 4;
			}
		}

		static Vector3[] _halfBlockDUpside = new Vector3[4] {
			new Vector3(0f,0.5f,0f),
			new Vector3(0f,0.5f,1f),
			new Vector3(1f,0.5f,0f),
			new Vector3(1f,0.5f,1f)
		};

		static Vector3[] _halfBlockDLeftSide = new Vector3[4] {
			new Vector3(0f,0f,1f),
			new Vector3(0f,0.5f,1f),
			new Vector3(0f,0f,0f),
			new Vector3(0f,0.5f,0f)
		};

		static Vector3[] _halfBlockDRightSide = new Vector3[4] {
			new Vector3(1f,0f,0f),
			new Vector3(1f,0.5f,0f),
			new Vector3(1f,0f,1f),
			new Vector3(1f,0.5f,1f)
		};

		static Vector3[] _halfBlockDBackSide = new Vector3[4] {
			new Vector3(0f,0f,0f),
			new Vector3(0f,0.5f,0f),
			new Vector3(1f,0f,0f),
			new Vector3(1f,0.5f,0f)
		};

		static Vector3[] _halfBlockDFrontSide = new Vector3[4] {
			new Vector3(1f,0f,1f),
			new Vector3(1f,0.5f,1f),
			new Vector3(0f,0f,1f),
			new Vector3(0f,0.5f,1f)
		};

		static Vector2[] _halfTileUV = new Vector2[4] {
			new Vector2(0f,0.5f),
			new Vector2(0f,0f),
			new Vector2(1f,0.5f),
			new Vector2(1f,0f)
		};

		static Vector3[] _fullBlockUpSide = new Vector3[4] {
			new Vector3(0f,1f,0f),
			new Vector3(0f,1f,1f),
			new Vector3(1f,1f,0f),
			new Vector3(1f,1f,1f)
		};
		static Vector3[] _fullBlockDownSide = new Vector3[4] {
			new Vector3(1f,0f,0f),
			new Vector3(1f,0f,1f),
			new Vector3(0f,0f,0f),
			new Vector3(0f,0f,1f)
		};

		static Vector3[] _fullBlockLeftSide = new Vector3[4] {
			new Vector3(0f,0f,1f),
			new Vector3(0f,1f,1f),
			new Vector3(0f,0f,0f),
			new Vector3(0f,1f,0f)
		};

		static Vector3[] _fullBlockRightSide = new Vector3[4] {
			new Vector3(1f,0f,0f),
			new Vector3(1f,1f,0f),
			new Vector3(1f,0f,1f),
			new Vector3(1f,1f,1f)
		};

		static Vector3[] _fullBlockBackSide = new Vector3[4] {
			new Vector3(0f,0f,0f),
			new Vector3(0f,1f,0f),
			new Vector3(1f,0f,0f),
			new Vector3(1f,1f,0f)
		};

		static Vector3[] _fullBlockFrontSide = new Vector3[4] {
			new Vector3(1f,0f,1f),
			new Vector3(1f,1f,1f),
			new Vector3(0f,0f,1f),
			new Vector3(0f,1f,1f)
		};

		static Vector2[] _fullTileUV = new Vector2[4] {
			new Vector2(0f,1f),
			new Vector2(0f,0f),
			new Vector2(1f,1f),
			new Vector2(1f,0f)
		};

		static Vector3[] _horizontalPlaneVerts = new Vector3[4] {
			new Vector3(0f,0.02f,0f),
			new Vector3(0f,0.02f,1f),
			new Vector3(1f,0.02f,0f),
			new Vector3(1f,0.02f,1f)

		};

		static Vector3[] _rotVertPlaneVerts_0 = new Vector3[4] {
			new Vector3(0f,0f,0f),
			new Vector3(0f,1f,0f),
			new Vector3(1f,0f,1f),
			new Vector3(1f,1f,1f)

		};

		static Vector3[] _rotVertPlaneVerts_1 = new Vector3[4] {
			new Vector3(0f,0f,1f),
			new Vector3(0f,1f,1f),
			new Vector3(1f,0f,0f),
			new Vector3(1f,1f,0f)

		};

		static int[] _planeTris         = new int[6] {0,1,2,2,1,3};
		static int[] _planeTrisInverted = new int[6] {2,1,0,1,2,3};
		//Неполные блоки не рисуем только если они полностью ограждены полными блоками.
		public static void GenerateHorizontalPlane(GeneratableMesh meshInfo, BlockDescription desc, BlockData data, Vector3 rootPos, VisibilityFlags visibility) {
			if ( visibility == VisibilityFlags.None ) {
				return;
			}
			var pointer = meshInfo.Vertices.Count;
			var calcColor = new Color32(data.SunLevel, data.LightLevel, 0, 0);
			AddPlane(meshInfo, _horizontalPlaneVerts, desc.Subtypes[Mathf.Clamp(data.Subtype, 0, desc.Subtypes.Count - 1)].FaceTiles[0], rootPos, pointer, calcColor);
		}

		public static void AddPlaneInv(GeneratableMesh meshInfo, Vector3[] verts, TilesetHelper helper, Byte2 tile, Vector3 rootPos, int pointer, Color32 color) {
			meshInfo.AddVerticesWithPos(verts, rootPos);
			meshInfo.AddTriangles(_planeTrisInverted, pointer);
			meshInfo.AddPlaneUVs(tile);
			//Ага
			meshInfo.Colors.Add(color);
			meshInfo.Colors.Add(color);
			meshInfo.Colors.Add(color);
			meshInfo.Colors.Add(color);
		}

		public static void AddPlane(GeneratableMesh meshInfo, Vector3[] verts, Byte2 tile, Vector3 rootPos, int pointer, Color32 color) {
			meshInfo.AddVerticesWithPos(verts, rootPos);
			meshInfo.AddTriangles(_planeTris, pointer);
			meshInfo.AddPlaneUVs(tile);
			//Ага
			meshInfo.Colors.Add(color);
			meshInfo.Colors.Add(color);
			meshInfo.Colors.Add(color);
			meshInfo.Colors.Add(color);
		}

		public static void AddPlaneWithUVs(GeneratableMesh meshInfo, Vector3[] verts, Vector2[] uvs, Vector3 rootPos, int pointer, Color32 color) {
			meshInfo.AddVerticesWithPos(verts, rootPos);
			meshInfo.AddTriangles(_planeTris, pointer);
			meshInfo.AddUVs(uvs);
			//Ага
			meshInfo.Colors.Add(color);
			meshInfo.Colors.Add(color);
			meshInfo.Colors.Add(color);
			meshInfo.Colors.Add(color);
		}

		static void AddVerticesWithPos(this GeneratableMesh meshInfo, Vector3[] verts, Vector3 rootPos) {
			var vertsList = meshInfo.Vertices;
			for ( int i = 0; i < verts.Length; i++ ) {
				vertsList.Add(verts[i] + rootPos);
			}
		}

		static void AddTriangles(this GeneratableMesh meshInfo, int[] indexes, int rootIndex) {
			var trisList = meshInfo.Triangles;
			for ( int i = 0; i < indexes.Length; i++ ) {
				trisList.Add(indexes[i] + rootIndex);
			}
		}

		static void AddPlaneUVs(this GeneratableMesh meshInfo, Byte2 tilePos) {
			meshInfo.AddUVs(GetCachedUVsForTile(tilePos));
		}

		static void AddUVs(this GeneratableMesh meshInfo, Vector2[] uvs) {
			var uvsList = meshInfo.UVs;
			for ( int i = 0; i < uvs.Length; i++ ) {
				uvsList.Add(uvs[i]);
			}
		}

		static Vector2[] CacheUVsForTile(Byte2 tilePos) {
			var uvs = new Vector2[4];
			for ( int i = 0; i < uvs.Length; i++ ) {
				uvs[i] = _helper.RelativeToAbsolute(_fullTileUV[i].x, _fullTileUV[i].y, tilePos);
			}
			return uvs;
		}

		static Vector2[] GetCachedUVsForTile(Byte2 tilePos) {
			return _fullTileUVCache[tilePos.X + _fullTileCacheWidth * tilePos.Y];
		}
	}
}
