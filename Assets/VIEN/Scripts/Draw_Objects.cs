using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_Objects : MonoBehaviour {


    private GameObject[] DrawableObjects;

    public Draw_Objects()
    {

    }

    public GameObject[] getDrawableObjects()
    {
        return DrawableObjects;
    }



    // Use this for initialization
    void Start () {
        DrawableObjects = GameObject.FindGameObjectsWithTag("Drawable");
        
    }
	


	// Update is called once per frame
	void Update () {
		
	}
}
