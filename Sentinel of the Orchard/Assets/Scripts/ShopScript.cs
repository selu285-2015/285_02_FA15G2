using UnityEngine;
using System.Collections;

public class ShopScript : MonoBehaviour {
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private GameObject shop;
	[SerializeField]
	private GameObject shopText;

	bool isShopping = false;

	// Use this for initialization
	void Start () {
	
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
		}
		else if(Input.GetKeyDown(KeyCode.E) && isShopping){
			shop.SetActive(false);
			Time.timeScale = 1;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			shopText.SetActive(true);
			isShopping = false;
		}
	}
}
