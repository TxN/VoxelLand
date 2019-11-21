using ZeroFormatter;

namespace Voxels {
	[ZeroFormattable]
	public class VisibilityFlagsHolder {
		[Index(3)]
		public virtual VisibilityFlags[] Data {
			get {
				return _data;
			}
			set {
				_data = value;
			}
		}
		VisibilityFlags[] _data = null;

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

		int _x = 0;
		int _y = 0;
		int _z = 0;

		public VisibilityFlagsHolder() {
		}

		public VisibilityFlagsHolder(int sizeX, int sizeY, int sizeZ, VisibilityFlags[] arr) {
			_x = sizeX;
			_y = sizeY;
			_z = sizeZ;
			Data = arr;
		}

		public VisibilityFlagsHolder(int sizeX, int sizeY, int sizeZ) {
			_x = sizeX;
			_y = sizeY;
			_z = sizeZ;
			Data = new VisibilityFlags[sizeX * sizeY * sizeZ];
		}

		[IgnoreFormat]
		public VisibilityFlags this[int x, int y, int z] {
			get {
				return _data[y * _z * _x + z * _x + x];
			}
			set {
				_data[y * _z * _x + z * _x + x] = value;
			}
		}
	}
}

