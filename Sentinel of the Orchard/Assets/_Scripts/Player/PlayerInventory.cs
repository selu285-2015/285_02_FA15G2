using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {

	public int money = 300;
	public int amountOfTesla = 0;
	public int amountOfTiki = 0;
	public int amountOf3rdTower = 0;
	public GameObject shopCanvas;
	public Collider shopCollider;
	public Text teslaAmount;
	public Text tikiAmount;
	public Text ShottyAmount;

	public GameObject gun;
	public GameObject wrench;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		teslaAmount.text = amountOfTesla.ToString();
		tikiAmount.text = amountOfTiki.ToString();
		ShottyAmount.text = amountOf3rdTower.ToString ();
		swapSystem ();
	}

	void OnTriggerEnter(Collider check){
		if (check == shopCollider) {
			shopCanvas.SetActive(true);
			print ("fdsa");
		}
    }

	void OnTriggerExit(Collider check){
		if (check == shopCollider) {
			shopCanvas.SetActive(false);
		}
    }

	void swapSystem(){
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			// enable gun
			//dis wrench
			gun.SetActive(true);
			wrench.SetActive(false);
		}
		else if(Input.GetKeyDown(KeyCode.Alpha5)){
			//enable wrnech
			//dis gun
			gun.SetActive(false);
			wrench.SetActive(true);
		}
	}
}
