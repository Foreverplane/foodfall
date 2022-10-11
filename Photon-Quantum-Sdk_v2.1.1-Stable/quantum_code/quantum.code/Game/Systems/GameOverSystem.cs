namespace Quantum.Game;

public unsafe class GameOverSystem : SystemMainThread {

	public override void Update(Frame f) {
	
		if (f.Global->ElapsedTime >=f.RuntimeConfig.TotalGameTime) {
			f.Global->GameState = GameState.GameOver;
			f.SystemDisable<GameOverSystem>();
			f.SystemDisable<MovementSystem>();
			f.SystemDisable<PickupSystem>();
		}
	}
}
