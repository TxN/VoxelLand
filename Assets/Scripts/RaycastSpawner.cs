using UnityEngine;

namespace Voxels {
	public sealed class RaycastSpawner : MonoBehaviour {
		public bool DrawDebugGUI = true;

		Vector3 _pointIn;
		Vector3 _pointOut;

		Rect DebugInBlock = new Rect(10, 10, 250, 40);
		Rect DebugOutBlock = new Rect(10, 60, 250, 40);

		private void Update() {
			var cm = ChunkManager.Instance;
			cm.ViewPosition = transform.position;
			var hitInfo = new RaycastHit();
			var dir =  transform.TransformDirection(Vector3.forward);
			if ( Physics.Raycast(transform.position, dir, out hitInfo, 100) ) {
				_pointIn  = hitInfo.point + dir * 0.03f;
				_pointOut = hitInfo.point - dir * 0.015f;
				var chunk = cm.GetChunkInCoords(_pointIn);//Баг: если нет чанка, создается непрорегеннный чанк, который потом не заполнятеся.
				if ( chunk != null ) {
					var block = cm.GetBlockIn(_pointIn);
					if ( !block.IsEmpty() ) {
						if ( Input.GetMouseButtonUp(0) ) {
							cm.DestroyBlock(_pointIn);
						}

						if ( Input.GetKeyUp(KeyCode.G) ) {
							cm.PutBlock(_pointOut, new BlockData(BlockType.RedstoneLamp, 1));
						}
                        if ( Input.GetKeyUp(KeyCode.H) ) {
                            cm.PutBlock(_pointOut, new BlockData(BlockType.Bricks, 0));
                        }
						if ( Input.GetKeyUp(KeyCode.B) ) {
							cm.PutBlock(_pointOut, new BlockData(BlockType.Weed, 0));
						}
						if ( Input.GetKeyUp(KeyCode.V) ) {
							cm.PutBlock(_pointOut, new BlockData(BlockType.WaterStill, 0));
						}
						if ( Input.GetKeyUp(KeyCode.T) ) {
							cm.PutBlock(_pointOut, new BlockData(BlockType.Leaves, 0));
						}
						if ( Input.GetKeyUp(KeyCode.Y) ) {
							cm.PutBlock(_pointOut, new BlockData(BlockType.Log, 0));
						}
						if ( Input.GetKeyUp(KeyCode.Alpha1) ) {
							var blockIn = cm.GetBlockIn(_pointIn);
							if ( !blockIn.IsEmpty() ) {
								blockIn.AddColor = ColorUtils.ConvertTo565(new Color32(255, 0, 0, 1));
								cm.PutBlock(_pointIn, blockIn);
							}
						}
						if ( Input.GetKeyUp(KeyCode.Alpha2) ) {
							var blockIn = cm.GetBlockIn(_pointIn);
							if ( !blockIn.IsEmpty() ) {
								blockIn.AddColor = ColorUtils.ConvertTo565(new Color32(0, 255, 0, 1));
								cm.PutBlock(_pointIn, blockIn);
							}
						}
						if ( Input.GetKeyUp(KeyCode.Alpha3) ) {
							var blockIn = cm.GetBlockIn(_pointIn);
							if ( !blockIn.IsEmpty() ) {
								blockIn.AddColor = ColorUtils.ConvertTo565(new Color32(0, 0, 255, 1));
								cm.PutBlock(_pointIn, blockIn);
							}
						}
						if ( Input.GetKeyUp(KeyCode.Alpha4) ) {
							var blockIn = cm.GetBlockIn(_pointIn);
							if ( !blockIn.IsEmpty() ) {
								blockIn.AddColor = ColorUtils.ConvertTo565(new Color32(0, 255, 255, 1));
								cm.PutBlock(_pointIn, blockIn);
							}
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
