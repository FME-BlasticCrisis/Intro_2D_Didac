using UnityEngine;
using System.Collections;

public class FloatingText : MonoBehaviour {

	private static readonly GUISkin Skin = Resources.Load<GUISkin>("GameSkin");

	public static FloatingText Show(string text, string style, IFloatingTextPositioner positioner) {
		var go = new GameObject ("Floating Text");
		var floatingtext = go.AddComponent<FloatingText> ();
		floatingtext.Style = Skin.GetStyle (style);
		floatingtext._positioner = positioner;
		floatingtext._content = new GUIContent (text);
		return floatingtext;
	}

	private GUIContent _content;
	private IFloatingTextPositioner _positioner;

	public string test {get { return _content.text; } set { _content.text = value; }}
	public GUIStyle Style { get; set;}

	public void OnGUI() {
		var position = new Vector2 ();
		var contentSize = Style.CalcSize (_content);
		if (!_positioner.GetPosition (ref position, _content, contentSize)) {
			Destroy (gameObject);
			return;
		}

		GUI.Label (new Rect (position.x, position.y, contentSize.x, contentSize.y), _content, Style);
	}
}
