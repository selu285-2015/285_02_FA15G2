using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{
	public GameObject player;
    public Text CurrentMoney_Text;
	public PlayerInventory inven;


    // Use this for initialization
    void Start()
    {
		inven =  player.GetComponent<PlayerInventory>();
        //player's total money
       // CurrentMoney = startMoney;
        //presents money on the screen
        CurrentMoney_Text.text = "Money: " + inven.money.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GainMoney(int MoneyGained)
    {
        //adds money to player and presents it in money UI
        inven.money += MoneyGained;
        CurrentMoney_Text.text = "Money: " + inven.money.ToString();
    }

    public void LoseMoney(int MoneyLost)
    {
        if (inven.money - MoneyLost < 0)
        {
            //showed in console when player doesnt have enough money to lose.
            Debug.Log("You require additional money.");

        }else
        {
            //subtracts money from player and presents in to money UI
            inven.money -= MoneyLost;
            CurrentMoney_Text.text = "Money: " + inven.money.ToString();

        }
    }
}
