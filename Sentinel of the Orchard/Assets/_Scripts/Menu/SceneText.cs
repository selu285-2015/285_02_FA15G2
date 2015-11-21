using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SceneText : MonoBehaviour {

    public PauseMenu pauseCheck;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
        bool stayAlive = !pauseCheck.pauseCheck();

		if ((Input.GetKey (KeyCode.M)) && (stayAlive)) {
			Destroy(gameObject);
		}


	
	}
}
