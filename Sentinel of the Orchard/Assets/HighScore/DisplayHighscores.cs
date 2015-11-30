using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour {

    public Text[] highscoreText;
    HighScores highscoreManager;



	// Use this for initialization
	void Start () {
	for(int i = 0; i<highscoreText.Length; i++)
        {
            highscoreText[i].text = i+1 + ". Fetching...";
        }

        highscoreManager = GetComponent<HighScores>();
        StartCoroutine("RefreshHighscores");
    }
	

	// Update is called once per frame
	void Update () {
	}


    public void OnHighscoresDownloaded(Highscore[] highscoreList)
    {
        for (int i = 0; i< highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ". ";
            if(highscoreList.Length > i)
            {
                highscoreText[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
            }
        }
    }

    IEnumerator RefreshHighscores()
    {
        while (true)
        {
            highscoreManager.DownloadHighscores();
            yield return new WaitForSeconds(30);
        }
    }
}
