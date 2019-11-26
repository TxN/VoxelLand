namespace Voxels.Networking.Serverside {
	public abstract class ChatCommand {
		public virtual string Keyword { get; }
		public virtual bool   OpOnly  { get; }
		public abstract string ProcessCommand(ClientState sender, string[] commandWords);
		
	}
}

