namespace Quantum.Game;

public unsafe class TimeSystem : SystemMainThread {
	public override void Update(Frame f) {
		f.Global->ElapsedTime += f.DeltaTime;
	}
}
