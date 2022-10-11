using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
namespace View {
	public class GameOverPanel : PanelView {
		[SerializeField]
		private Transform _ScoreElementsRoot;
		[SerializeField]
		private EndGameInfoView _ScoreElementPrefab;
		public void SetupInfos(List<EndGameInfoElementData> endGameInfos) {
			var sorted = endGameInfos.OrderByDescending(_ => _.Scores);
			foreach (var endGameStatElement in sorted) {
				var instance = Object.Instantiate(_ScoreElementPrefab,_ScoreElementsRoot);
				instance.Setup(endGameStatElement);
			}
		}
	}

}
