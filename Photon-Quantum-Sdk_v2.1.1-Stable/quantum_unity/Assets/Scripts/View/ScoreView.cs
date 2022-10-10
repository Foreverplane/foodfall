using System;
using Quantum;
using TMPro;
using UniRx;
namespace View {
	public class ScoreView : ComponentToViewProvider<PlayerScore> {
		public TMP_Text Text;

		private void Start() {
			Component.Subscribe(score => Text.text = score.Score.ToString("00")).AddTo(this);
		}
	}

}
