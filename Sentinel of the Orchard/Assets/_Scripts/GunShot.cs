using UnityEngine;
using System.Collections;

public class GunShot : MonoBehaviour {

	private AudioSource source;
	float timer = 0 ;
	public float  attackSpeed = .5f;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if ((Input.GetMouseButtonDown (0)) && (timer >= attackSpeed) && Time.timeScale != 0) {
			source.Play();
			timer = 0f;
		}

	}
}
