using UnityEngine;
using System.Collections.Generic;

using SMGCore.EventSys;
using Voxels.Networking.Events;

using JetBrains.Annotations;

namespace Voxels.Networking.Serverside {
	public class ServerPlayerEntityManager : ServerSideController<ServerPlayerEntityManager> {
		public ServerPlayerEntityManager(ServerGameManager owner) : base(owner) { }

		//TODO: Get spawn points from worldgen
		public Vector3 DefaultSpawnPoint = new Vector3(0, 60, 0);

		public List<PlayerEntity> _players = new List<PlayerEntity>();

		//TODO: load player list and spawn points
		public override void Load() {
			base.Load();
		}

		public override void PostLoad() {
			base.PostLoad();
		}

		public override void Reset() {
			base.Reset();
		}

		public void BroadcastPlayerUpdate(ClientState client, PlayerEntity newInfo) {
			var server = ServerController.Instance;
			var player = GetPlayerByOwner(client);
			player.Position = newInfo.Position;
			player.LookDir  = newInfo.LookDir;
			
			server.SendToAll(ServerPacketID.PlayerUpdate, new S_PlayerUpdateMessage { Player = player });
		}

		[CanBeNull]
		PlayerEntity GetPlayerByOwner(ClientState owner) {
			foreach ( var player in _players ) {
				if ( player.Owner == owner ) {
					return player;
				}
			}
			return null;
		}

		void SpawnPlayer(ClientState client) {
			var player = new PlayerEntity { Owner = client, PlayerName = client.UserName, Position = DefaultSpawnPoint };
			_players.Add(player);
			EventManager.Fire<OnServerPlayerSpawn>(new OnServerPlayerSpawn { Player = player });
		}

		void DespawnPlayer(ClientState client) {
			var toDespawn = GetPlayerByOwner(client);
			if ( toDespawn == null ) {
				return;
			}
			EventManager.Fire<OnServerPlayerDespawn>(new OnServerPlayerDespawn { Player = toDespawn });
			var server = ServerController.Instance;
			server.SendToAll(ServerPacketID.PlayerDespawn, new S_DespawnPlayerMessage { PlayerToDespawn = toDespawn });
			_players.Remove(toDespawn);
		}

		void SendAllPlayers(ClientState receiver) {
			var server = ServerController.Instance;
			foreach ( var player in _players ) {
				server.SendNetMessage(player.Owner, ServerPacketID.PlayerSpawn, new S_SpawnPlayerMessage { PlayerToSpawn = player });
			}
		}

		void OnClientJoin(OnClientConnected e) {
			//send all live players to client
			SendAllPlayers(e.State);
			//spawn new player
			SpawnPlayer(e.State);
		}

		void OnClientDisconnect(OnClientDisconnected e) {
			DespawnPlayer(e.State);
		}
	}
}
