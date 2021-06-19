using UnityEngine;

using Voxels.Networking.Clientside.Entities;

using ZeroFormatter;

namespace Voxels.Networking.Serverside.Entities {
	public class FlyingBlockServerside : DynamicEntityServerside {
		public BlockData PresentedBlock     { get; set; }
		public ushort    MaxAge             { get; set; } = 40;
		public ushort    Age                { get; set; } = 0;
		public bool      UseGravity         { get; set; } = true;
		public FlyingBlockContactBehaviour ContactAction { get; set; }

		public override string EntityType {
			get {
				return "FlyingBlock";
			}
		}

		public override void Init() {
			Mover.Radius = 0.5f;
			Mover.UpHeight = 0.5f;
			Mover.DownHeight = 0.5f;
			Mover.FreeMove = false;
			Mover.Buoyant = false;
			Mover.GravityEnabled = UseGravity;
		}

		public override void Tick() {
			base.Tick();
			Age += 1;

			if ( Age > MaxAge ) {
				ServerDynamicEntityController.Instance.DestroyEntity(UID);
				return;
			}

			if ( ContactAction != FlyingBlockContactBehaviour.Nothing && Mover.IsGrounded ) {			
				if ( ContactAction == FlyingBlockContactBehaviour.SpawnBlock ) {
					ServerChunkManager.Instance.PutBlock(Mover.Position, PresentedBlock);
				}
				ServerDynamicEntityController.Instance.DestroyEntity(UID);
			}
		}

		public override byte[] SerializeViewState() {
			return ZeroFormatterSerializer.Serialize(new FlyingBlockClientState { BlockData = PresentedBlock });
		}

		public override byte[] SerializeState() {
			return ZeroFormatterSerializer.Serialize(new FlyingBlockServerState { Block = PresentedBlock, Age = Age, ContactAction = ContactAction,
			MaxAge = MaxAge, MoveDirection = Mover.Velocity});
		}
	}

	public enum FlyingBlockContactBehaviour : byte {
		Nothing    = 0,
		Die        = 1,
		SpawnBlock = 2,
	}
	
	[ZeroFormattable]
	public class FlyingBlockServerState {
		[Index(0)]
		public virtual BlockData Block         { get; set; }

		[Index(1)]
		public virtual ushort    MaxAge        { get; set; }
		[Index(2)]
		public virtual ushort    Age           { get; set; }
		[Index(3)]
		public virtual Vector3   MoveDirection { get; set; }
		[Index(4)]
		public virtual FlyingBlockContactBehaviour ContactAction { get; set; }
	}

}
