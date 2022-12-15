using System.Collections.Generic;

using UnityEngine;

using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Utils;

using JetBrains.Annotations;

namespace Voxels.Networking.Serverside {
	public class ServerPlayerEntityManager : ServerSideController<ServerPlayerEntityManager> {
		public ServerPlayerEntityManager(ServerGameManager owner) : base(owner) { }

		//TODO: Get spawn points from worldgen
		public Vector3 DefaultSpawnPoint = new Vector3(0, 60, 0);

		public List<PlayerEntity> Players = new List<PlayerEntity>();

		public override void Load() {
			base.Load();
		}

		public override void PostLoad() {
			base.PostLoad();
			EventManager.Subscribe<OnServerReadyToSpawnNewPlayer>   (this, OnNeedClientSpawn);
			EventManager.Subscribe<OnClientDisconnected>(this, OnClientDisconnect);
		}

		public override void Save() {
			base.Save();
		}

		public override void Reset() {
			base.Reset();
			EventManager.Unsubscribe<OnServerReadyToSpawnNewPlayer>   (OnNeedClientSpawn);
			EventManager.Unsubscribe<OnClientDisconnected>(OnClientDisconnect);
		}

		public override void Update() {
			base.Update();
			/*foreach ( var p in Players ) {
				if ( VoxelsUtils.Cast(p.Position, -Vector3.up, 1f, VoxelsUtilsServerside.IsBlockSolid, out var result) ) {
					//Debug.DrawLine(p.Position, result.HitPosition);
				}
			}
			*/
		}

		public bool GetBlockInSight(PlayerEntity player, out Vector3 blockPos, out BlockData block) {
			blockPos = Vector3.zero;
			block = BlockData.Empty;
			if ( player == null ) {				
				return false;
			}
			var lookDir = GetPlayerLookDirection(player);
			var isCast = ServerChunkManager.Instance.CollisionHelper.Cast(CastType.AnyBlock, player.Position + Vector3.up * 0.5f, lookDir, PlayerInteraction.MAX_SIGHT_DISTANCE, out var result);
			if ( isCast ) {
				blockPos = result.HitPosition + lookDir * 0.03f;
				block = ServerChunkManager.Instance.GetBlockIn(blockPos);
				return true;
			}
			return false;
		}

		public Vector3 GetPlayerLookDirection(PlayerEntity player) {
			if ( player == null) {
				return Vector3.forward;
			}

			var rot = Quaternion.Euler(player.LookDir.x, player.LookDir.y, 0);
			return rot * Vector3.forward;
		}

		public Vector3 GetSpawnPosition(PlayerEntity player) {
			var info = ServerSaveLoadController.Instance.GetPlayerInfo(player.PlayerName);
			if ( info != null ) {
				return info.SpawnPoint;
			}
			return DefaultSpawnPoint;
		}

		public Vector3 GetSpawnPosition(ClientState client) {
			var info = ServerSaveLoadController.Instance.GetPlayerInfo(client.UserName);
			if ( info != null ) {
				return info.SpawnPoint;
			}
			return DefaultSpawnPoint;
		}

		public Vector3 GetHomePosition(ClientState client) {
			var info = ServerSaveLoadController.Instance.GetPlayerInfo(client.UserName);
			if ( info != null ) {
				return info.HomePoint;
			}
			return DefaultSpawnPoint;
		}

		public Vector3 GetLastSavedPosition(ClientState client) {
			var info = ServerSaveLoadController.Instance.GetPlayerInfo(client.UserName);
			if ( info != null ) {
				return info.LastSavedPos;
			}
			return DefaultSpawnPoint;
		}

		public void BroadcastPlayerUpdate(ClientState client, PlayerEntity newInfo) {
			var server = ServerController.Instance;
			var player = GetPlayerByOwner(client);
			player.Position = newInfo.Position;
			player.LookDir  = newInfo.LookDir;
			
			server.SendToAll(ServerPacketID.PlayerUpdate, new S_PlayerUpdateMessage { Player = player });
		}

		public void BroadcastPlayerPosUpdate(ClientState client, Vector3 newPos, byte rawPitch, byte rawYaw, PosUpdateOptions flags = PosUpdateOptions.None) {
			var server = ServerController.Instance;
			var player = GetPlayerByOwner(client);
			var pitch = MathUtils.Remap(rawPitch, 0, 255, 0, 360);
			var yaw   = MathUtils.Remap(rawYaw, 0, 255, 0, 360);
			player.Position = newPos;
			player.LookDir  = new Vector2(pitch, yaw);
			
			server.SendToAll(ServerPacketID.PlayerPosAndRotUpdate, new S_PosAndOrientationUpdateMessage {
				CommandID = (byte) flags,
				ConId     = (ushort)client.ConnectionID,
				Position  = newPos,
				LookPitch = rawPitch,
				Yaw       = rawYaw
			});
		}

		[CanBeNull]
		public PlayerEntity GetPlayerByOwner(ClientState owner) {
			foreach ( var player in Players ) {
				if ( player.Owner == owner ) {
					return player;
				}
			}
			return null;
		}

		public void SetSpawnPoint(string playerName, Vector3 spawnPoint) {
			//TODO: check if position is valid
			var sc = ServerSaveLoadController.Instance;
			var info = sc.GetPlayerInfo(playerName);
			if ( info != null ) {
				info.SpawnPoint = spawnPoint;
				sc.UpdatePlayerInfo(info);
			}			
		}

		public void SetHomePoint(string playerName, Vector3 spawnPoint) {
			//TODO: check if position is valid
			var sc = ServerSaveLoadController.Instance;
			var info = sc.GetPlayerInfo(playerName);
			if ( info != null ) {
				info.HomePoint = spawnPoint;
				sc.UpdatePlayerInfo(info);
			}
		}

		void SpawnPlayer(ClientState client) {
			var sc = ServerSaveLoadController.Instance;
			var info = sc.GetPlayerInfo(client.UserName);
			if ( info == null ) {
				info = new PlayerEntitySaveInfo {
					Name = client.UserName,
					SpawnPoint = DefaultSpawnPoint,
					HomePoint = DefaultSpawnPoint,
					LastSavedPos = DefaultSpawnPoint,
					UsedSkinName = "default"
				};
				sc.UpdatePlayerInfo(info);
			}
			var player = new PlayerEntity { Owner = client, PlayerName = client.UserName, Position = info.LastSavedPos, ConId = (ushort)client.ConnectionID };
			Players.Add(player);
			var server = ServerController.Instance;
			server.SendToAll(ServerPacketID.PlayerSpawn, new S_SpawnPlayerMessage { PlayerToSpawn = player });
			EventManager.Fire(new OnServerPlayerSpawn { Player = player, Client = client });

			//send all entities
			ServerDynamicEntityController.Instance.RegisterClient(player, client);
		}

		void DespawnPlayer(ClientState client) {
			var toDespawn = GetPlayerByOwner(client);		
			if ( toDespawn == null ) {
				return;
			}
			var sc = ServerSaveLoadController.Instance;
			var info = sc.GetPlayerInfo(client.UserName);

			info.LastSavedPos = toDespawn.Position;
			sc.UpdatePlayerInfo(info);
			EventManager.Fire(new OnServerPlayerDespawn { Player = toDespawn });
			var server = ServerController.Instance;
			server.SendToAll(ServerPacketID.PlayerDespawn, new S_DespawnPlayerMessage { PlayerToDespawn = toDespawn });
			Players.Remove(toDespawn);

			ServerDynamicEntityController.Instance.UnregisterClient(client);
		}

		void SendAllPlayers(ClientState receiver) {
			var server = ServerController.Instance;
			foreach ( var player in Players ) {
				server.SendNetMessage(receiver, ServerPacketID.PlayerSpawn, new S_SpawnPlayerMessage { PlayerToSpawn = player });
			}
		}

		void OnNeedClientSpawn(OnServerReadyToSpawnNewPlayer e) {
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
