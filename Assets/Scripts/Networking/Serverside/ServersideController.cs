using UnityEngine;

namespace Voxels.Networking {
	public abstract class BaseServersideController {
		protected ServerGameManager Owner { get; }

		protected BaseServersideController(ServerGameManager owner) {
			Owner = owner;
		}

		public abstract string DebugName { get; }

		public virtual void Init() { }
		public virtual void PostInit() { }

		public virtual void Load() { }
		public virtual void PostLoad() { }

		public virtual void Save() { }

		public virtual void Update() { }
		public virtual void Reset() { }
	}

	public class ServerSideController<T> : BaseServersideController where T : ServerSideController<T> {
		public static T Instance { get; private set; }

		string _debugName = string.Empty;

		public override string DebugName {
			get {
				if ( string.IsNullOrEmpty(_debugName) ) {
					_debugName = typeof(T).Name;
				}
				return _debugName;
			}
		}

		protected ServerSideController(ServerGameManager owner) : base(owner) {
			if ( Instance != null ) {
				var text = string.Format(
					"StateController<{0}>. Instance already created!",
					typeof(T).Name);
				throw new UnityException(text);
			}
			Instance = this as T;
		}

		public override void Reset() {
			Instance = null;
		}
	}
}
