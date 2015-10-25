using UnityEngine;
using System.Collections;

public class ExitGame : MonoBehaviour {


    public void Quit ()
	{
        Time.timeScale = 1;
        Application.Quit ();
	}
}
