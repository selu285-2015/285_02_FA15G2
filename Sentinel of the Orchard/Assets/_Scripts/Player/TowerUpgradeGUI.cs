using UnityEngine;
using System.Collections;

public class TowerUpgradeGUI : MonoBehaviour {

    public GameObject upgradeCanvas;
    public Collider upgradeCollider;
    // Use this for initialization

    void OnTriggerEnter(Collider check)
    {
        if (check == upgradeCollider)
        {
            upgradeCanvas.SetActive(true);
            print("fdsa");
        }
    }

    void OnTriggerExit(Collider check)
    {
        if (check == upgradeCollider)
        {
            upgradeCanvas.SetActive(false);
        }
    }
}
