using Quantum;
using UniRx;
using UnityEngine;
namespace View {
	public abstract class ComponentToViewProvider<T> : EntityViewProvider where T : unmanaged, IComponent {
		[field: SerializeField]
		public ReactiveProperty<T> Component = new ReactiveProperty<T>();
		
		private void Update() {
			if(base.EntityView.EntityRef==default)
				return;
			Component.SetValueAndForceNotify(QuantumRunner.Default.Game.Frames.Predicted.Get<T>(base.EntityView.EntityRef));
		}

	}
}
