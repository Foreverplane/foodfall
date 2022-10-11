using TMPro;
using UnityEngine;
namespace View {
	public class EndGameInfoView : MonoBehaviour {

		[SerializeField]
		private TMP_Text _NickName;
		[SerializeField]
		private TMP_Text _Scores;
		
		public void Setup(EndGameInfoElementData endGameInfoElementData) {
			_NickName.text = endGameInfoElementData.NickName.ToString();
			_Scores.text = endGameInfoElementData.Scores.ToString();
		}
	}
}
