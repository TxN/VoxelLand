using System.Collections.Generic;

using UnityEngine;

using SMGCore.EventSys;
using Voxels.Networking.Events;

using JetBrains.Annotations;

namespace Voxels.Networking.Clientside {
	public class ClientPlayerEntityManager : ClientsideController<ClientPlayerEntityManager> {
		public ClientPlayerEntityManager(ClientGameManager owner) : base(owner) { }

		const string PLAYER_PREFAB_PATH = "Player";

		List<PlayerEntity> _players = new List<PlayerEntity>();

		PlayerEntity _cachedPlayer = null;

		bool _controlEnabled = true;
		//TODO: Move to GUI controller
		public bool IsPlayerControlEnabled { get {
				return LocalPlayer != null && _controlEnabled;
			}
			set {
				_controlEnabled = value;
			}
		}

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

		public void SpawnPlayer(PlayerEntity newPlayer) {
			_players.Add(newPlayer);

			var playerGo = Object.Instantiate(Resources.Load(PLAYER_PREFAB_PATH), newPlayer.Position, Quaternion.identity) as GameObject;
			playerGo.name = newPlayer.PlayerName;
			var playerView = playerGo.GetComponent<PlayerMovement>();
			newPlayer.View = playerView;
			playerView.Setup(newPlayer);
			Debug.LogFormat("Spawn player '{0}'", newPlayer.PlayerName);
			EventManager.Fire(new OnClientPlayerSpawn { Player = newPlayer });
		}

		public void DespawnPlayer(PlayerEntity toDespawn) {
			var localEntity = GetPlayer(toDespawn.PlayerName);
			if ( localEntity == null ) {
				return;
			}
			EventManager.Fire(new OnClientPlayerDespawn { Player = localEntity });
			Object.Destroy(localEntity.View.gameObject);
			_players.Remove(localEntity);
		}

		public void UpdatePlayer(PlayerEntity newInfo) {
			var localEntity = GetPlayer(newInfo.PlayerName);
			if ( localEntity == null ) {
				return;
			}
			localEntity.Position = newInfo.Position;
			localEntity.LookDir  = newInfo.LookDir;
			EventManager.Fire(new OnClientPlayerUpdate { Player = localEntity });
		}

		public void SendUpdateToServer(PlayerEntity senderInfo) {
			if ( senderInfo == null || !IsLocalPlayer(senderInfo) ) {
				return;
			}
			ClientController.Instance.SendNetMessage(ClientPacketID.PlayerUpdate, new C_PlayerUpdateMessage { PlayerInfo = senderInfo });
		}
	}
}
