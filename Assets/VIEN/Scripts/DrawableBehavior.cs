using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawableBehavior : MonoBehaviour {
	public GameObject WorldInteraction;
	public int State;
	public string[] SearchTag = new string[1];
	private GameObject player;
	private float time = 0.0f;
	private bool start;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		start = false;
	}
	
	// Update is called once per frame
	void Update () {
		Timing();
	}

	public void Timing() {
		if (start) {
			time += Time.deltaTime;
			if (time >= 3.0f) {
				newPosition ();
				start = false;
			}
		}
	}

	public void Teleport() {
		start = true;
		WorldInteraction.SendMessage ("PlayBanana");
	}

	private void newPosition() {
		player.transform.position = this.transform.position;
		player.transform.rotation = this.transform.rotation;
		WorldInteraction.SendMessage ("SetState",State);
	}
}
