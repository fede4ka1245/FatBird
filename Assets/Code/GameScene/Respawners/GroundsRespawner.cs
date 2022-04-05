using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundsRespawner : Respawner, IRespawner
{
    [SerializeField] GameObject lastInstalledGround;
    [SerializeField] float distanceBetweenGrounds;
    public override Vector3 GetRespawnPosition()
    {
        return new Vector3(lastInstalledGround.transform.position.x + distanceBetweenGrounds,
            lastInstalledGround.transform.position.y, lastInstalledGround.transform.position.z);
    }

    protected override void SetLastRespawnObject(GameObject @object)
    {
        lastInstalledGround = @object;
    }

    void Start()
    {
        Objects = GameObject.FindGameObjectsWithTag("Ground");
    }
}
