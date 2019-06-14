using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject spawnable;
    public bool stopSpawnig = false;
    public float spawnTime;
    public float spawnDelay;
    
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        Instantiate(spawnable, transform.position, transform.rotation);
        if (stopSpawnig)
        {
            CancelInvoke("SpawnObject");
        }
    }

}
