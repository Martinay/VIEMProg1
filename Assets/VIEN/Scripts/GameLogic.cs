using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {
	public GameObject DrawingHud;
	public GameObject DrawingSurface;

	public void EnterDrawMode()
	{
		DrawingHud.SetActive(true);
		DrawingSurface.SetActive(true);
	}	

	public void ExitDrawMode()
	{
		DrawingHud.SetActive(false);
		DrawingSurface.SetActive(false);
	}
}
