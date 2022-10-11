using Photon.Deterministic;
using System;

namespace Quantum {
  partial class RuntimeConfig {
	  public FP PrepareTime;
	  public FP GameTime;
	  public FP PickupsAmount;
	  public FP SpawnRate;
	  public FP SpawnXRange;
	  public FP SpawnYRange;
	  public FP SpawnHeight;
	  public FP TotalGameTime => GameTime + PrepareTime;

	  partial void SerializeUserData(BitStream stream) {
		  stream.Serialize(ref PrepareTime);
		  stream.Serialize(ref GameTime);
		  stream.Serialize(ref SpawnRate);
		  stream.Serialize(ref SpawnXRange);
		  stream.Serialize(ref SpawnYRange);
		  stream.Serialize(ref SpawnHeight);
		  stream.Serialize(ref PickupsAmount);
	  }

  }
}