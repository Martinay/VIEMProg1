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

	public void SetState(int state) {
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

	void StartState () {
		time += Time.deltaTime;
		if(time >= 5.0f && innerState == 0) {
			SetGroupActive (new int[] { 0 }, true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
		}
		else if (time >= 20.0f && innerState == 1) {
			AudioSource.PlayClipAtPoint(Introduction, Camera.main.transform.position);
			innerState++;
		}
		else if (time >= 75.0f && innerState == 2) {
			SetGroupActive (new int[] { 1, 2 }, true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateOne (){
		time += Time.deltaTime;
		if (innerState == 0) {
			int[] falseStates = { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
			SetGroupActive (falseStates, false);
			//Set current activ light
			SetGroupActive (new int[] { 0 }, true);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			int[] trueStates = { 1, 2 };
			SetGroupActive (trueStates, true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}
		
	void StateTwo (){
		time += Time.deltaTime;
		if (innerState == 0) {
			int[] falseStates = { 1, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
			SetGroupActive (falseStates, false);
			//Set current activ light
			SetGroupActive (new int[] { 2 }, true);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			int[] trueStates = { 0, 3 };
			SetGroupActive (trueStates, true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateThree (){
		time += Time.deltaTime;
		if (innerState == 0) {
			int[] falseStates = { 2, 3, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
			SetGroupActive (falseStates, false);
			//Set current activ light
			SetGroupActive (new int[] { 1 }, true);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			int[] trueStates = { 0, 4 };
			SetGroupActive (trueStates, true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateFour (){
		time += Time.deltaTime;
		if (innerState == 0) {
			int[] falseStates = { 0, 2, 3, 6, 8, 9, 10, 11, 12, 13, 14 };
			SetGroupActive (falseStates, false);
			//Set current activ light
			SetGroupActive (new int[] { 4 }, true);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			int[] trueStates = { 1, 5, 7 };
			SetGroupActive (trueStates, true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateFive (){
		time += Time.deltaTime;
		if (innerState == 0) {
			int[] falseStates = { 0, 1, 2, 3, 7, 8, 9, 10, 11, 12, 13, 14 };
			SetGroupActive (falseStates, false);
			//Set current activ light
			SetGroupActive (new int[] { 5 }, true);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			int[] trueStates = { 4, 6 };
			SetGroupActive (trueStates, true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateSix (){
		time += Time.deltaTime;
		if (innerState == 0) {
			int[] falseStates = { 0, 1, 2, 3, 4, 7, 8, 10, 11, 12, 13, 14 };
			SetGroupActive (falseStates, false);
			//Set current activ light
			SetGroupActive (new int[] { 6 }, true);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			int[] trueStates = { 5, 9 };
			SetGroupActive (trueStates, true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateSeven (){
		time += Time.deltaTime;
		if (innerState == 0) {
			int[] falseStates = { 0, 1, 2, 3, 5, 6, 9, 10, 11, 12, 13, 14 };
			SetGroupActive (falseStates, false);
			//Set current activ light
			SetGroupActive (new int[] { 7 }, true);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			int[] trueStates = { 4, 8 };
			SetGroupActive (trueStates, true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateEight (){
		time += Time.deltaTime;
		if (innerState == 0) {
			int[] falseStates = { 0, 1, 2, 3, 4, 5, 6, 10, 11, 12, 13, 14 };
			SetGroupActive (falseStates, false);
			//Set current activ light
			SetGroupActive (new int[] { 8 }, true);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			int[] trueStates = { 7, 9 };
			SetGroupActive (trueStates, true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateNine (){
		time += Time.deltaTime;
		if (innerState == 0) {
			int[] falseStates = { 0, 1, 2, 3, 4, 5, 7, 11, 13, 14 };
			SetGroupActive (falseStates, false);
			//Set current activ light
			SetGroupActive (new int[] { 9 }, true);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			int[] trueStates = { 6, 8, 10, 12 };
			SetGroupActive (trueStates, true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateTen (){
		time += Time.deltaTime;
		if (innerState == 0) {
			int[] falseStates = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 14 };
			SetGroupActive (falseStates, false);
			//Set current activ light
			SetGroupActive (new int[] { 12 }, true);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			int[] trueStates = { 9, 13 };
			SetGroupActive (trueStates, true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateEleven (){
		time += Time.deltaTime;
		if (innerState == 0) {
			int[] falseStates = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
			SetGroupActive (falseStates, false);
			//Set current activ light
			SetGroupActive (new int[] { 13 }, true);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			int[] trueStates = { 12, 14 };
			SetGroupActive (trueStates, true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateTwelve (){
		time += Time.deltaTime;
		if (innerState == 0) {
			int[] falseStates = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 12, 13, 14 };
			SetGroupActive (falseStates, false);
			//Set current activ light
			SetGroupActive (new int[] { 10 }, true);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			int[] trueStates = { 9, 11 };
			SetGroupActive (trueStates, true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void StateThirteen (){
		time += Time.deltaTime;
		if (innerState == 0) {
			int[] falseStates = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 12, 13, 14 };
			SetGroupActive (falseStates, false);
			//Set current activ light
			SetGroupActive (new int[] { 11 }, true);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			int[] trueStates = { 10 };
			SetGroupActive (trueStates, true);
			AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
			innerState++;
			Reset ();
		}
	}

	void Reset () {
		time = 0.0f;
		innerState = 0;
		State = -1;
	}

	void SetGroupActive(int[] lights, bool active){
		foreach (int light in lights) {
			switch (light) {
			case 0:
				Light0.SetActive (active);
				break;
			case 1:
				Light1.SetActive (active);
				break;
			case 2:
				Light2.SetActive (active);
				break;
			case 3:
				Light3.SetActive (active);
				break;
			case 4:
				Light4.SetActive (active);
				break;
			case 5:
				Light5.SetActive (active);
				break;
			case 6:
				Light6.SetActive (active);
				break;
			case 7:
				Light7.SetActive (active);
				break;
			case 8:
				Light8.SetActive (active);
				break;
			case 9:
				Light9.SetActive (active);
				break;
			case 10:
				Light10.SetActive (active);
				break;
			case 11:
				Light11.SetActive (active);
				break;
			case 12:
				Light12.SetActive (active);
				break;
			case 13:
				Light13.SetActive (active);
				break;
			case 14:
				Light14.SetActive (active);
				break;
			}
		}
	}
}
