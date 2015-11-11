using UnityEngine;
using System.Collections;

public class BeforeWaveSong : MonoBehaviour {

	private AudioSource beforeWave;

	
	// Use this for initialization
	void Start () {
		beforeWave = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (Input.GetKeyDown (KeyCode.M)) {      
			
			beforeWave.Stop();
		}
	}
}
