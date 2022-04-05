using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawner : MonoBehaviour
{
    [SerializeField]
    protected GameObject Pipes; 
    [SerializeField]
    protected float StartSpawnPositionOnXAxis;
    [SerializeField]
    protected int PipesCount;
    protected float DistanceBetweenPipes;
    PipesRespawner pipesRespawner;

    private void Awake()
    {
        pipesRespawner = FindObjectOfType<PipesRespawner>();
        DistanceBetweenPipes = pipesRespawner.DistanceBetweenPipes;
        Spawn();
    }

    public void Spawn()
    {
        float xPosition = StartSpawnPositionOnXAxis;
        for (int index = 0; index < PipesCount; index++)
        {
            float yPosition = Random.Range(pipesRespawner.MaxAndMinSpawnPositionOnYAxis.x,
                pipesRespawner.MaxAndMinSpawnPositionOnYAxis.y);
            Vector3 spawnPosition = new Vector3(xPosition, yPosition, Pipes.transform.position.x);
            pipesRespawner.LastInstalledPipes = Instantiate(Pipes, spawnPosition, Quaternion.identity);
            xPosition += DistanceBetweenPipes;
        }
    }
}
