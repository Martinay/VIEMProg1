using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

	public void SubmitCoordinates(RawCoordinates coordinates)
	{
        make_req req = new make_req(coordinates);
        req.Req();

		//foreach(var x in coordinates.X)
			//Debug.Log(x);
	}
}
