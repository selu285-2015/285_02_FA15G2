using UnityEngine;
using System.Collections;

public class LoadCourtScene : MonoBehaviour {
	public GameObject player;
	public PlayerInventory p;
	public HighScores h;
	// Use this for initialization
	void Start () {
		p = player.GetComponent<PlayerInventory> ();
		h = player.GetComponent<HighScores> ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			Application.LoadLevel (6);
			h.add(p.points);
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