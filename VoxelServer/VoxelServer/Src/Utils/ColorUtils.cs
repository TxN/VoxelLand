using UnityEngine;

public class ColorUtils {

	static byte[] Table5 = {0, 8, 16, 25, 33, 41, 49, 58, 66, 74, 82, 90, 99, 107, 115, 123, 132,
 140, 148, 156, 165, 173, 181, 189, 197, 206, 214, 222, 230, 239, 247, 255};

	static byte[] Table6 = {0, 4, 8, 12, 16, 20, 24, 28, 32, 36, 40, 45, 49, 53, 57, 61, 65, 69,
 73, 77, 81, 85, 89, 93, 97, 101, 105, 109, 113, 117, 121, 125, 130, 134, 138,
 142, 146, 150, 154, 158, 162, 166, 170, 174, 178, 182, 186, 190, 194, 198,
 202, 206, 210, 215, 219, 223, 227, 231, 235, 239, 243, 247, 251, 255};

	public static Color32 ConvertToColor32(byte h, byte l) {
		uint i = (uint)h * 256 + l;
		var r = i >> 11;
		var g = (i & 0b11111100000) >> 5;
		var b = i & 0b0000000000011111;
		return new Color32(Table5[r], Table6[g], Table5[b], 1);
	}

	public static ushort ConvertTo565(Color32 c) {
		var b = (c.b >> 3) & 0x1f;
		var g = ((c.g >> 2) & 0x3f) << 5;
		var r = ((c.r >> 3) & 0x1f) << 11;
		return (ushort)(r | g | b);
	}
}
