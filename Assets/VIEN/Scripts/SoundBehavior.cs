using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBehavior : MonoBehaviour {
	public AudioClip LightsOn, Introduction, Wrong1, Wrong2, Wrong3, Wrong4, Heart, Banana;
	private AudioSource _audioSource;
	private GameObject _gameobject;
	private bool sendBack;
	// Use this for initialization
	void Start () {
		_audioSource = gameObject.AddComponent<AudioSource>();
		sendBack = false;
	}
	
	// Update is called once per frame
	void Update () {
		if ( sendBack && !_audioSource.isPlaying) {
			sendBack = false;
			_gameobject.SendMessage("newPosition");
		}
	}

	public void startClip(AudioClip clip){
		_audioSource.clip = clip;
		_audioSource.loop = false;
		_audioSource.Play();
	}

	public void PlayLightsOn () {
		startClip (LightsOn);
	}

	public void PlayIntroduction () {
		startClip (Introduction);
	}

	public void PlayWrong () {
		System.Random rand = new System.Random ();
		int src = rand.Next(0,4);
		switch(src){
		case 0:
			startClip (Wrong1);
			break;
		case 1:
			startClip (Wrong2);
			break;
		case 2:
			startClip (Wrong3);
			break;
		case 3:
			startClip (Wrong4);
			break;
		}
	}

	public void PlayBanana (GameObject sender) {
		sendBack = true;
		_gameobject = sender;
		startClip (Banana);
	}

	public void PlayFish (GameObject sender) {
		sendBack = true;
		_gameobject = sender;
		startClip (Banana);
	}

	public void PlayHeart () {
		startClip (Heart);
	}
}
