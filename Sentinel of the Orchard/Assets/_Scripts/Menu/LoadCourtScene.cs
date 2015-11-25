using UnityEngine;
using System.Collections;

public class LoadCourtScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			Application.LoadLevel (6);

		}
	}

	void OnTriggerStay (Collider PickBerries) {

			if (PickBerries.gameObject.tag == "Player") {
				if (Input.GetKeyDown (KeyCode.Z)) {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				Application.LoadLevel (4);
				}
			}
}
}