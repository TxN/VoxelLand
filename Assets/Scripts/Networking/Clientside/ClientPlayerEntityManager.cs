using UnityEngine;

using System.Collections.Generic;

namespace Voxels.Networking.Clientside {
	public class ClientPlayerEntityManager : ClientsideController<ClientPlayerEntityManager> {
		public ClientPlayerEntityManager(ClientGameManager owner) : base(owner) { }

		List<PlayerEntity> _players = new List<PlayerEntity>();

		

		public void GetPlayer(string name) {

		}

		public void SpawnPlayer() {

		}

		public void DespawnPlayer() {

		}
	}
}
