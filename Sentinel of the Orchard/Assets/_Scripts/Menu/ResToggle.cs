using UnityEngine;
using System.Collections;

public class ResToggle : MonoBehaviour
{
    bool isPressed = false;
    public GameObject panel;


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            togglePanel(isPressed, panel);
        }
    }

    void togglePanel(bool isPressed, GameObject panel)
    {
        if(isPressed)
        {
            panel.SetActive(isPressed);
            isPressed = !isPressed;
        }
        else
        {
            panel.SetActive(isPressed);
            isPressed = !isPressed;
        }
    }
}
