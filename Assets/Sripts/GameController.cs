using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int totalScore;
    public Text scoreText;

    public GameObject gameOver;
    public GameObject win;
    public GameObject pause;

    public static GameController instance;

    bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void ShowWin()
    {
        win.SetActive(true);
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

    void Update () {
        if (Input.GetKeyDown (KeyCode.P)) 
        {
            isPause = !isPause;

            if (isPause) {
                Pause ();
            }
            else
            {
                UnPause();
            }
        }
    }
}
