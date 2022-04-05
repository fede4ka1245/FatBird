using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    MenuBird[] birds;
    int birdsIndex;
    [SerializeField]
    Text highScoreText;
    Save save;
    [SerializeField]
    GameObject buttonPlay;
    [SerializeField]
    Text enoghScore;
    Birds selectedBird;

    void Start()
    {
        save = Save.GetData();
        highScoreText.text = $"BEST: {save.HighScore}";
        ShowSelectedBird();
    }

    void ShowSelectedBird()
    {
        birds[birdsIndex].gameObject.SetActive(true);
        selectedBird = birds[birdsIndex].Bird;
        if (birds[birdsIndex].IsOpened())
        {
            buttonPlay.SetActive(true);
            enoghScore.gameObject.SetActive(false);
        }
        else
        {
            buttonPlay.SetActive(false);
            enoghScore.gameObject.SetActive(true);
            enoghScore.text = $"Get it for \"BEST\" more than {birds[birdsIndex].HighScoreForOpenning}";
        }
    }

    public void SelectNextBird()
    {
        birds[birdsIndex].gameObject.SetActive(false);
        if (birdsIndex < birds.Length - 1)
        {
            birdsIndex++;
        }
        else
        {
            birdsIndex = 0;
        }
        ShowSelectedBird();
    }
    public void SelectPrevBird()
    {
        birds[birdsIndex].gameObject.SetActive(false);
        if (birdsIndex > 0)
        {
            birdsIndex--;
        }
        else
        {
            birdsIndex = birds.Length - 1;
        }
        ShowSelectedBird();
    }

    void SaveData()
    {
        save.SelectedBird = selectedBird;
        Save.SaveData(save);
    }

    public void LoadGameScene()
    {
        SaveData();
        SceneTransition.SwitchToScene("Game");
    }

    
}
