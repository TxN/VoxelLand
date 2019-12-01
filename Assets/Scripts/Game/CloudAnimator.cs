using System.Collections.Generic;

using UnityEngine;

namespace Voxels.Networking.Clientside {
	public sealed class CloudAnimator : MonoBehaviour {
		public float            CloudAltitude  = 130;
		public int              CloudCount     = 50;
		public float            SpawnRadius    = 350;
		public List<GameObject> CloudFabs      = new List<GameObject>();
		public Vector3          MoveDirection;

		List<GameObject> _preparedFabs = new List<GameObject>();
		Material         _cloudMat     = null;
		bool             _inited       = false;
		void Start() {
			TryInit();
		}

		void TryInit() {
			if (_inited ) {
				return;
			}
			var pc = ClientPlayerEntityManager.Instance;
			if ( pc == null ) {
				return;
			}
			var ply = pc.LocalPlayer;
			if ( ply == null ) {
				return;
			}
			_inited = true;

			_cloudMat = Instantiate(CloudFabs[0].GetComponent<Renderer>().material);
			for ( int i = 0; i < CloudCount; i++ ) {
				var circ = Random.insideUnitCircle * SpawnRadius;
				var pos = new Vector3(ply.Position.x + circ.x, CloudAltitude, circ.y + ply.Position.z);
				var fab = CloudFabs[Random.Range(0, CloudFabs.Count)];
				var obj = Instantiate(fab, pos, fab.transform.rotation, transform);
				obj.GetComponent<Renderer>().material = _cloudMat;
				obj.SetActive(true);
				_preparedFabs.Add(obj);
			}
		}

		void Update() {
			TryInit();
			var pc = ClientPlayerEntityManager.Instance;
			if ( pc == null ) {
				return;
			}
			var ply = pc.LocalPlayer;
			if ( ply == null ) {
				return;
			}
			var pos = new Vector3(ply.Position.x, 50, ply.Position.z);

			foreach ( var item in _preparedFabs ) {
				item.transform.position += Time.deltaTime * MoveDirection;
				if ( Vector3.Distance(pos, item.transform.position) > 500 ) {
					var circ = Random.onUnitSphere * SpawnRadius;
					var p = new Vector3(ply.Position.x + circ.x, CloudAltitude, circ.y + ply.Position.z);
					item.transform.position = p;
				}

			}
			_cloudMat.SetFloat("_SunLevel", ClientWorldStateController.Instance.AmbientLightIntensity);
		}
	}
}
