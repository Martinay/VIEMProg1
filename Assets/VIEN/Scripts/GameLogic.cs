using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {
	public GameObject DrawingHud;

	public void EnterDrawMode()
	{
		DrawingHud.SetActive(true);
	}	

	public void ExitDrawMode()
	{
		DrawingHud.SetActive(false);
	}
}
