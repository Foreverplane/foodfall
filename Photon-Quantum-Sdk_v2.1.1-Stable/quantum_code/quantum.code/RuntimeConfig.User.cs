using Photon.Deterministic;
using System;

namespace Quantum {
  partial class RuntimeConfig {
	  public FP PrepareTime;
	  public FP GameTime;
	  partial void SerializeUserData(BitStream stream) {
		  stream.Serialize(ref PrepareTime);
		  stream.Serialize(ref GameTime);
	  }

  }
}