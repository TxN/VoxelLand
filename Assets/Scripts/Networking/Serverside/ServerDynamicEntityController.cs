using System.Collections.Generic;

using UnityEngine;

namespace Voxels.Networking.Serverside {
	public class ServerDynamicEntityController : ServerSideController<ServerDynamicEntityController> {
		public const float NET_TICK_TIME = 0.1f;
		public const float TICK_TIME     = 0.05f;

		Dictionary<uint, DynamicEntityServerside>     _entities     = new Dictionary<uint, DynamicEntityServerside>();
		Dictionary<ClientState, PlayerEntityObserver> _netObservers = new Dictionary<ClientState, PlayerEntityObserver>();

		public ServerDynamicEntityController(ServerGameManager owner) : base(owner) { }

		float _lastTickTime    = 0f;
		float _lastNetSendTime = -0.03f;

		uint _curUID = 0;

		public IEnumerable<DynamicEntityServerside> AllEntities {
			get {
				return _entities.Values;
			}
		}

		public override void Update() {
			base.Update();

			if ( Time.time > _lastTickTime + TICK_TIME ) {
				Tick();
				_lastTickTime = Time.time;
			}

			if ( Time.time > _lastNetSendTime + NET_TICK_TIME ) {
				NetTick();
				_lastNetSendTime = Time.time;
			}
		}

		public void SpawnEntity<T>(Vector3 pos, Quaternion rot, uint uid = 0, byte[] data = null) where T: DynamicEntityServerside, new() {
			var entity = new T();
			if ( uid == 0 ) {
			 	uid = GetNewUID();
			}
			entity.UID = uid;
			entity.Mover.Position = pos;
			entity.Mover.Rotation = rot;
			if ( data != null ) {
				entity.DeserializeState(data);
			}
			entity.Init();
			_entities.Add(uid, entity);
			//TODO: Rebuild

			var sc = ServerController.Instance;
			var state = entity.SerializeViewState();
			foreach ( var item in _netObservers ) {
				sc.SendNetMessage(item.Key, ServerPacketID.SpawnEntity, new S_SpawnEntityMessage { UID = uid, Position = pos,
					Rotation = entity.Mover.PackedRotation, TypeName = entity.EntityType, State = state });
				item.Value.Entities.Add(uid, entity);
			}
		}

		public uint GetNewUID() {
			_curUID++;
			return _curUID;
		}

		public void DestroyEntity(uint uid) {
			var sc = ServerController.Instance;
			foreach ( var item in _netObservers ) {
				if ( item.Value.Entities.ContainsKey(uid) ) {
					sc.SendNetMessage(item.Key, ServerPacketID.DespawnEntity, new S_DespawnEntityMessage { UID = uid });
					item.Value.Entities.Remove(uid);
				}
			}
			_entities.Remove(uid);
			//TODO:Rebuild
		}

		public void RegisterClient(PlayerEntity player, ClientState client) {
			var state = new PlayerEntityObserver { Client = client, Player = player };
			_netObservers.Add(client, state);
		}

		public void UnregisterClient(ClientState client) {
			_netObservers.Remove(client);
		}

		void Tick() {
			foreach ( var p in _entities ) {
				p.Value.Tick();
			}
		}

		void NetTick() {
			var sc = ServerController.Instance;
			foreach ( var p in _entities ) {
				var e = p.Value;
				e.NetTick();
				if ( e.Mover.NeedSendUpdate ) {
					var msg = e.Mover.GetPosUpdateMessage(out var t);
					foreach ( var op in _netObservers ) {
						var c = op.Value;
						if ( c.Entities.ContainsKey(e.UID) ) {
							if ( t == PosUpdateType.Pos ) {
								sc.SendRawNetMessage(op.Key, ServerPacketID.UpdateEntityPos, msg);
							} else if ( t == PosUpdateType.Rot ) {
								sc.SendRawNetMessage(op.Key, ServerPacketID.UpdateEntityRot, msg);
							} else {
								sc.SendRawNetMessage(op.Key, ServerPacketID.UpdateEntityPosRot, msg);
							}
							
						}
					}
					e.Mover.UpdateSent();
				}
			}
		}
	}

	public sealed class PlayerEntityObserver {
		public PlayerEntity Player = null;
		public ClientState  Client = null;
		public Dictionary<uint, DynamicEntityServerside> Entities = new Dictionary<uint, DynamicEntityServerside>();
		public float LastUpdateTime = 0f;
	}
}

