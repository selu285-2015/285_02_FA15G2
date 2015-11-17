using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

	public int money = 300;
	public int amountOfTesla = 0;
	public int amountOfTiki = 0;
	public int amountOf3rdTower = 0;
	public GameObject shopCanvas;
	public Collider shopCollider;
    public GameObject upgradeCanvas;
    public Collider upgradeCollider;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider check){
		if (check == shopCollider) {
			shopCanvas.SetActive(true);
			print ("fdsa");
		}
        if (check.gameObject.CompareTag("Tower"))
        {
            upgradeCanvas.SetActive(true);
        }
    }

	void OnTriggerExit(Collider check){
		if (check == shopCollider) {
			shopCanvas.SetActive(false);
		}
        if (check.gameObject.CompareTag("Tower"))
        {
            upgradeCanvas.SetActive(false);
        }
    }
}
