using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudRespawner : Respawner, IRespawner
{
    [SerializeField]
    Vector2 MaxMinPositionY;
    [SerializeField]
    Vector2 MaxMinPositionZ;
    [SerializeField]
    Vector3[] SpawnPositions;
    [SerializeField]
    float distanceBetweenClouds;
    int indexReturnedPosition;
    [SerializeField] GameObject lastInstalledCloud;
    [SerializeField] GameObject[] clouds;
    public override Vector3 GetRespawnPosition()
    {
        Vector3 respawnPosition;
        float xSpawnPositions = distanceBetweenClouds + lastInstalledCloud.transform.position.x;
        if (indexReturnedPosition < SpawnPositions.Length - 1)
        {
            indexReturnedPosition++;
        }
        else
        {
            indexReturnedPosition = 0;
        }
        SpawnPositions[indexReturnedPosition].x = xSpawnPositions;
        respawnPosition = SpawnPositions[indexReturnedPosition];
        return respawnPosition;
    }

    protected override void SetLastRespawnObject(GameObject @object)
    {
        lastInstalledCloud = @object;
    }

    void Awake()
    {
        CreateSpawnPositions();
        Spawn();
        Objects = GameObject.FindGameObjectsWithTag("Cloud");
    }

    void CreateSpawnPositions()
    {
        for (int index = 0; index < SpawnPositions.Length; index++)
        {
            SpawnPositions[index] = new Vector3(0,
                Random.Range(MaxMinPositionY.x, MaxMinPositionY.y),
                Random.Range(MaxMinPositionZ.x, MaxMinPositionZ.y));
        }
    }

    Vector3 GetSpawnPosition()
    {
        return GetRespawnPosition();
    }

    void Spawn()
    {
        foreach (var @object in clouds)
        {
            var obj = Instantiate(@object, GetSpawnPosition(), Quaternion.identity);
            SetLastRespawnObject(obj);
        }
    }
}
