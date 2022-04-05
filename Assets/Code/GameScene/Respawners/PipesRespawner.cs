using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesRespawner : Respawner, IRespawner
{
    public Vector2 MaxAndMinSpawnPositionOnYAxis;
    public GameObject LastInstalledPipes;
    public float DistanceBetweenPipes;
    [SerializeField]
    float[] yRandomPositions;
    int yRandomPositionsIndex;
    public override Vector3 GetRespawnPosition()
    {
        return new Vector3(LastInstalledPipes.transform.position.x + DistanceBetweenPipes,
            GetRandomPipesPositionY(), LastInstalledPipes.transform.position.z);
    }

    protected override void SetLastRespawnObject(GameObject @object)
    {
        LastInstalledPipes = @object;
    }

    public float GetRandomPipesPositionY()
    {
        if (yRandomPositionsIndex < yRandomPositions.Length - 1)
        {
            yRandomPositionsIndex++;
        }
        else
        {
            yRandomPositionsIndex = 0;
        }
        return yRandomPositions[yRandomPositionsIndex];
    }

    void Start()
    {
        Objects = GameObject.FindGameObjectsWithTag("Pipes");
        CreateRandomPositions();
    }

    void CreateRandomPositions()
    {
        for (int index = 0; index < yRandomPositions.Length; index++)
        {
            yRandomPositions[index] = Random.Range(MaxAndMinSpawnPositionOnYAxis.x,
                MaxAndMinSpawnPositionOnYAxis.y);
        }
    }
}
