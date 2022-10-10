﻿using Photon.Deterministic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quantum {
	partial class RuntimePlayer {
		public AssetRefEntityPrototype PlayerPrototype;

		partial void SerializeUserData(BitStream stream) {
			stream.Serialize(ref PlayerPrototype.Id);
		}
	}
}
