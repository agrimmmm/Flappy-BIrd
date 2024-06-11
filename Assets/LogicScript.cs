using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int PlayerScore = 0;
    public int HighScore = 0;
    public Text scoreText;
    public GameObject GameOver;
    public Text highScoreText;
    public GameObject StartScreen;
    public GameObject Bird;
    public GameObject PipeSpawner;

    [ContextMenu("UpdateScore")]
    public void UpdateScore(int addend)
    {
        PlayerScore += addend;
        scoreText.text = PlayerScore.ToString();
    } 

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Game_Over()
    {
        GameOver.SetActive(true);
        if (PlayerScore > HighScore)
        {
            HighScore = PlayerScore;
            PlayerPrefs.SetInt("HighScore", HighScore);
            PlayerPrefs.Save();
        }
    }

    public void StartGame()
    {
        StartScreen.SetActive(false);
        Bird.SetActive(true);
        PipeSpawner.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GetHighScore()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = HighScore.ToString();
    }
}
