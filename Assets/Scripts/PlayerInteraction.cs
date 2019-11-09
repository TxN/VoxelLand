using UnityEngine;

using Voxels.UI;

namespace Voxels {
	public sealed class PlayerInteraction : MonoBehaviour {
		const int MAX_SIGHT_DISTANCE = 32;

		public Vector3   CurrentInPos  { get; private set; } = Vector3.zero;
        public Vector3   CurrentOutPos { get; private set; } = Vector3.zero;
        public BlockData BlockInSight  { get; private set; } = BlockData.Empty;

		void Update() {
			var cm = ChunkManager.Instance;
			cm.ViewPosition = transform.position;
			var hitInfo = new RaycastHit();
			var dir = transform.TransformDirection(Vector3.forward);
			if ( Physics.Raycast(transform.position, dir, out hitInfo, MAX_SIGHT_DISTANCE) ) { //TODO: Chunk layermask
				CurrentInPos  = hitInfo.point + dir * 0.03f;
				CurrentOutPos = hitInfo.point - dir * 0.015f;
				var chunk = cm.GetChunkInCoords(CurrentInPos);
				if ( chunk != null ) {
					var block = cm.GetBlockIn(CurrentInPos);
					BlockInSight = block;

					if ( Input.GetMouseButtonUp(0) ) {
						cm.DestroyBlock(CurrentInPos);
					}
					if ( Input.GetKey(KeyCode.LeftShift)  && Input.GetMouseButtonUp(1) ) {
						var blockIn = cm.GetBlockIn(CurrentInPos);
						Debug.Log(string.Format("Interaction with {0}", blockIn.Type.ToString() ));
					} else if ( Input.GetMouseButtonUp(1) ) {
						//cm.PutBlock(CurrentOutPos, new BlockData(GameManager.Instance.Hotbar.SelectedBlock,0));
					}
				}
			} else {
				CurrentOutPos = Vector3.zero;
				CurrentInPos = Vector3.zero;
				BlockInSight = BlockData.Empty;
			}
		}

		void PaintBlockInSight(Color32 color) {
			var cm = ChunkManager.Instance;
			var blockIn = cm.GetBlockIn(CurrentInPos);
			if ( !blockIn.IsEmpty() ) {
				blockIn.AddColor = ColorUtils.ConvertTo565(color);
				cm.PutBlock(CurrentInPos, blockIn);
			}
		}

	}
}

