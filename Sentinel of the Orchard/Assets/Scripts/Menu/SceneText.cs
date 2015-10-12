using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SceneText : MonoBehaviour {



	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.M)) {
			Destroy(gameObject);
		}

	
	}
}
