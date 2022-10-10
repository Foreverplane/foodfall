using System;
using UnityEngine;
using View;
public class UIPanelContainer : MonoBehaviour {
	[SerializeField]
	private PanelView[] _PanelViews;

	public PanelView[] Panels => _PanelViews;
	void OnValidate() {
		_PanelViews = GetComponentsInChildren<PanelView>(true);
	}
	public void ShowPanel<T>() {
		foreach (var panelView in _PanelViews) {
			panelView.Canvas.enabled = panelView.GetType() == typeof(T);
		}
	}
	public void ShowPanels(Type[] activePanels) {
		foreach (var panelView in _PanelViews) {
			panelView.Canvas.enabled = Array.Exists(activePanels, x => x == panelView.GetType());
		}
	}
}
