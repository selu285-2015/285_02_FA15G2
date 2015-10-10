using UnityEngine;
using System.Collections;

public class MouseLock : MonoBehaviour {
	bool paused = false;
	
	void Start ()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = (false);
		Time.timeScale = 1;
	}
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape) && paused) {
			UnPause ();
		} else if (Input.GetKeyDown (KeyCode.Escape) && !paused) {

			GamePause ();
		} else if (Input.GetKeyDown (KeyCode.P) && paused) {
			Application.Quit();
		}

	}

	void GamePause(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		paused = true;
		Time.timeScale = 0;//pause

	}

	void UnPause(){
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		paused = false;
		Time.timeScale = 1;//unpause;
	}

	void OnGUI(){
		var w = 895;
		var h = 423;
		var GUIMenu = new Rect ((Screen.width - w) / 2, (Screen.height - h) / 2, Screen.width / 2, Screen.height / 2);
		GameObject btnExitGame;


		if (paused) {
			GUI.Box(new Rect(GUIMenu), "Menu");
			//GUI.Button(new Rect ((Screen.width - w)/ 2, (Screen.height - h) / 2, Screen.width / 10, Screen.height / 5), "Exit Game");
			if(GUI.Button(new Rect ((Screen.width - w)/ 2, (Screen.height - h) / 2, Screen.width / 10, Screen.height / 5), "Exit Game"))
			{
				Application.Quit();
			}

		}
	}
}