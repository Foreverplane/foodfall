using UniRx;
using View;
using Zenject;
public class RunningStateUIService : UIService {

	[Inject]
	private TimerPanel _TimerPanel;
	public override void Initialize() {
		ServerData.RemainingTime.SkipLatestValueOnSubscribe().Subscribe(_ => {
			_TimerPanel.SetTime(_.AsInt);
		});
	}
}