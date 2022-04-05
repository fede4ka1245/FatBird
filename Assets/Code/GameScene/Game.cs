using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Game : MonoBehaviour
{
    public float Speed;

    public int Score;
    int highScore;
    [SerializeField]
    Text highScoreText;
    [SerializeField]
    Text scoreText;

    [SerializeField]
    GameObject startUI;
    [SerializeField]
    GameObject deathUI;

    IBird bird;
    Save save;

    [SerializeField]
    GameObject shield;

    [SerializeField]
    GameObject buttonReborn;
    int adsCounter;

    private void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("4251905", false);
        }
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<IBird>();

        save = Save.GetData();
        highScore = save.HighScore;

        ShowScore();
        adsCounter = 0;

        Time.timeScale = 0;
    }

    public void ShowScore()
    {
        scoreText.text = Score.ToString();
        if (Score > highScore)
        {
            highScore = Score;
        }
        highScoreText.text = $"BEST: {highScore}";
    }



    public void Death()
    {
        deathUI.SetActive(true);
        if (adsCounter > 2)
        {
            buttonReborn.SetActive(false);
        }
    }

    void SaveAll()
    {
        save.HighScore = highScore;
        Save.SaveData(save);
    }

    public void Replay()
    {
        SaveAll();
        SceneManager.LoadScene("Game");
    }

    public void LoadMenuScene()
    {
        SaveAll();
        SceneTransition.SwitchToScene("Menu");
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startUI.SetActive(false);
        bird.Jump();
    }

    public void Reborn()
    {
        if (Advertisement.IsReady())
        {
            StartCoroutine(RebornCoroutine());
            Advertisement.Show("Rewarded_Android");
        }
    }

    IEnumerator RebornCoroutine()
    {
        bird.Reborn();
        deathUI.SetActive(false);
        adsCounter++;

        yield return new WaitForSecondsRealtime(2f);

        startUI.SetActive(true);
    }

    public void OffShield()
    {
        shield.SetActive(false);
    }

    public void OnShield()
    {
        shield.SetActive(true);
    }

}
