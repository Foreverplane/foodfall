using Features.Restart;
using Features.UI;
using UnityEngine;
using View;
using Zenject;

public class GameInstaller : MonoInstaller {

	[SerializeField]
	private UIPanelContainer _PanelContainer;

	public override void InstallBindings() {
		SignalBusInstaller.Install(Container);
		Container.DeclareSignal<FinishButtonSignal>().RequireSubscriber();
		Container.BindInterfacesAndSelfTo<ServerData>().AsSingle();
		Container.BindInterfacesAndSelfTo<EndGameData>().AsSingle();
		BindSignalSources();
		BindUIPanels();
		Container.BindInterfacesAndSelfTo<GameUIService>().AsSingle();
		Container.BindInterfacesAndSelfTo<PrepareStateUIService>().AsSingle();
		Container.BindInterfacesAndSelfTo<RunningStateUIService>().AsSingle();
		Container.BindInterfacesAndSelfTo<GameOverStateUIService>().AsSingle();
		Container.BindInterfacesAndSelfTo<RestartEverythingService>().AsSingle();
		Container.BindSignal<FinishButtonSignal>().ToMethod<RestartEverythingService>(_ => _.RequestRestart).FromResolve();
	}
	private void BindSignalSources() {
		var signalSources = _PanelContainer.GetComponentsInChildren<ISignalSourceView>(true);
		foreach (var signalSource in signalSources) {
			Container.Inject(signalSource);
		}
	}
	private void BindUIPanels() {
		foreach (var panelView in _PanelContainer.Panels) {
			Container.Bind(panelView.GetType()).FromInstance(panelView).AsSingle();
		}
		Container.BindInterfacesAndSelfTo<UIPanelContainer>().FromInstance(_PanelContainer).AsSingle();
	}
}
