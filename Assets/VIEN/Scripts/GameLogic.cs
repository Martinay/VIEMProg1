using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameLogic : MonoBehaviour {
	public GameObject DrawingHud;
	public GameObject DrawingSurface;
    public GameObject drawables;
	public GameObject Tutorial;
    private Draw_Objects Draw_Objects;

    public void Start()
    {
        Draw_Objects = drawables.GetComponent<Draw_Objects>();
		OnStartTutorial();
    }

	public void OnStartTutorial()
	{
		Tutorial.SetActive(true);
	}

	public void OnTutorialFinished()
	{
		Tutorial.SetActive(false);
	}

    public void SubmitCoordinates(List<RawCoordinates> coordinates, int width, int height)
	{        
        make_req req = new make_req(coordinates, width, height, Draw_Objects.getDrawableObjects());
        req.Req();
	}
}
