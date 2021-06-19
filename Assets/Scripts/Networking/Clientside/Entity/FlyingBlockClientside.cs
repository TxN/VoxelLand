
using ZeroFormatter;

namespace Voxels.Networking.Clientside.Entities {
	public sealed class FlyingBlockClientside : DynamicEntityClientside {
		public override string EntityType {
			get {
				return "FlyingBlock";
			}
		}

		public BlockData PresentedBlock { get; private set; }

		SingleBlockPresenter _presenter = null;

		public override void Init() {
			base.Init();
			_presenter = GetComponentInChildren<SingleBlockPresenter>();
			_presenter.Init();
			_presenter.DrawBlock(PresentedBlock);
		}

		public override void DeInit() {
			base.DeInit();
			if ( _presenter ) {
				_presenter.RemoveBlock();
			}
		}

		public override void DeserializeState(byte[] state) {
			if ( state == null || state.Length == 0 ) {
				return;
			}
			var result = ZeroFormatterSerializer.Deserialize<FlyingBlockClientState>(state);
			if ( result != null ) {
				PresentedBlock = result.BlockData;
			}
		}
	}

	[ZeroFormattable]
	public class FlyingBlockClientState {
		[Index(0)]
		public virtual BlockData BlockData { get; set; }
	}
}

