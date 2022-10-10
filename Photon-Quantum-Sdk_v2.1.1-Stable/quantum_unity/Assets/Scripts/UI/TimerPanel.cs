using TMPro;
using UnityEngine;
namespace View {
	public class TimerPanel : PanelView {

		[SerializeField]
		private TMP_Text _Text;
		public void SetTime(int time) {
			_Text.text = time.ToString("00:00");
		}

	}
}
