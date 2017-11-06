﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameLogic : MonoBehaviour {
	public GameObject IngameLogic;
    public GameObject drawables;
	public GameObject Tutorial;
    private Draw_Objects Draw_Objects;

    public void Start()
    {
        Draw_Objects = drawables.GetComponent<Draw_Objects>();
    }

	public void OnStartTutorial()
	{
		Tutorial.SetActive(true);
	}

	public void OnTutorialFinished()
	{
		Tutorial.SetActive(false);
		IngameLogic.SetActive(true);
	}

    public void SubmitCoordinates(SubmitCoordinates coordinates)
	{        
		print("SubmitStart");
        make_req req = new make_req(coordinates.Coordinates, coordinates.Width, coordinates.Height, Draw_Objects.getDrawableObjects());
        req.Req();
	}
}
