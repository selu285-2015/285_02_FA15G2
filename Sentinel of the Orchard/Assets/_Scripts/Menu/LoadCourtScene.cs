﻿using UnityEngine;
using System.Collections;

public class LoadCourtScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	

	void OnTriggerStay (Collider PickBerries) {

			if (PickBerries.gameObject.tag == "Player") {
				if (Input.GetKeyDown (KeyCode.Z)) {
				Application.LoadLevel (4);
				}
			}
}
}