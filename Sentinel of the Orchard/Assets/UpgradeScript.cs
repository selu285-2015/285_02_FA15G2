using UnityEngine;
using System.Collections;

public class UpgradeScript : MonoBehaviour {

    
    public TowerBase target;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject upgradeText;
    private PlayerInventory inven;
    bool isShopping = false;
    private MoneySystem mSystem;

    // Use this for initialization
    void Start()
    {
        inven = player.GetComponent<PlayerInventory>();
        mSystem = player.GetComponent<MoneySystem>();
    }
    
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpgradeDamage()
    {
        if (inven.money >= 10 * Mathf.Pow(2, target.DamageLevel))
        {
            mSystem.LoseMoney(10 * (int)Mathf.Pow(2, target.DamageLevel));
            target.DamageLevel++;
        }
    }
    public void UpgradeFireRate()
    {
        if (inven.money >= 10 * Mathf.Pow(2, target.FireRateLevel))
        {
            mSystem.LoseMoney(10 * (int)Mathf.Pow(2, target.FireRateLevel));
            target.FireRateLevel++;
        }
    }
    public void UpgradeRange()
    {
        if (inven.money >= 10 * Mathf.Pow(2, target.RangeLevel))
        {
            mSystem.LoseMoney(10 * (int)Mathf.Pow(2, target.RangeLevel));
            target.GetComponent<SphereCollider>().radius += 1;
        }
    }
    public void UpgradeSpecial()
    {
        if (inven.money >= 500 && target.Special == 0)
        {
            mSystem.LoseMoney(500);
            target.Special = 1;
        }
    }
}
