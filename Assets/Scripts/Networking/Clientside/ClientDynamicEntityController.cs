using System.Threading;
using System.Collections.Generic;

using UnityEngine;
using DataStructures.ViliWonka.KDTree;

namespace Voxels.Networking.Clientside {
	public class ClientDynamicEntityController : ClientsideController<ClientDynamicEntityController> {
		public ClientDynamicEntityController(ClientGameManager owner) : base(owner) { }

		const string ENTITY_PATH = "Client/DynamicEntities/";
		const int TREE_UPDATE_INTERVAL = 2000;

		Dictionary<uint, DynamicEntityClientside> _entities = new Dictionary<uint, DynamicEntityClientside>();

		Thread _threeRebuildThread = null;
		KDTree _entityPosTree = null;

		public override void Init() {
			base.Init();
			_threeRebuildThread = new Thread(TreeRebuildThread);
			_entityPosTree = new KDTree(16);
		}

		public override void Reset() {
			base.Reset();
			if ( _threeRebuildThread != null ) {
				_threeRebuildThread.Abort();
			}
		}

		public void SpawnEntity(uint uid, string typeName, Vector3 pos, Quaternion rot, byte[] data) {
			var e = GetPrefab(typeName);
			if ( e == null ) {
				Debug.LogError(string.Format("Cannot spawn entity type {0} with id {1}", typeName, uid));
				return;
			}
			e.transform.position = pos;
			e.transform.rotation = rot;
			if ( data != null && data.Length > 0 ) {
				e.DeserializeState(data);
			}
			e.Init();
			_entities.Add(uid, e);
		}

		public void DespawnEntity(uint uid) {
			var e = GetEntity(uid);
			if ( e ) {
				e.DeInit();
				Object.Destroy(e.gameObject);
			}
			_entities.Remove(uid);
		}

		public void UpdatePosition(uint uid, PosUpdateType type, Vector3 pos, Quaternion rot) {
			var e = GetEntity(uid);
			if ( e ) {
				e.UpdatePosition(type, pos, rot);
			}
		}

		public DynamicEntityClientside GetEntity(uint uid) {
			_entities.TryGetValue(uid, out var val);
			return val;
		}

		DynamicEntityClientside GetPrefab(string typeName) {
			var res = Resources.Load<GameObject>(ENTITY_PATH + typeName);
			if ( res == null ) {
				return null;
			}
			var obj = Object.Instantiate(res);
			obj.name = typeName;
			var e = obj.GetComponent<DynamicEntityClientside>();
			if ( !e ) {
				Object.Destroy(obj);
			}
			return e;
		}

		void TreeRebuildThread() {
			while(true) {
				Thread.Sleep(TREE_UPDATE_INTERVAL);
			}
		}
	}
}
