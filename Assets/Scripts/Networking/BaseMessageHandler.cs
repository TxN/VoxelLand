namespace Voxels.Networking {
	public abstract class BaseClientMessageHandler {
		public virtual ClientPacketID CommandId {
			get {
				return ClientPacketID.None;
			}
		}

		public virtual void ProcessMessage(Serverside.ClientState client, byte[] rawCommand) { }
	}

	public abstract class BaseServerMessageHandler {
		public virtual ServerPacketID CommandId {
			get {
				return ServerPacketID.None;
			}
		}

		public virtual void ProcessMessage(byte[] rawCommand) { }
	}
}

