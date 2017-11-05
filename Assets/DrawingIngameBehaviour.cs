using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingIngameBehaviour : MonoBehaviour {

    public GameLogic GameLogic;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Submit()
    {
        //var lines = _lineSegments.Where(x=> !x.IsEmpty).Select(x => new RawCoordinates(x.Points)).ToList();

//        GameLogic.SubmitCoordinates(lines, (int)_backgroundRenderer.bounds.size.x, (int)_backgroundRenderer.bounds.size.y);
    }
}
