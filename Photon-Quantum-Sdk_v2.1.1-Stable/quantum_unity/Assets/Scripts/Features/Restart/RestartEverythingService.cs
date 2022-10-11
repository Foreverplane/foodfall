using Quantum.Demo;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
namespace Features.Restart {
	public class RestartEverythingService {

		public void RequestRestart() {
			Debug.Log("<color=green>RequestRestart</color>");
			if (UIMain.Client == null) {
				Debug.LogError("Please start game from MENU scene");
				return;
			}
			UIMain.Client.Disconnect(); // from quantum
		}

	}
}
