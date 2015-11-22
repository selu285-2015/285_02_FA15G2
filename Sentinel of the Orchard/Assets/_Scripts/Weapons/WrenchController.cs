using UnityEngine;
using System.Collections;

public class WrenchController : MonoBehaviour
{

    public GameObject player;
    public GameObject upgradeCanvas;
    public MoneySystem moneySystem;
	// Use this for initialization
    void Start()
    {
        moneySystem = player.GetComponent<MoneySystem>();
    }

    void Update()
    {
        if (Input.GetKey("e") && upgradeCanvas.activeSelf)
        {
            upgradeCanvas.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    void OnTriggerStay(Collider other)
    {

        if(Input.GetMouseButton(0) && other.CompareTag("Tower") && !other.isTrigger)
        {
            upgradeCanvas.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            upgradeCanvas.GetComponent<UpgradeScript>().target = other.gameObject.GetComponent<TowerBase>();
        }
    }
}

