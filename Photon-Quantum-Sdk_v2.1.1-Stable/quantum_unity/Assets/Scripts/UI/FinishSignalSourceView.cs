using System;
using Features.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
namespace View {

	public class FinishSignalSourceView : MonoBehaviour, ISignalSourceView {
		[SerializeField]
		private Button _Button;

		[Inject]
		private SignalBus _SignalBus;

		private void OnValidate() {
			_Button = GetComponent<Button>();
		}

		private void Awake() {
			_Button.onClick.AddListener(OnButtonClick);
		}

		private void OnDestroy() {
			_Button.onClick.RemoveListener(OnButtonClick);
		}
		private void OnButtonClick() {
			Debug.Log("OnClick");
			_SignalBus.Fire<FinishButtonSignal>();
		}
	}
}
