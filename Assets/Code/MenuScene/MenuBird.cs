using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuBird : MonoBehaviour
{
    public Birds Bird;
    public int HighScoreForOpenning;
    protected Save save;
    protected void Awake()
    {
        save = Save.GetData();
    }
    public virtual bool IsOpened()
    {
        return HighScoreForOpenning < save.HighScore;
    }
}
