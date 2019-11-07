using ZeroFormatter;

namespace Voxels {
	[ZeroFormattable]
	public class BlockDataHolder {
		[Index(3)]
		public virtual BlockData[] Data {
			get {
				return _data;
			}
			set {
				_data = value;
			}
		}

		[Index(0)]
		public virtual int SizeX {
			get { return _x; }
			set { _x = value; }
		}

		[Index(1)]
		public virtual int SizeY {
			get { return _y; }
			set { _y = value; }
		}

		[Index(2)]
		public virtual int SizeZ {
			get { return _z; }
			set { _z = value; }
		}

		BlockData[] _data = null;
		int _x = 0;
		int _y = 0;
		int _z = 0;

		public BlockDataHolder() {

		}

		public BlockDataHolder(int sizeX, int sizeY, int sizeZ, BlockData[] arr) {
			_x = sizeX;
			_y = sizeY;
			_z = sizeZ;
			Data = arr;
		}

		public BlockDataHolder(int sizeX, int sizeY, int sizeZ) {
			_x = sizeX;
			_y = sizeY;
			_z = sizeZ;
			Data = new BlockData[sizeX * sizeY * sizeZ];
		}

		[IgnoreFormat]
		public BlockData this[int x, int y, int z] {
			get {
				return _data[y * _z * _x + z * _x + x];
			}
			set {
				_data[y * _z * _x + z * _x + x] = value;
			}
		}


	}
}

