namespace Quantum.Game;

public unsafe class PrepareGameSystem : SystemMainThread{

	public override void OnInit(Frame f) {
		f.Global->GameState = GameState.Prepare;
		f.SystemDisable<MovementSystem>();
	}
	public override void Update(Frame f)
	{
		f.Global->GameTime += f.DeltaTime;
		if (f.Global->GameTime >= f.RuntimeConfig.PrepareTime)
		{
			StartGame(f);
		}
	}
	private void StartGame(Frame f) {
		if (!f.IsVerified)
			return;
		f.SystemDisable<PrepareGameSystem>();

		f.SystemEnable<MovementSystem>();
		f.Global->GameState = GameState.Running;
		f.Global->GameTime = 0;
		f.Signals.SwitchGameState(GameState.Running);
		f.Events.SwitchGameState(GameState.Running);
	}
}
