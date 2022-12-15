using System;
using System.Collections.Generic;
using System.Text;

namespace ZeroFormatter.DynamicObjectSegments.UnityEngine {
	using global::System;
	using global::ZeroFormatter.Formatters;
	using global::ZeroFormatter.Internal;
	using global::ZeroFormatter.Segments;

	public class Vector3Formatter<TTypeResolver> : Formatter<TTypeResolver, global::UnityEngine.Vector3>
		where TTypeResolver : ITypeResolver, new() {
		readonly Formatter<TTypeResolver, float> formatter0;
		readonly Formatter<TTypeResolver, float> formatter1;
		readonly Formatter<TTypeResolver, float> formatter2;

		public override bool NoUseDirtyTracker {
			get {
				return formatter0.NoUseDirtyTracker
					&& formatter1.NoUseDirtyTracker
					&& formatter2.NoUseDirtyTracker
				;
			}
		}

		public Vector3Formatter() {
			formatter0 = Formatter<TTypeResolver, float>.Default;
			formatter1 = Formatter<TTypeResolver, float>.Default;
			formatter2 = Formatter<TTypeResolver, float>.Default;

		}

		public override int? GetLength() {
			return 12;
		}

		public override int Serialize(ref byte[] bytes, int offset, global::UnityEngine.Vector3 value) {
			BinaryUtil.EnsureCapacity(ref bytes, offset, 12);
			var startOffset = offset;
			offset += formatter0.Serialize(ref bytes, offset, value.x);
			offset += formatter1.Serialize(ref bytes, offset, value.y);
			offset += formatter2.Serialize(ref bytes, offset, value.z);
			return offset - startOffset;
		}

		public override global::UnityEngine.Vector3 Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize) {
			byteSize = 0;
			int size;
			var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
			offset += size;
			byteSize += size;
			var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
			offset += size;
			byteSize += size;
			var item2 = formatter2.Deserialize(ref bytes, offset, tracker, out size);
			offset += size;
			byteSize += size;

			return new global::UnityEngine.Vector3(item0, item1, item2);
		}
	}

	public class Vector2Formatter<TTypeResolver> : Formatter<TTypeResolver, global::UnityEngine.Vector2>
		where TTypeResolver : ITypeResolver, new() {
		readonly Formatter<TTypeResolver, float> formatter0;
		readonly Formatter<TTypeResolver, float> formatter1;

		public override bool NoUseDirtyTracker {
			get {
				return formatter0.NoUseDirtyTracker
					&& formatter1.NoUseDirtyTracker
				;
			}
		}

		public Vector2Formatter() {
			formatter0 = Formatter<TTypeResolver, float>.Default;
			formatter1 = Formatter<TTypeResolver, float>.Default;

		}

		public override int? GetLength() {
			return 8;
		}

		public override int Serialize(ref byte[] bytes, int offset, global::UnityEngine.Vector2 value) {
			BinaryUtil.EnsureCapacity(ref bytes, offset, 8);
			var startOffset = offset;
			offset += formatter0.Serialize(ref bytes, offset, value.x);
			offset += formatter1.Serialize(ref bytes, offset, value.y);
			return offset - startOffset;
		}

		public override global::UnityEngine.Vector2 Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize) {
			byteSize = 0;
			int size;
			var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
			offset += size;
			byteSize += size;
			var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
			offset += size;
			byteSize += size;

			return new global::UnityEngine.Vector2(item0, item1);
		}
	}


}