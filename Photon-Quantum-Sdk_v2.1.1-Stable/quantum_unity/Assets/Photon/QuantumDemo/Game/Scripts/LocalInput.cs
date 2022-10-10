using System;
using Photon.Deterministic;
using Quantum;
using UnityEngine;

public class LocalInput : MonoBehaviour {
    
  private void OnEnable() {
    QuantumCallback.Subscribe(this, (CallbackPollInput callback) => PollInput(callback));
  }

  public void PollInput(CallbackPollInput callback) {
    Quantum.Input i = new Quantum.Input();
    i.Jump = PlayerInputSingleton.Instance.JumpIsPressed;
    var x = PlayerInputSingleton.Instance.MoveVector.x;
    i.Direction = new Vector2(x, 0).ToFPVector2();
    callback.SetInput(i, DeterministicInputFlags.Repeatable);
  }
}
