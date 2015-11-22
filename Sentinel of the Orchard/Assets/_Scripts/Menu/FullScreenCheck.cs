﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FullScreenCheck : MonoBehaviour {

    Text instruction;
    bool isFS = false;
    Resolution currentRes;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        checkFS();
        instruction = GetComponent<Text>();
        currentRes = Screen.currentResolution;
        if (isFS)
            instruction.text = "Fullscreen";
        else if (isFS == false)
            instruction.text = "Windowed";
    }
    void checkFS ()
    {
        if(Screen.fullScreen == true)
            isFS = true;
        else if(Screen.fullScreen == false)
            isFS = false;
    }
    public void changeState ()
    {
        checkFS();
        isFS = !isFS;

        Screen.SetResolution(currentRes.width, currentRes.height, isFS);
    }
}