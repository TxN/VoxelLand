using System.IO;

using UnityEngine;

namespace Voxels {
	public sealed class SaveLoadManager {

		const string SaveDirPath = "Save/";
		string _saveName = "testSave";


		public string CurrentSaveName {
			get { return _saveName; }
		}

		public string SavePath {
			get {
				return string.Format("{0}{1}/", SaveDirPath, CurrentSaveName);
			}
		}

		public void Save() {
			var path = SavePath;
			if ( !Directory.Exists(path) ) {
				Directory.CreateDirectory(path);
			}
			var file = File.Create(SavePath + "state");
			var writer = new BinaryWriter(file);
			ChunkManager.Instance.Save(writer);
			file.Close();
		}

		public void Load() {
			var path = SavePath;
			if ( !Directory.Exists(path) ) {
				return;
			}
			var file = File.OpenRead(SavePath + "state");
			var reader = new BinaryReader(file);
			ChunkManager.Instance.Load(reader);
			file.Close();
		}

		public void CheckSaveDir() {
			if ( !Directory.Exists(SavePath) ) {
				Directory.CreateDirectory(SavePath);
			}
		}
	}

}
