using System.Collections.Generic;
using Photon.Deterministic;
using TMPro;
using UnityEngine;
namespace View {
	public class TextPanel : PanelView {

		[SerializeField]
		private TMP_Text _Text;

		private Dictionary<string, string> _TextRemap = new Dictionary<string, string>() {
			{ "0", "GO!" }
		};
		public void SetText(string text) {
			_TextRemap.TryGetValue(text, out var remappedText);
			_Text.text = string.IsNullOrEmpty(remappedText) ? text : remappedText;
		}
	}
}
