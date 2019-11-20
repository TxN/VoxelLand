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

		public List<PlayerEntity> Players = new List<PlayerEntity>();

		//TODO: load player list and spawn points
		public override void Load() {
			base.Load();
		}

		public override void PostLoad() {
			base.PostLoad();
			EventManager.Subscribe<OnClientConnected>   (this, OnClientJoin);
			EventManager.Subscribe<OnClientDisconnected>(this, OnClientDisconnect);
		}

		public override void Reset() {
			base.Reset();
			EventManager.Unsubscribe<OnClientConnected>   (OnClientJoin);
			EventManager.Unsubscribe<OnClientDisconnected>(OnClientDisconnect);
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
			foreach ( var player in Players ) {
				if ( player.Owner == owner ) {
					return player;
				}
			}
			return null;
		}

		void SpawnPlayer(ClientState client) {
			var player = new PlayerEntity { Owner = client, PlayerName = client.UserName, Position = DefaultSpawnPoint };
			Players.Add(player);
			var server = ServerController.Instance;
			server.SendToAll(ServerPacketID.PlayerSpawn, new S_SpawnPlayerMessage { PlayerToSpawn = player });
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
			Players.Remove(toDespawn);
		}

		void SendAllPlayers(ClientState receiver) {
			var server = ServerController.Instance;
			foreach ( var player in Players ) {
				server.SendNetMessage(receiver, ServerPacketID.PlayerSpawn, new S_SpawnPlayerMessage { PlayerToSpawn = player });
			}
		}

		void OnClientJoin(OnClientConnected e) {
			Debug.LogFormat("Sending to {0} all player spawn", e.State.UserName);
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
