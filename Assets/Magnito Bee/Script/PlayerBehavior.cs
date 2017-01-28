﻿using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {

	public Vector3 normalModePosition;
	public Vector3 beastModePosition;
	public HealthAndEnergyScript energyScript;

	//private bool beastMode = false;
	//private bool transiteComplete = false;
	public int playerState = 0; //0:normal,1:charged 2: transit to beast mode, 3:beastmode, 4:transit back to normal

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (playerState == 1) {
			playerState = 2;
		} else if (playerState == 2) {
			transform.position = Vector3.MoveTowards (transform.position, beastModePosition, 0.1f);
			if (transform.position == beastModePosition) {
				playerState = 3;
			}
		} else if (playerState == 3) {
			energyScript.decrementEnergy (10.0f);
		} else if (playerState == 4) {
			transform.position = Vector3.MoveTowards (transform.position, normalModePosition, 0.1f);
			if (transform.position == normalModePosition) {
				playerState = 0;
			}
		}

	}
}