using System;
using System.Collections.Generic;
using Photon.Deterministic;
namespace Quantum.Game;

public unsafe class PickupSystem : SystemMainThread, ISignalOnCollisionEnter3D {
	private const int K = 1000;
	private readonly Random _Random = new Random();

	private FP _PickupsAmount;
	private string FoodPath => $"Resources/DB/Food/FoodEntity {_Random.Next(0, _PickupsAmount.AsInt)}|EntityPrototype";
	public override void OnInit(Frame f) {
		// Log.Debug("PickupSystem initialized");
		_PickupsAmount = f.RuntimeConfig.PickupsAmount;
	}

	public override void Update(Frame f) {
		if(!f.IsVerified)
			return;
		// Log.Debug($"Frame: {f.Number} v {f.IsVerified} p {f.IsPredicted}");
		f.Global->TempSpawnTime += f.DeltaTime;
		if (f.Global->TempSpawnTime >= f.RuntimeConfig.SpawnRate) {
			f.Global->TempSpawnTime = 0;
			SpawnPickup(f);
		}
	}
	private void SpawnPickup(Frame frame) {
		// Log.Debug("Spawn Pickup");
		var prototype = frame.FindAsset<EntityPrototype>(FoodPath);
		var entity = frame.Create(prototype);
		if (frame.Unsafe.TryGetPointer<PhysicsBody3D>(entity, out var physicsBody3D)) {
			physicsBody3D->Velocity = FPVector3.Zero;
			physicsBody3D->AngularVelocity = FPVector3.Zero;
		}
		if (frame.Unsafe.TryGetPointer<Transform3D>(entity, out var transform)) {
			transform->Position.X = _Random.Next(-frame.RuntimeConfig.SpawnXRange.AsInt * K, frame.RuntimeConfig.SpawnXRange.AsInt * K) / K;
			transform->Position.Y = frame.RuntimeConfig.SpawnHeight + _Random.Next(-frame.RuntimeConfig.SpawnYRange.AsInt * K, frame.RuntimeConfig.SpawnYRange.AsInt * K) / K;
		}
	}
	public void OnCollisionEnter3D(Frame f, CollisionInfo3D info) {
		if (!f.Has<FoodScoreData>(info.Entity)) return;
		if (!f.Has<FoodDestroyerTag>(info.Other)) return;
		if (f.DestroyPending(info.Entity)) return;
		// Log.Debug("Collision");
		var score = f.Get<FoodScoreData>(info.Entity);
		if (f.Unsafe.TryGetPointer<PlayerLink>(info.Other, out var link)) {
			f.Signals.ChangePlayerScore(score.Score, link->Player);
		}
		f.Destroy(info.Entity); // TODO: pooling
	}
}
