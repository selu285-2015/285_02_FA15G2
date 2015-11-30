using UnityEngine;
using System.Collections;

public class Waves : MonoBehaviour {


	[SerializeField]private Transform apple;
	[SerializeField]private Transform lemon;
	[SerializeField]private Transform boss;
	[SerializeField]private Transform lime;
	//[SerializeField]private Transform orange;
	//[SerializeField]private PauseMenu pauseMenu;
	[SerializeField]private TextAsset strings;
	private float timer = 0f;
	public float waveDelay = 1f;
	private bool spawning = false;
	private string waves;
	private char[] charArray;
	private int index;


	// Use this for initialization
	void Start () {
		index = 0;

		charArray = strings.ToString().ToCharArray();
	}
	
	//might look bad, but kinda needed for spawning of enemies since This is technically a 2d Char array
	void Update () {
		if (spawning == true && (index != charArray.Length-1)) {
				timer += Time.deltaTime;
				if (timer >= waveDelay) {
					timer = 0f;
					//Trying to make it more efficent boyz
					switch (charArray[index]) {
					case 'a':		SpawnApple ();
						index++;
						break;
					case 'l':
						SpawnLemon ();
						index++;
						break;
					case 'b':
						SpawnBoss ();
						index++;
						break;
					case 'g':
						SpawnLime();
						index++;
						break;
					default:
						index++;
						break;

					}
				}
			
		else if(charArray [index] == '\n'){
			spawning = false;
				index++;
		}
			}
	else if(Input.GetKeyDown(KeyCode.M)){
			spawning = true;
		}
	}
	
	void SpawnApple() {
			Object.Instantiate (apple);
		}

	void SpawnLemon() {
		Object.Instantiate (lemon);
	}

	void SpawnBoss() {
		Object.Instantiate (boss);
	}

	void SpawnLime(){
		Object.Instantiate (lime);
	}
}
