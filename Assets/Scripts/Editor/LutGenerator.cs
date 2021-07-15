using System.IO;

using UnityEngine;

public sealed class LutGenerator : MonoBehaviour {
	void Start() {
		var tex = new Texture2D(256, 256, TextureFormat.RGB24, false);
		for ( int x = 0; x < 256; x++ ) {
			for ( int y = 0; y < 256; y++ ) {
				tex.SetPixel(x, y, ColorUtils.ConvertToColor32( (byte)x, (byte)y));
			}
		}
		tex.Apply();
		var data = tex.EncodeToPNG();
		File.WriteAllBytes(Application.dataPath + "/../lut.png", data);
	}
}
