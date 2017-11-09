using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presentation : MonoBehaviour {
	public GameObject Worldbehavior;
	public GameObject Enemy;
    public GameObject TestUI;
	private bool pauseGame = false;
	private bool pauseEnemy = false;
    private bool showTestUI = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) {
			if (!pauseGame)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
			pauseGame = !pauseGame;
		}

		if (Input.GetKeyDown ("o")) {
			Enemy.SetActive(pauseEnemy);
			pauseEnemy = !pauseEnemy;
		}

		if (Input.GetKeyDown ("k")) {
			Worldbehavior.SendMessage ("StopClip");
			Worldbehavior.SendMessage ("DebugSkip");
		}


        if (Input.GetKeyDown("l"))
        {
            showTestUI = !showTestUI;
            TestUI.SetActive(showTestUI);
        }
    }
}
