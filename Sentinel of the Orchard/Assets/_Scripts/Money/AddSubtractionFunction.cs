using UnityEngine;
using System.Collections;

public class AddSubtractionFunction : MonoBehaviour
{

    public GameObject player;
    

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            player.GetComponent<MoneySystem>().GainMoney(50);

        }
        
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            player.GetComponent<MoneySystem>().LoseMoney(50);
        }

    }
}
