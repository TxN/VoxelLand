using System.Collections.Generic;

using UnityEngine;

using SMGCore.EventSys;
using Voxels.UI;
using Voxels.Networking.Events;

using JetBrains.Annotations;

namespace Voxels.Networking.Clientside {

	public class ClientUIManager : ClientsideController<ClientUIManager> {
		public ClientUIManager(ClientGameManager owner) : base(owner) { }

		const string MAIN_UI_PREFAB_PATH = "ClientUICanvas";

		GameObject _mainCanvas = null;

		public Hotbar Hotbar { get; private set; }

		public override void Init() {
			base.Init();
			var canvasFab = Resources.Load(MAIN_UI_PREFAB_PATH);
			_mainCanvas   = Object.Instantiate((GameObject) canvasFab, null);
			Hotbar        = _mainCanvas.GetComponentInChildren<Hotbar>();
		}

	}
}