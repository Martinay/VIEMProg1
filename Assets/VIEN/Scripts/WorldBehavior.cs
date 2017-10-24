using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBehavior : MonoBehaviour {
	public GameObject Light0, Light1, Light2, Light3, Light4, Light5, Light6, Light7, Light8, Light9, Light10, Light11, Light12, Light13, Light14;
	public AudioClip LightsOn, Introduction;
	public int State; 

	private float time;



	// Use this for initialization
	void Start () {
		ResetTime ();
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

	void ResetTime(){
		time = 0.0f;
	}

	void StartSequence (){
		time += Time.deltaTime;
		bool first = false, second = false, third = false;
		if(time >= 5.0f && !first) {
			Light0.SetActive (true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			first = true;
		}
		if (time >= 20.0f && !second) {
			AudioSource.PlayClipAtPoint(Introduction, Camera.main.transform.position);
			second = true;
		}
		if (time >= 80.0f && !third) {
			Light1.SetActive (true);
			Light2.SetActive (true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			third = true;
		}
	}
}
