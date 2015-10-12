using UnityEngine;
using System.Collections;

public class Waves : MonoBehaviour {


	int i = 0;
	public Transform prefab;
	public Transform prefab2;
	public Transform prefab3;
	float timer = 0f;
	public float waveDelay = 0.5f;
	bool waveOne = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		timer += Time.deltaTime;

		if((Input.GetKey(KeyCode.M)) && (waveOne == false)){
			waveOne = true;
			

		}
		if ((i < 4) && (waveOne == true) && (timer >= waveDelay)) {
			SpawnApple ();
			i++;
			timer = 0;

		}
		else if ((i < 6) && (waveOne == true) && (timer >= waveDelay)) {
			SpawnLemon ();
			i++;
			timer = 0;
			
		}
		else if ((i < 7) && (waveOne == true) && (timer >= waveDelay)) {
			SpawnApple ();
			i++;
			timer = 0;
			
		}
		else if ((i < 10) && (waveOne == true) && (timer >= waveDelay)) {
			SpawnLemon ();
			i++;
			timer = 0;
			
		}
		else if ((i < 13) && (waveOne == true) && (timer >= waveDelay)) {
			SpawnApple ();
			i++;
			timer = 0;
			
		}
		else if ((i < 16) && (waveOne == true) && (timer >= waveDelay)) {
			SpawnLemon ();
			i++;
			timer = 0;
			
		}
		else if ((i < 18) && (waveOne == true) && (timer >= waveDelay)) {
			SpawnApple ();
			i++;
			timer = 0;
			
		}
		else if ((i == 18) && (waveOne == true) && (timer >= waveDelay)) {
			SpawnBoss ();
			i++;
			timer = 0;
			
		}

	}
	void SpawnApple() {

			Object.Instantiate (prefab);
			
		}

	void SpawnLemon() {
		Object.Instantiate (prefab2);
	}

	void SpawnBoss() {
		Object.Instantiate (prefab3);
	}
	

}
