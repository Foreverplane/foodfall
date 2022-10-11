using Photon.Deterministic;
namespace Quantum.Game;

public unsafe class MovementSystem : SystemMainThreadFilter<MovementSystem.Filter> {
	public struct Filter {
		public EntityRef EntityRef;
		public CharacterController3D* CharacterController3D;
		public Transform3D* Transform3D;
		public PlayerLink* PlayerLink;
	}
	public override void Update(Frame f, ref Filter filter) {

		var input = f.GetPlayerInput(filter.PlayerLink->Player);
		if (input->Jump.WasPressed)
			filter.CharacterController3D->Jump(f);
		//speed hack protection
		input->Direction = input->Direction.Normalized;
		var fpVector3 = input->Direction.XOY;
		filter.CharacterController3D->Move(f, filter.EntityRef, fpVector3);
		// filter.Transform3D->Rotation = input->Direction != default ? FPQuaternion.LookRotation(fpVector3) : filter.Transform3D->Rotation;
	}
}