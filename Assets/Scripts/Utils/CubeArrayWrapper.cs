using ZeroFormatter;

namespace Voxels {
	public class CubeArrayWrapper<T> {

		[Index(3)]
		public virtual T[] Data {
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

		T[] _data = null;
		int _x = 0;
		int _y = 0;
		int _z = 0;

		public CubeArrayWrapper() {
		}

		public CubeArrayWrapper(int sizeX, int sizeY, int sizeZ) {
			_x = sizeX;
			_y = sizeY;
			_z = sizeZ;
			Data = new T[sizeX * sizeY * sizeZ];
		}

		[IgnoreFormat]
		public T this[int x, int y, int z] {
			get {
				return Data[y * _z * _x + z * _x + x];
			}
			set {
				Data[y * _z * _x + z * _x + x] = value;
			}
		}
	}
}
