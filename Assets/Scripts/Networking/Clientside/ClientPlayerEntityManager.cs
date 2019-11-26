using System.Collections.Generic;

using UnityEngine;

using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Utils;

using JetBrains.Annotations;

namespace Voxels.Networking.Clientside {
	public class ClientPlayerEntityManager : ClientsideController<ClientPlayerEntityManager> {
		public ClientPlayerEntityManager(ClientGameManager owner) : base(owner) { }

		const string PLAYER_PREFAB_PATH = "Player";
		const string PROXY_PREFAB_PATH  = "PlayerProxy";

		List<PlayerEntity> _players = new List<PlayerEntity>();

		PlayerEntity _cachedPlayer = null;

		[CanBeNull]
		public PlayerEntity LocalPlayer {
			get {
				if ( _cachedPlayer == null ) {
					_cachedPlayer = GetPlayer(ClientController.Instance.ClientName);
				}
				return _cachedPlayer;
			}
		}

		public bool IsLocalPlayer(PlayerEntity player) {
			if ( player == null ) {
				return false;
			}
			return player.PlayerName == ClientController.Instance.ClientName;
		}

		[CanBeNull]
		public PlayerEntity GetPlayer(string name) {
			foreach ( var player in _players ) {
				if ( player.PlayerName == name ) {
					return player;
				}
			}
			return null;
		}

		[CanBeNull]
		public PlayerEntity GetPlayer(ushort conId) {
			foreach ( var player in _players ) {
				if ( player.ConId == conId ) {
					return player;
				}
			}
			return null;
		}

		public void SpawnPlayer(PlayerEntity newPlayer) {
			_players.Add(newPlayer);
			var prefabPath = IsLocalPlayer(newPlayer) ? PLAYER_PREFAB_PATH : PROXY_PREFAB_PATH;
			var playerGo   = Object.Instantiate(Resources.Load(prefabPath), newPlayer.Position, Quaternion.identity) as GameObject;
			playerGo.name  = newPlayer.PlayerName;
			playerGo.transform.rotation = Quaternion.Euler(0, newPlayer.LookDir.y, 0);
			var playerView = playerGo.GetComponent<PlayerMovement>();
			newPlayer.View = playerView;
			playerView.Setup(newPlayer);
			Debug.LogFormat("Spawn player '{0}'", newPlayer.PlayerName);
			EventManager.Fire(new OnClientPlayerSpawn { Player = newPlayer });
		}

		public void DespawnPlayer(PlayerEntity toDespawn) {
			Debug.LogFormat("Client: despawn command received for {0}", toDespawn.PlayerName);
			var localEntity = GetPlayer(toDespawn.PlayerName);
			if ( localEntity == null ) {
				return;
			}
			EventManager.Fire(new OnClientPlayerDespawn { Player = localEntity });
			_players.Remove(localEntity);
		}

		public void UpdatePlayer(PlayerEntity newInfo) {
			var localEntity = GetPlayer(newInfo.ConId);
			if ( localEntity == null ) {
				return;
			}
			localEntity.Position = newInfo.Position;
			localEntity.LookDir  = newInfo.LookDir;
			
			EventManager.Fire(new OnClientPlayerUpdate { Player = localEntity });
		}

		public void UpdatePlayerPos(ushort conId, Vector3 newPos, byte rawPitch, byte rawYaw) {
			var localEntity = GetPlayer(conId);
			if ( localEntity == null ) {
				return;
			}
			localEntity.Position = newPos;
			var pitch = MathUtils.Remap(rawPitch, 0, 255, 0, 360);
			var yaw   = MathUtils.Remap(rawYaw,   0, 255, 0, 360);
			localEntity.LookDir = new Vector2(pitch, yaw);
			EventManager.Fire(new OnClientPlayerUpdate { Player = localEntity });
		}

		public void SendPosUpdateToServer(PlayerEntity senderInfo, Vector3 position, float yaw, float pitch) {
			if ( senderInfo == null || !IsLocalPlayer(senderInfo) ) {
				return;
			}
			senderInfo.Position = position;
			senderInfo.LookDir = new Vector2(pitch, yaw);
			ClientController.Instance.SendNetMessage(ClientPacketID.PlayerPosAndRotUpdate, new C_PosAndOrientationUpdateMessage {
				Position  = position,
				LookPitch = (byte)Mathf.RoundToInt(MathUtils.Remap(pitch, 0, 360, 0, 255)),
				Yaw       = (byte)Mathf.RoundToInt(MathUtils.Remap(yaw,   0, 360, 0, 255)),
			});
		}
	}
}
