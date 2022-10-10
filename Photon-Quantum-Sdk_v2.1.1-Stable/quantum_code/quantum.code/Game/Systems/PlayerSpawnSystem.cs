namespace Quantum.Game;

public unsafe class PlayerSpawnSystem : SystemSignalsOnly, ISignalOnPlayerDataSet {
	public void OnPlayerDataSet(Frame frame, PlayerRef player) {
		var data = frame.GetPlayerData(player);
		
		var prototype = frame.FindAsset<EntityPrototype>(data.PlayerPrototype.Id);

		var entity = frame.Create(prototype);
		if (frame.Unsafe.TryGetPointer<PlayerLink>(entity, out var playerLink))
			playerLink->Player = player;

		if (frame.Unsafe.TryGetPointer<Transform3D>(entity, out var transform)) {
			transform->Position.X = 0 + player;
		}
	}
}