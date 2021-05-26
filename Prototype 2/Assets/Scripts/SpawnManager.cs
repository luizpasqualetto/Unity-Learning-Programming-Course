using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] dogPrefabs;
    public float spawnDistance = 20.0f;
    public float spawnRange = 20.0f;
    public float startDelay = 2;
    public float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomDog", startDelay, spawnInterval);
    }


    void Update()
    {

    }

    void SpawnRandomDog()
    {
        //Randomizes the position and type of dog spawned
        int dogIndex = Random.Range(0, dogPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 0, spawnDistance);

        // Spawns the dogs randomly in a randomy position
        Instantiate(dogPrefabs[dogIndex], spawnPos, dogPrefabs[dogIndex].transform.rotation);
    }
}
