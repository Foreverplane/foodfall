using TMPro;
using UniRx;

namespace View {

	public class NicknameView : PlayerInfoView {
		public TMP_Text Text;

		private void Start() {
			base.Player.Subscribe((rPlayer) => {
				Text.text = rPlayer?.Nickname;
			});
		}
	}
}
