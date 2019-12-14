using System.Linq;
using System.Collections.Generic;

using UnityEngine;

using SMGCore.EventSys;
using Voxels.Networking.Events;
using Voxels.Utils;

using JetBrains.Annotations;

namespace Voxels.Networking.Serverside {
	public class ServerPlayerEntityManager : ServerSideController<ServerPlayerEntityManager> {
		public ServerPlayerEntityManager(ServerGameManager owner) : base(owner) { }

		const string SAVE_DATA_FILE_NAME = "players.dat";

		//TODO: Get spawn points from worldgen
		public Vector3 DefaultSpawnPoint = new Vector3(0, 60, 0);

		public List<PlayerEntity> Players = new List<PlayerEntity>();

		Dictionary<string, PlayerEntitySaveInfo> _playersData = new Dictionary<string, PlayerEntitySaveInfo>();

		//TODO: load player list and spawn points
		public override void Load() {
			base.Load();
			var loadedHolder = ServerSaveLoadController.Instance.LoadSaveFile<PlayerEntityControllerDataHolder>(SAVE_DATA_FILE_NAME);
			if ( loadedHolder != null ) {
				_playersData.Clear();
				foreach ( var item in loadedHolder.DataArray ) {
					if ( item == null ) {
						continue;
					}
					_playersData.Add(item.Name, item);
				}
			}
		}

		public override void PostLoad() {
			base.PostLoad();
			EventManager.Subscribe<OnServerReadyToSpawnNewPlayer>   (this, OnNeedClientSpawn);
			EventManager.Subscribe<OnClientDisconnected>(this, OnClientDisconnect);
		}

		public override void Save() {
			base.Save();
			var saveData = new PlayerEntityControllerDataHolder {
				DataArray = _playersData.Values.ToArray()
			};
			ServerSaveLoadController.Instance.SaveFileToDisk(SAVE_DATA_FILE_NAME, saveData);
		}

		public override void Reset() {
			base.Reset();
			EventManager.Unsubscribe<OnServerReadyToSpawnNewPlayer>   (OnNeedClientSpawn);
			EventManager.Unsubscribe<OnClientDisconnected>(OnClientDisconnect);
		}

		public override void Update() {
			base.Update();
			foreach ( var p in Players ) {
				if ( VoxelsUtils.Cast(p.Position, -Vector3.up, 1f, IsBlockSolid, out var result) ) {
					//Debug.DrawLine(p.Position, result.HitPosition);
				}
			}
		}

		bool IsBlockSolid(Int3 index) {
			var cm = ServerChunkManager.Instance;
			var lib = VoxelsStatic.Instance.Library;
			var block = cm.GetBlockIn(index.X, index.Y, index.Z);
			return !lib.GetBlockDescription(block.Type).IsPassable;
		}

		public Vector3 GetSpawnPosition(PlayerEntity player) {
			if ( _playersData.TryGetValue(player.PlayerName, out var data) ) {
				return data.SpawnPoint;
			}
			return DefaultSpawnPoint;
		}

		public Vector3 GetSpawnPosition(ClientState client) {
			if ( _playersData.TryGetValue(client.UserName, out var data) ) {
				return data.SpawnPoint;
			}
			return DefaultSpawnPoint;
		}

		public Vector3 GetHomePosition(ClientState client) {
			if ( _playersData.TryGetValue(client.UserName, out var data) ) {
				return data.HomePoint;
			}
			return DefaultSpawnPoint;
		}

		public Vector3 GetLastSavedPosition(ClientState client) {
			if ( _playersData.TryGetValue(client.UserName, out var data) ) {
				return data.LastSavedPos;
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
			var yaw   = MathUtils.Remap(rawPitch, 0, 255, 0, 360);
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
			if ( _playersData.TryGetValue(playerName, out var data) ) {
				data.SpawnPoint = spawnPoint;
			}
		}

		public void SetHomePoint(string playerName, Vector3 spawnPoint) {
			//TODO: check if position is valid
			if ( _playersData.TryGetValue(playerName, out var data) ) {
				data.HomePoint = spawnPoint;
			}
		}

		void SpawnPlayer(ClientState client) {
			_playersData.TryGetValue(client.UserName, out var data);
			if ( data == null ) {
				data = new PlayerEntitySaveInfo {
					Name = client.UserName,
					SpawnPoint = DefaultSpawnPoint,
					HomePoint = DefaultSpawnPoint,
					LastSavedPos = DefaultSpawnPoint,
					UsedSkinName = "default"
				};
				_playersData.Add(client.UserName, data);
			}
			var player = new PlayerEntity { Owner = client, PlayerName = client.UserName, Position = data.LastSavedPos, ConId = (ushort)client.ConnectionID };
			Players.Add(player);
			var server = ServerController.Instance;
			server.SendToAll(ServerPacketID.PlayerSpawn, new S_SpawnPlayerMessage { PlayerToSpawn = player });
			EventManager.Fire(new OnServerPlayerSpawn { Player = player, Client = client });
		}

		void DespawnPlayer(ClientState client) {
			var toDespawn = GetPlayerByOwner(client);		
			if ( toDespawn == null ) {
				return;
			}
			var data = _playersData[client.UserName];
			data.LastSavedPos = toDespawn.Position;
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
