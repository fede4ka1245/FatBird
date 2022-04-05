using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Save
{
    const string key = "Save";

    public int HighScore;
    public Birds SelectedBird;


    public static Save GetData()
    {
        if (PlayerPrefs.HasKey(key))
        {
            return JsonUtility.FromJson<Save>(PlayerPrefs.GetString(key));
        }
        return new Save();
    }
    public static void SaveData(Save save)
    {
        PlayerPrefs.SetString(key, JsonUtility.ToJson(save));
    }
}
