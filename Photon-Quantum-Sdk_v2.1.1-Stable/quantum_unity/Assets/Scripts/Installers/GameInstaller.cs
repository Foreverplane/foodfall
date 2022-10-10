using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller {

	[SerializeField]
	private UIPanelContainer _PanelContainer;
	public override void InstallBindings() {
		Container.BindInterfacesAndSelfTo<ServerData>().AsSingle();
		foreach (var panelView in _PanelContainer.Panels) {
			Container.Bind(panelView.GetType()).FromInstance(panelView).AsSingle();
		}
		Container.BindInterfacesAndSelfTo<UIPanelContainer>().FromInstance(_PanelContainer).AsSingle();
		Container.BindInterfacesAndSelfTo<GameUIService>().AsSingle();
		Container.BindInterfacesAndSelfTo<PrepareStateUIService>().AsSingle();
		Container.BindInterfacesAndSelfTo<RunningStateUIService>().AsSingle();
	}
}
