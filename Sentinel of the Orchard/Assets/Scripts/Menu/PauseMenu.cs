using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    bool paused = false;
    public GameObject pauseUI;

	void Start () {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = (false);
        Time.timeScale = 1;

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(paused, pauseUI);
            paused = !paused;
        }
    }

    void PauseGame(bool isPaused, GameObject pausemenu)
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            pausemenu.SetActive(isPaused);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            pausemenu.SetActive(isPaused);
        }
    }

    public bool pauseCheck ()
    {
        return pauseUI.activeInHierarchy;
    }

    public void Quit ()
    {
        Application.Quit();
    }
}
