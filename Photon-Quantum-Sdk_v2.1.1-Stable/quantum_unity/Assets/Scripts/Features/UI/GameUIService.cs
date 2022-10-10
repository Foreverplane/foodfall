
using System;
using System.Collections.Generic;
using Quantum;
using UnityEngine;
using View;
using Zenject;
using UniRx;

public class GameUIService : IInitializable {

	[Inject]
	private UIPanelContainer _PanelContainer;
	[Inject]
	private ServerData _ServerData;

	private readonly Dictionary<GameState, Type[]> _PanelsToStateMap = new Dictionary<GameState, Type[]>() {
		{ GameState.None, new Type[] { typeof(TextPanel) } },
		{ GameState.Prepare, new Type[] { typeof(TextPanel) } },
		{ GameState.Running, new Type[] { typeof(TimerPanel) } },
		{ GameState.GameOver, new Type[] { typeof(GameOverPanel) } },
	};
	

	public void Initialize() {
		_ServerData.GameState.Subscribe(_ => {
			var activePanels = _PanelsToStateMap[_];
			_PanelContainer.ShowPanels(activePanels);
		});
	}

}