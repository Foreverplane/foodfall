using Quantum;
using UniRx;
using View;
using Zenject;
public class GameOverStateUIService : UIService {

	[Inject]
	private GameOverPanel _GameOverPanel;
	

	[Inject]
	private EndGameData _EndGameData;
	public override void Initialize() {
		ServerData.GameState.SkipLatestValueOnSubscribe().Subscribe(_ => {
			if(_ != GameState.GameOver)
				return;

			var endGameInfos = _EndGameData.RequestInfoForEndGame();
			_GameOverPanel.SetupInfos(endGameInfos);
		});
	}
}
