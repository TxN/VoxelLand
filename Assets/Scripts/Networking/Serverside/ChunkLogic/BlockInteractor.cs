using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Voxels.Networking.Serverside {
	public static class BlockInteractor {
		public static bool InteractWithBlock(ref BlockData sourceBlock, Vector3 worldPosition) {
			switch ( sourceBlock.Type ) {
				case BlockType.Air:
					break;
				case BlockType.Bedrock:
					break;
				case BlockType.Grass:
					break;
				case BlockType.Dirt:
					break;
				case BlockType.Stone:
					break;
				case BlockType.Cobblestone:
					break;
				case BlockType.Wood:
					break;
				case BlockType.Sand:
					break;
				case BlockType.Gravel:
					break;
				case BlockType.Log:
					break;
				case BlockType.Leaves:
					break;
				case BlockType.Clay:
					break;
				case BlockType.IronOre:
					break;
				case BlockType.CoalOre:
					break;
				case BlockType.Wool:
					break;
				case BlockType.Bricks:
					break;
				case BlockType.WaterStill:
					break;
				case BlockType.WaterFlow:
					break;
				case BlockType.WaterLily:
					break;
				case BlockType.Weed:
					sourceBlock = new BlockData(BlockType.Air);
					return true;
				case BlockType.Mushroom:
					break;
				case BlockType.RedstoneLamp:
					if ( sourceBlock.Subtype == 0 ) {
						sourceBlock.Subtype = 1;
					} else {
						sourceBlock.Subtype = 0;
					}
					return true;
				case BlockType.Glass:
					break;
				case BlockType.Sandstone:
					break;
				case BlockType.LavaStill:
					break;
				case BlockType.LavaFlow:
					break;
				case BlockType.TNT:
					break;
				case BlockType.RedBlock:
					break;
				case BlockType.StoneSlab:
					break;
				case BlockType.Shrub:
					break;
				case BlockType.IronBlock:
					break;
				case BlockType.GoldBlock:
					break;
				case BlockType.DiamondBlock:
					break;
				case BlockType.LapisLazuli:
					break;
				case BlockType.Obsidian:
					break;
				case BlockType.Bookshelf:
					break;
				default:
					break;
			}

			return false;
		}
	}
}

