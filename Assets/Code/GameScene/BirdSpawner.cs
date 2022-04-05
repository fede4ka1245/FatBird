using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    Vector3 spawnPosition = new Vector3(-5.5f, -2f, 0f);
    Save save;
    Birds selectedBird;

    [SerializeField] GameObject YellowBird;
    [SerializeField] GameObject PinkBird;
    [SerializeField] GameObject BlackBird;
    [SerializeField] GameObject BlueBird;
    [SerializeField] GameObject RedBird;
    void Awake()
    {
        save = Save.GetData();
        selectedBird = save.SelectedBird;
        Spawn();
    }

    void SpawnBird(GameObject bird)
    {
        Instantiate(bird, spawnPosition, Quaternion.identity);
    }

    void Spawn()
    {
        switch(selectedBird)
        {
            case Birds.Yellow:
                SpawnBird(YellowBird);
                break;
            case Birds.Pink:
                SpawnBird(PinkBird);
                break;
            case Birds.Black:
                SpawnBird(BlackBird);
                break;
            case Birds.Blue:
                SpawnBird(BlueBird);
                break;
            case Birds.Red:
                SpawnBird(RedBird);
                break;
        }
    }

}
