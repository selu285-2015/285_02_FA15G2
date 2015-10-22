using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerMoney : MonoBehaviour
{
    public int CurrentMoney;
    public Text CurrentMoney_Counter;


    // Use this for initialization
    void Start()
    {
        CurrentMoney = 0;
        //No UI for this yet
        CurrentMoney_Counter.text = CurrentMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GainMoney(int MoneyGained)
    {
        //adds money to player total money and presents it in money UI
        CurrentMoney += MoneyGained;
        CurrentMoney_Counter.text = CurrentMoney.ToString();

    }

    public void LoseMoney(int MoneyLost)
    {

        if (CurrentMoney - MoneyLost < 0)
        {
            Debug.Log("You require additional money.");

        }else
        {
            //subtracts money from player and presents in to money UI
            CurrentMoney -= MoneyLost;
            CurrentMoney_Counter.text = CurrentMoney.ToString();

        }
    }
}
