using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {

	private bool waveOne = false;
	private AudioSource source;



	void Start () {
		source = GetComponent<AudioSource> ();

	}
	

	void Update () {
	

		if ((Input.GetKeyDown (KeyCode.M)) && (waveOne == false)) {
			source.Play();
			waveOne = true;
		}
	}
}
