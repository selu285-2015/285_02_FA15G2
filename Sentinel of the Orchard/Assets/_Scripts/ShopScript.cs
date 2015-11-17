using UnityEngine;
using System.Collections;

public class ShopScript : MonoBehaviour {
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private GameObject shop;
	[SerializeField]
	private GameObject shopText;
	private PlayerInventory inven;
	bool isShopping = false;
	private MoneySystem mSystem;
	public GameObject hud;
	private PauseMenu pM;
	// Use this for initialization
	void Start () {
		inven = player.GetComponent<PlayerInventory> ();
		mSystem = player.GetComponent<MoneySystem> ();
		pM = hud.GetComponent<PauseMenu> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E) && !(isShopping)){
			shop.SetActive(true);
			Time.timeScale = 0;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			shopText.SetActive(false);
			isShopping = true;
			pM.enabled = false;
		}
		else if(Input.GetKeyDown(KeyCode.E) && isShopping){
			shop.SetActive(false);
			Time.timeScale = 1;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			shopText.SetActive(true);
			isShopping = false;
			pM.enabled = true;
		}
	}

	public void buyTesla(){
		if (inven.money >= 100) {
			mSystem.LoseMoney(100);
			inven.amountOfTesla++;
			//play cha ching sound here
		} else {
			//play err err sound
		}
	}
	public void buyTiki(){
		if (inven.money >= 100) {
			inven.money = inven.money - 100;
			inven.amountOfTiki++;
			//play young mulla baybe
		} else {
			//play err err sound
		}
	}
}
