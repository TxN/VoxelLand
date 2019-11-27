using UnityEngine;
using UnityEditor;

using Voxels;

public class CreateLibraryAssetAction {
	[MenuItem("Assets/Create/Tileset Resource Asset")]
	public static void CreateMyAsset() {
		ResourceLibrary asset = ScriptableObject.CreateInstance<ResourceLibrary>();

		AssetDatabase.CreateAsset(asset, "Assets/Resources/ResourceLibrary_new.asset");
		AssetDatabase.SaveAssets();

		EditorUtility.FocusProjectWindow();
		Selection.activeObject = asset;
	}
}
