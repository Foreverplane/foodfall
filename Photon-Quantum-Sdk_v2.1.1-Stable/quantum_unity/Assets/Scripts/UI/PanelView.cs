using System;
using UnityEngine;
namespace View {
	public abstract class PanelView : UIElementView {
		[SerializeField]
		private Canvas _Canvas;

		public Canvas Canvas => _Canvas;

		private void OnValidate() {
			_Canvas = GetComponent<Canvas>();
		}
	}
}