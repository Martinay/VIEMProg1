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
		State = 0;
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
			StartState ();
			break;
		case 1:
			StateOne ();
			break;
		case 2:
			StateTwo ();
			break;
		case 3:
			StateThree ();
			break;
		case 4:
			StateFour ();
			break;
		case 5:
			StateFive ();
			break;
		case 6:
			StateSix ();
			break;
		case 7:
			StateSeven ();
			break;
		case 8:
			StateEight ();
			break;
		case 9:
			StateNine ();
			break;
		case 10:
			StateTen ();
			break;
		case 11:
			StateEleven ();
			break;
		case 12:
			StateTwelve ();
			break;
		case 13:
			StateThirteen ();
			break;
		default:
			break;
		}
	}

	void Reset () {
		time = 0.0f;
		innerState = 0;
		State = -1;
	}

	void StartState () {
		time += Time.deltaTime;
		if(time >= 5.0f && innerState == 0) {
			Light0.SetActive (true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
		}
		else if (time >= 20.0f && innerState == 1) {
			//AudioSource.PlayClipAtPoint(Introduction, Camera.main.transform.position);
			innerState++;
		}
		else if (time >= /*75.0f*/ 21.0f && innerState == 2) {
			Light1.SetActive (true);
			Light2.SetActive (true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateOne (){
		time += Time.deltaTime;
		if (innerState == 0) {
			Light3.SetActive (false);
			Light4.SetActive (false);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			Light1.SetActive (true);
			Light2.SetActive (true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateTwo (){
		time += Time.deltaTime;
		if (innerState == 0) {
			Light1.SetActive (false);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			Light3.SetActive (true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateThree (){
		time += Time.deltaTime;
		if (innerState == 0) {
			Light2.SetActive (false);
			Light5.SetActive (false);
			Light7.SetActive (false);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			Light0.SetActive (true);
			Light4.SetActive (true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateFour (){
		time += Time.deltaTime;
		if (innerState == 0) {
			Light0.SetActive (false);
			Light6.SetActive (false);
			Light8.SetActive (false);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			Light1.SetActive (true);
			Light5.SetActive (true);
			Light7.SetActive (true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateFive (){
		time += Time.deltaTime;
		if (innerState == 0) {
			Light1.SetActive (false);
			Light7.SetActive (false);
			Light9.SetActive (false);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			Light4.SetActive (true);
			Light6.SetActive (true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateSix (){
		time += Time.deltaTime;
		if (innerState == 0) {
			Light4.SetActive (false);
			Light8.SetActive (false);
			Light10.SetActive (false);
			Light12.SetActive (false);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			Light5.SetActive (true);
			Light9.SetActive (true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateSeven (){
		time += Time.deltaTime;
		if (innerState == 0) {
			Light1.SetActive (false);
			Light5.SetActive (false);
			Light9.SetActive (false);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			Light4.SetActive (true);
			Light8.SetActive (true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateEight (){
		time += Time.deltaTime;
		if (innerState == 0) {
			Light4.SetActive (false);
			Light6.SetActive (false);
			Light10.SetActive (false);
			Light12.SetActive (false);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			Light7.SetActive (true);
			Light9.SetActive (true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateNine (){
		time += Time.deltaTime;
		if (innerState == 0) {
			Light5.SetActive (false);
			Light7.SetActive (false);
			Light11.SetActive (false);
			Light13.SetActive (false);
			Light14.SetActive (false);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			Light6.SetActive (true);
			Light8.SetActive (true);
			Light10.SetActive (true);
			Light12.SetActive (true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateTen (){
		time += Time.deltaTime;
		if (innerState == 0) {
			Light6.SetActive (false);
			Light8.SetActive (false);
			Light10.SetActive (false);
			Light14.SetActive (false);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			Light9.SetActive (true);
			Light13.SetActive (true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateEleven (){
		time += Time.deltaTime;
		if (innerState == 0) {
			Light9.SetActive (false);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			Light12.SetActive (true);
			Light14.SetActive (true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateTwelve (){
		time += Time.deltaTime;
		if (innerState == 0) {
			Light6.SetActive (false);
			Light8.SetActive (false);
			Light12.SetActive (false);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			Light9.SetActive (true);
			Light11.SetActive (true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateThirteen (){
		time += Time.deltaTime;
		if (innerState == 0) {
			Light9.SetActive (false);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			Light10.SetActive (true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}
}
