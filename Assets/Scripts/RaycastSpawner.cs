using UnityEngine;

namespace Voxels {
	public sealed class RaycastSpawner : MonoBehaviour {
		public bool DrawDebugGUI = true;

		public GameObject Cursor = null;

		Vector3 _pointIn;
		Vector3 _pointOut;

		Rect DebugInBlock = new Rect(10, 10, 250, 50);
		Rect DebugOutBlock = new Rect(10, 70, 250, 50);

		private void Update() {
			var hitInfo = new RaycastHit();
			var dir =  transform.TransformDirection(Vector3.forward);
			if ( Physics.Raycast(transform.position, dir, out hitInfo, 100) ) {
				Cursor.transform.position = hitInfo.point;
				var cm = ChunkManager.Instance;
				_pointIn  = hitInfo.point + dir * 0.03f;
				_pointOut = hitInfo.point - dir * 0.015f;
				var chunk = cm.GetChunkInCoords(_pointIn);
				if ( chunk != null ) {
					var block = cm.GetBlockIn(_pointIn);
					if ( !block.IsEmpty() ) {
						if ( Input.GetMouseButtonUp(0) ) {
							cm.DestroyBlock(_pointIn);
						}

						if ( Input.GetKeyUp(KeyCode.G) ) {
							cm.PutBlock(_pointOut, new BlockData(BlockType.RedstoneLamp, 1, 0));
						}
                        if ( Input.GetKeyUp(KeyCode.H) ) {
                            cm.PutBlock(_pointOut, new BlockData(BlockType.Bricks, 0, 0));
                        }
					}
				}
			}
		}

		void OnGUI() {
			if ( !DrawDebugGUI ) {
				return;
			}
			var cm = ChunkManager.Instance;
			var blockIn  = cm.GetBlockIn(_pointIn);
			var blockOut = cm.GetBlockIn(_pointOut);
			GUI.Label(DebugInBlock,  string.Format("Inner: {0}, ambient: {1} sun: {2}", blockIn.Type, blockIn.LightLevel, blockIn.SunLevel));
			GUI.Label(DebugOutBlock, string.Format("Outer: {0}, ambient: {1} sun: {2}", blockOut.Type, blockOut.LightLevel, blockOut.SunLevel));
		}
	}

}
