using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameLogic : MonoBehaviour {
	public GameObject DrawingHud;
	public GameObject DrawingSurface;
    public GameObject drawables;
    private Draw_Objects Draw_Objects;

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

    public void Start()
    {
        Draw_Objects = drawables.GetComponent<Draw_Objects>();
    }

    public void SubmitCoordinates(List<RawCoordinates> coordinates, int width, int height)
	{        
        make_req req = new make_req(coordinates, width, height, Draw_Objects.getDrawableObjects());
        req.Req();
	}
}
