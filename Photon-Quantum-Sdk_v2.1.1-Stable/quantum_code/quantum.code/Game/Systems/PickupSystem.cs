using System;
using Photon.Deterministic;
namespace Quantum.Game;

public unsafe class PickupSystem : SystemMainThread, ISignalOnCollisionEnter3D {
	private Random _Random = new Random();
	private FP _SpawnRate;

	private FP _SpawnXRange;
	private FP _SpawnYRange;

	private FP _TempSpawnRate;
	private EntityPrototype _Asset;
	private FP _SpawnHeight;
	public override void OnInit(Frame f) {
		_SpawnRate = f.RuntimeConfig.SpawnRate;
		_SpawnXRange = f.RuntimeConfig.SpawnXRange;
		_SpawnYRange = f.RuntimeConfig.SpawnYRange;
		_SpawnHeight = f.RuntimeConfig.SpawnHeight;
		_TempSpawnRate = new FP();
		_Asset = f.FindAsset<EntityPrototype>("Resources/DB/FoodEntity|EntityPrototype");
	}

	public override void Update(Frame f) {
		_TempSpawnRate += f.DeltaTime;
		if (_TempSpawnRate >= _SpawnRate) {
			_TempSpawnRate = 0;
			// _SpawnRate = _Random.Next(0, _SpawnRate.AsInt);
			SpawnPickup(f);
		}
	}
	private void SpawnPickup(Frame frame) {
		var prototype = _Asset;
		var entity = frame.Create(prototype);
		if (frame.Unsafe.TryGetPointer<Transform3D>(entity, out var transform)) {
			transform->Position.X = _Random.Next(-_SpawnXRange.AsInt * 1000, _SpawnXRange.AsInt * 1000) / 1000;
			transform->Position.Y = _SpawnHeight + _Random.Next(-_SpawnYRange.AsInt * 1000, _SpawnYRange.AsInt * 1000) / 1000;
		}
	}
	public void OnCollisionEnter3D(Frame f, CollisionInfo3D info) {
		if (!f.Has<FoodScoreData>(info.Entity)) return;
		if (!f.Has<FoodDestroyerTag>(info.Other)) return;
		f.Destroy(info.Entity);
		
		
	}
}
