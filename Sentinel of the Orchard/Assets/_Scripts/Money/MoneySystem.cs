using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{
    public int CurrentMoney;
    public Text CurrentMoney_Text;


    // Use this for initialization
    void Start()
    {
        //player's total money
        CurrentMoney = 0;

        //presents money on the screen
        CurrentMoney_Text.text = "Money: " + CurrentMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    { 
    }

    public void GainMoney(int MoneyGained)
    {
        //adds money to player and presents it in money UI
        CurrentMoney += MoneyGained;
        CurrentMoney_Text.text = "Money: " + CurrentMoney.ToString();

    }

    public void LoseMoney(int MoneyLost)
    {

        if (CurrentMoney - MoneyLost < 0)
        {
            //showed in console when player doesnt have enough money to lose.
            Debug.Log("You require additional money.");

        } else
        {
            //subtracts money from player and presents in to money UI
            CurrentMoney -= MoneyLost;
            CurrentMoney_Text.text = "Money: " + CurrentMoney.ToString();

        }
    }
}
