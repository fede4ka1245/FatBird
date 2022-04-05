using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Respawner : MonoBehaviour, IRespawner
{
    [SerializeField]
    protected float XDestroyPosition;
    [SerializeField]
    protected GameObject[] Objects;

    public void Respawn()
    {
        for (int index = 0; index < Objects.Length; index++)
        {
            if (Objects[index].transform.position.x <= XDestroyPosition)
            {
                Objects[index].transform.position = GetRespawnPosition();
                SetLastRespawnObject(Objects[index]);
            }
        }
    }

    public abstract Vector3 GetRespawnPosition();
    protected abstract void SetLastRespawnObject(GameObject @object);


    protected void FixedUpdate()
    {
        Respawn();
    }
}
