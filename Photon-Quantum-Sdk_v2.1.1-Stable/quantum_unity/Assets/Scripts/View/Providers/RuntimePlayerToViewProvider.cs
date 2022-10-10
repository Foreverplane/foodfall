using System;
using Photon.Deterministic;
using Quantum;
using UniRx;
using UnityEngine;
namespace View {

	public class RuntimePlayerToViewProvider : EntityViewProvider {
		private EntityRef _EntityRef;
	

		public ReactiveProperty<RuntimePlayer> RuntimePlayer = new ReactiveProperty<RuntimePlayer>();

		private void Awake() {
			EntityView.OnEntityInstantiated.AddListener(Init);
		}
		private void Init(IDeterministicGame game) {
			_EntityRef = GetComponent<EntityView>().EntityRef;
			if (_EntityRef == default) {
				Debug.LogError("Smth wrong with entity ref");
				return;
			}
			var frame = QuantumRunner.Default.Game.Frames.Verified;
			if (frame.TryGet<PlayerLink>(_EntityRef, out var pd)) {
				var playerData = frame.GetPlayerData(pd.Player);
				Debug.Log($"Set name: {playerData.Nickname}");
				RuntimePlayer.SetValueAndForceNotify(playerData);
			}
			else {
				Debug.LogError($"There is no PlayerLink for EntityRef {_EntityRef.Index}");
			}
		}
	}
}
