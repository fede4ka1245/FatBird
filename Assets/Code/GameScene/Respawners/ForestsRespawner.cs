using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestsRespawner : Respawner, IRespawner
{
    [SerializeField] GameObject lastInstalledForest;
    [SerializeField] float distanceBetweenForests;
    public override Vector3 GetRespawnPosition()
    {
        return new Vector3(lastInstalledForest.transform.position.x + distanceBetweenForests,
            lastInstalledForest.transform.position.y, lastInstalledForest.transform.position.z);
    }

    protected override void SetLastRespawnObject(GameObject @object)
    {
        lastInstalledForest = @object;
    }

    void Start()
    {
        Objects = GameObject.FindGameObjectsWithTag("Forest");
    }
}
