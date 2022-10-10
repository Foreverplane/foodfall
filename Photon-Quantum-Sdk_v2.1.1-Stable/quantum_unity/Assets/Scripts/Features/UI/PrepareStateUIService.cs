using UniRx;
using View;
using Zenject;

public class PrepareStateUIService : UIService {
	private const string FORMAT = "0";

	[Inject]
	private TextPanel _TextPanel;

	public override void Initialize() {
		ServerData.PrepareTime.SkipLatestValueOnSubscribe().Subscribe(_ => {
			var val = _.AsInt;
			_TextPanel.SetText(val.ToString(FORMAT));
		});
	}
}