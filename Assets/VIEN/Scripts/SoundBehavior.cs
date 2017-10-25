using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBehavior : MonoBehaviour {
	public AudioClip LightsOn, Introduction, Wrong1, Wrong2, Wrong3, Wrong4, Heart;

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
		AudioSource.PlayClipAtPoint(Wrong1, Camera.main.transform.position);
	}

	public void PlayHeart () {
		AudioSource.PlayClipAtPoint(Heart, Camera.main.transform.position);
	}
}
