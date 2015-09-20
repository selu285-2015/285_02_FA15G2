using UnityEngine;
using System.Collections;

public class MouseLock : MonoBehaviour {
	bool paused;
	
	void Start ()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = (false);
		paused = (false);
	}
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape) && paused) {
			UnPause();
		}
		else if(Input.GetKeyDown(KeyCode.Escape) && !paused){

			GamePause();
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
}