using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResToggle : MonoBehaviour
{
    bool isPressed = true;
    public GameObject panel;
    public FullScreenCheck fSC;


	// Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void togglePanel()
    {
        panel.SetActive(isPressed);
        isPressed = !isPressed;
    }
    bool checkFS()
    {
        if (Screen.fullScreen == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void optionOne()
    {
        Screen.SetResolution(1024, 768, checkFS());
        fSC.setRes(Screen.currentResolution);
    }
    public void optionTwo()
    {
        Screen.SetResolution(1280, 1024, checkFS());
        fSC.setRes(Screen.currentResolution);
    }
    public void optionThree()
    {
        Screen.SetResolution(1366, 768, checkFS());
        fSC.setRes(Screen.currentResolution);
    }
    public void optionFour()
    {
        Screen.SetResolution(1920, 1080, checkFS());
        fSC.setRes(Screen.currentResolution);
    }
}
