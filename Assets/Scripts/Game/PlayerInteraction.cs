using UnityEngine;

using Voxels.UI;
using Voxels.Networking.Clientside;

namespace Voxels {
	public sealed class PlayerInteraction : MonoBehaviour {
		const int MAX_SIGHT_DISTANCE = 32;
		 
		public Vector3   CurrentInPos   { get; private set; } = Vector3.zero;
        public Vector3   CurrentOutPos  { get; private set; } = Vector3.zero;
        public BlockData BlockInSight   { get; private set; } = BlockData.Empty;
        public BlockData BlockOutSight  { get; private set; } = BlockData.Empty;

		public LayerMask EntityColMask;

		Collider[] _colCache = new Collider[16];

		void Update() {
			var cm = ClientChunkManager.Instance;
			var hitInfo = new RaycastHit();
			var dir = transform.TransformDirection(Vector3.forward);
			if ( Physics.Raycast(transform.position, dir, out hitInfo, MAX_SIGHT_DISTANCE) ) { //TODO: Chunk layermask
				CurrentInPos  = hitInfo.point + dir * 0.03f;
				CurrentOutPos = hitInfo.point - dir * 0.015f;

				var chunk = cm.GetChunkInCoords(CurrentInPos);
				if ( chunk != null ) {
					var block = cm.GetBlockIn(CurrentInPos);
					BlockInSight = block;
					var outBlock = cm.GetBlockIn(CurrentOutPos);
					BlockOutSight = outBlock;
					if ( Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonUp(1) ) {
						var blockIn = cm.GetBlockIn(CurrentInPos);
						Debug.Log(string.Format("Interaction with {0}", blockIn.Type.ToString()));
					} else if ( Input.GetMouseButtonUp(1) && CanPlaceBlock(CurrentOutPos) ) {
						cm.PutBlock(CurrentOutPos, new BlockData(ClientUIManager.Instance.Hotbar.SelectedBlock, 0));
					} else if ( Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonUp(0) ) {
						PaintBlockInSight(new Color32(255, 0, 0, 255));
					} else if ( Input.GetMouseButtonUp(0) ) {
						cm.DestroyBlock(CurrentInPos);
					}
				}
			} else {
				CurrentOutPos = Vector3.zero;
				CurrentInPos  = Vector3.zero;
				BlockInSight  = BlockData.Empty;
				BlockOutSight = BlockData.Empty;
			}
		}

		bool CanPlaceBlock(Vector3 pos ) {
			var floorPos = new Vector3(Mathf.Floor(pos.x), Mathf.Floor(pos.y), Mathf.Floor(pos.z)) + new Vector3(0.5f, 0.5f, 0.5f);
			var collisions =  Physics.OverlapBoxNonAlloc(floorPos, new Vector3(0.5f, 0.5f, 0.5f), _colCache, Quaternion.identity, EntityColMask);
			return collisions == 0;
		}

		void PaintBlockInSight(Color32 color) {
			var cm = ClientChunkManager.Instance;
			var blockIn = cm.GetBlockIn(CurrentInPos);
			if ( !blockIn.IsEmpty() ) {
				blockIn.AddColor = ColorUtils.ConvertTo565(color);
				cm.PutBlock(CurrentInPos, blockIn);
			}
		}

	}
}

