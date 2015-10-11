using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {

	public AudioClip waveSong;
	private AudioSource source;


	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
	

		if (Input.GetKeyDown (KeyCode.M)) {
			source.PlayOneShot(waveSong);
		}
	}
}
