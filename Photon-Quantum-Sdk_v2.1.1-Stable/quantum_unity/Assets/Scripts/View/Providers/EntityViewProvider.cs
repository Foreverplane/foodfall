using UnityEngine;
namespace View {
	public class EntityViewProvider : MonoBehaviour {
		[SerializeField]
		protected EntityView EntityView;
		private void OnValidate() {
			EntityView = GetComponent<EntityView>();
		}
	}
}
