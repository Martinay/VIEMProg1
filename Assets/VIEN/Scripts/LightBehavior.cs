using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehavior : MonoBehaviour {
	public GameObject Light0, Light1, Light2, Light3, Light4, Light5, Light6, Light7, Light8, Light9, Light10, Light11, Light12, Light13, Light14;
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
			ApplyState ( 
				new int[] { 0 },
				new int[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 },
				new int[] { 1, 2 }
			);
			break;
		case 2:
			ApplyState ( 
				new int[] { 2 },
				new int[] { 1, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 },
				new int[] { 0, 3 }
			);
			break;
		case 3:
			ApplyState ( 
				new int[] { 1 },
				new int[] { 2, 3, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 },
				new int[] { 0, 4 }
			);
			break;
		case 4:
			ApplyState (
				new int[] { 4 },
				new int[] { 0, 2, 3, 6, 8, 9, 10, 11, 12, 13, 14 },
				new int[] { 1, 5, 7 }
			);
			break;
		case 5:
			ApplyState ( 
				new int[] { 5 },
				new int[] { 0, 1, 2, 3, 7, 8, 9, 10, 11, 12, 13, 14 },
				new int[] { 4, 6 }
			);
			break;
		case 6:
			ApplyState ( 
				new int[] { 6 },
				new int[] { 0, 1, 2, 3, 4, 7, 8, 10, 11, 12, 13, 14 },
				new int[] { 5, 9 }
			);
			break;
		case 7:
			ApplyState ( 
				new int[] { 7 },
				new int[] { 0, 1, 2, 3, 5, 6, 9, 10, 11, 12, 13, 14 },
				new int[] { 4, 8 }
			);
			break;
		case 8:
			ApplyState ( 
				new int[] { 8 },
				new int[] { 0, 1, 2, 3, 4, 5, 6, 10, 11, 12, 13, 14 },
				new int[] { 7, 9 }
			);
			break;
		case 9:
			ApplyState ( 
				new int[] { 9 },
				new int[] { 0, 1, 2, 3, 4, 5, 7, 11, 13, 14 },
				new int[] { 6, 8, 10, 12 }
			);
			break;
		case 10:
			ApplyState ( 
				new int[] { 12 },
				new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 14 },
				new int[] { 9, 13 }
			);
			break;
		case 11:
			ApplyState ( 
				new int[] { 13 },
				new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
				new int[] { 12, 14 }
			);
			break;
		case 12:
			ApplyState ( 
				new int[] { 10 },
				new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 12, 13, 14 },
				new int[] { 9, 11 }
			);
			break;
		case 13:
			ApplyState ( 
				new int[] { 11 },
				new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 12, 13, 14 },
				new int[] { 10 }
			);
			break;
		default:
			break;
		}
	}

	void StartState () {
		time += Time.deltaTime;
		if(time >= 5.0f && innerState == 0) {
			SetGroupActive (new int[] { 0 }, true);
			gameObject.SendMessage ("PlayLightsOn");
			innerState++;
		}
		else if (time >= 20.0f && innerState == 1) {
			gameObject.SendMessage ("PlayIntroduction");
			innerState++;
		}
		else if (time >= 75.0f && innerState == 2) {
			SetGroupActive (new int[] { 1, 2 }, true);
			gameObject.SendMessage ("PlayLightsOn");
			innerState++;
			Reset ();
		}
	}

	void ApplyState (int[] curr, int[] deactivate, int[] activate) {
		time += Time.deltaTime;
		if (innerState == 0) {
			//deactivate lights
			SetGroupActive (deactivate, false);
			//activate current light
			SetGroupActive (curr, true);
			innerState++;
		}
		if (time >= 5.0f && innerState == 1) {
			//activate lights
			SetGroupActive (activate, true);
			gameObject.SendMessage ("PlayLightsOn");
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
