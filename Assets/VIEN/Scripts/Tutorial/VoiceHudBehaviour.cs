using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceHudBehaviour : MonoBehaviour {
	public Text TextBox;
	void OnEnable()
	{
		TextBox.text = string.Empty;
	}
	
	public void SetText(string Text)
	{
		TextBox.text = Text;
	}
}
