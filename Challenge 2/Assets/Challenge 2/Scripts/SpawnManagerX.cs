using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    private float spawnLimitXLeft = -22;
    public float spawnLimitXRight = 9;
    public float spawnPosY = 15;

    private float startDelay = 1.0f;
    private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomBall();
    }
    private void Update()
    {

    }
    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        //Randomizes the position and type of dog spawned

        int ballIndex = Random.Range(0, ballPrefabs.Length);
        spawnInterval = Random.Range(3.0f, 5.0f);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        Debug.Log(spawnInterval);
        Invoke("SpawnRandomBall", spawnInterval);

        // Spawns the dogs randomly in a randomy position

        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }
}
