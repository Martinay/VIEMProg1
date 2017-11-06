using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBehavior : MonoBehaviour {
	public AudioClip LightsOn, Introduction, Wrong1, Wrong2, Wrong3, Wrong4, Heart, Banana;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayLightsOn () {
		AudioSource.PlayClipAtPoint(LightsOn, Camera.main.transform.position);
	}

	public void PlayIntroduction () {
		AudioSource.PlayClipAtPoint(Introduction, Camera.main.transform.position);
	}

	public void PlayWrong () {
		System.Random rand = new System.Random ();
		int src = rand.Next(0,4);
		switch(src){
		case 0:
			AudioSource.PlayClipAtPoint(Wrong1, Camera.main.transform.position);
			break;
		case 1:
			AudioSource.PlayClipAtPoint(Wrong2, Camera.main.transform.position);
			break;
		case 2:
			AudioSource.PlayClipAtPoint(Wrong3, Camera.main.transform.position);
			break;
		case 3:
			AudioSource.PlayClipAtPoint(Wrong4, Camera.main.transform.position);
			break;
		}
	}

	public void PlayBanana () {
		AudioSource.PlayClipAtPoint(Banana, Camera.main.transform.position);
	}

	public void PlayHeart () {
		AudioSource.PlayClipAtPoint(Heart, Camera.main.transform.position);
	}
}
