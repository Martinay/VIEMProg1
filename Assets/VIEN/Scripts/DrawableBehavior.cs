﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawableBehavior : MonoBehaviour {
	public GameObject WorldInteraction;
	public int State;
	public string SearchTag;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Teleport() {
		player.transform.position = this.transform.position;
		player.transform.rotation = this.transform.rotation;
		WorldInteraction.SendMessage ("SetState",State);
	}
}
