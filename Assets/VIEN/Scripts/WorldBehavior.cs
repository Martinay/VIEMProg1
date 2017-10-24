using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBehavior : MonoBehaviour {
	public GameObject Light0, Light1, Light2, Light3, Light4, Light5, Light6, Light7, Light8, Light9, Light10, Light11, Light12, Light13, Light14;
	public AudioClip LightsOn, Introduction;
	public int State; 

	private float time;
	private int innerState;



	// Use this for initialization
	void Start () {
		Reset ();
	}

	// Update is called once per frame
	void Update () {
		Timing ();
	}

	void SetState(int state) {
		State = state;
	}

	void Timing () {
		switch (State) {
		case 0:
			StartSequence ();
			break;
		case 1:
			break;
		}
	}

	void Reset () {
		time = 0.0f;
		innerState = 0;
	}

	void StartSequence () {
		time += Time.deltaTime;
		if(time >= 5.0f && innerState == 0) {
			Light0.SetActive (true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
		}
		if (time >= 20.0f && innerState == 1) {
			AudioSource.PlayClipAtPoint(Introduction, Camera.main.transform.position);
			innerState++;
		}
		if (time >= 80.0f && innerState == 2) {
			Light1.SetActive (true);
			Light2.SetActive (true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void SecondState (){
		time += Time.deltaTime;
		if (time >= 5.0f && innerState == 0) {

		}
	}
}
