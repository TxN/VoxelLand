using System.Collections.Generic;

namespace Voxels {
	public enum BlockType: byte {
		Air         = 0,
		Bedrock     = 1,
		Grass       = 2,
		Dirt        = 3,
		Stone       = 4,
		Cobblestone = 5,
		Wood        = 6,
		Sand        = 7,
		Gravel      = 8,
		Log         = 9,
		Leaves      = 10,
		Clay        = 11,
		IronOre     = 12,
		CoalOre     = 13,
		Wool        = 14,
		Bricks      = 15,
		WaterStill  = 16,
		WaterFlow   = 17,
		WaterLily   = 18,
		Weed        = 19,
		Mushroom    = 20,
		RedstoneLamp= 21,
		Glass       = 22,
		Sandstone   = 23,
		LavaStill   = 24,
		LavaFlow    = 25,
		TNT         = 26,
		RedBlock    = 27,
		StoneSlab   = 28,
		Shrub       = 29,
		IronBlock   = 30,
		GoldBlock   = 31,
		DiamondBlock= 32,
		LapisLazuli = 33,
		Obsidian    = 34,
		Bookshelf   = 35,
	}

	public enum BlockModelType : byte {
		None             = 0,
		FullBlockSimple  = 1,
		FullBlockComplex = 2,
		HalfBlockDown    = 3,
		HalfBlockUp      = 4,
		Stairs           = 5,
		Plate            = 6,
		Grass            = 7,
		HorizontalPlane  = 8,
		SmallerBlock     = 9,
		CrossedVPlanes   = 10,
	}

	public enum BlockHarvestLevel : byte {
		Any = 0,
		T1 = 1,
		T2 = 2,
		T3 = 3,
		T4 = 4,
		T5 = 5,
		None = 255
	}

	[System.Flags]
	public enum VisibilityFlags : byte {
		None     = 0,
		Right    = 1,
		Left     = 2,
		Up       = 4,
		Down     = 8,
		Forward  = 16,
		Backward = 32,
		All      = 63,
	}

	[System.Serializable]
	public sealed class BlockDescription {

		public BlockType                Type            = BlockType.Air;
		public BlockModelType           ModelType       = BlockModelType.FullBlockSimple;
		public BlockHarvestLevel        HarvestLevel    = BlockHarvestLevel.Any;
		public byte                     Hardness        = 5;
		public byte                     LightLevel      = 0;
		public bool                     IsSwimmable     = false;
		public bool                     IsFull          = true;
		public bool                     IsPassable      = false;
		public bool                     IsColorable     = true;
		public bool                     IsTranslucent   = false;
		public bool                     HasMetadata     = false;
		public bool                     GravityAffected = false;
		public byte                     ExtraData       = 0;
		public List<SubtypeDescription> Subtypes        = new List<SubtypeDescription>();

		public bool IsLightEmitting {
			get {
				return LightLevel > 0;
			}
		}
	}

	[System.Serializable]
	public sealed class SubtypeDescription {
		public List<Byte2> FaceTiles = new List<Byte2>();
	}
}
