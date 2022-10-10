using Quantum;
using UniRx;
using UnityEngine;
namespace View {
	public abstract class PlayerInfoView : MonoBehaviour {
		
		[SerializeField]
		private RuntimePlayerToViewProvider Provider;

		protected ReactiveProperty<RuntimePlayer> Player => Provider.RuntimePlayer;
		private void OnValidate() {
			Provider = GetComponent<RuntimePlayerToViewProvider>();
		}
	}
}
