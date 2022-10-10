using Photon.Deterministic;
using Quantum;
using UniRx;
using UnityEngine;
using Zenject;
public class ServerData : IInitializable, ITickable {
	public readonly ReactiveProperty<FP> ElapsedTime = new ReactiveProperty<FP>();
	public readonly ReactiveProperty<FP> PrepareTime = new ReactiveProperty<FP>();
	public readonly ReactiveProperty<FP> RemainingTime = new ReactiveProperty<FP>();
	public readonly ReactiveProperty<GameState> GameState = new ReactiveProperty<GameState>();

	public void Initialize() {
		QuantumCallback.SubscribeManual(this, (CallbackGameStarted c) => OnGameStarted(c.Game));
		QuantumEvent.SubscribeManual<EventSwitchGameState>(this, SwitchGameState);
		// PrepareTime = QuantumRunner.Default.Game.Frames.Verified.RuntimeConfig.PrepareTime;
	}
	private void SwitchGameState(EventSwitchGameState callback) {
		Debug.Log($"SwitchGameState: {callback.TargetState}");
	}
	private void OnGameStarted(QuantumGame callbackGame) {
		Debug.Log("Game Started");
	}
	public unsafe void Tick() {
		var game = QuantumRunner.Default.Game;
		var framesVerified = game.Frames.Verified;
		if (framesVerified == default) return;
		var verifiedGlobal = framesVerified.Global;
		var elapsedTime = verifiedGlobal->ElapsedTime;
		ElapsedTime.Value = elapsedTime;
		var gameState = verifiedGlobal->GameState;
		GameState.Value = gameState;
		var gameTime = verifiedGlobal->GameTime;
		RemainingTime.Value = framesVerified.RuntimeConfig.GameTime + framesVerified.RuntimeConfig.PrepareTime - elapsedTime;
		PrepareTime.Value = gameState == Quantum.GameState.Prepare ? framesVerified.RuntimeConfig.PrepareTime - elapsedTime : PrepareTime.Value;
	}
}
