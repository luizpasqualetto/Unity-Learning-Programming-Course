using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int numBalls;
    public GameObject ball;
    [SerializeField] float spawnRange = 20.0f;
    [SerializeField] float startDelay = 2f;
    [SerializeField] float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBalls", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBalls()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), Random.Range(3, 4), Random.Range(-spawnRange, spawnRange));

        Instantiate(ball, spawnPos, ball.transform.rotation);
    }
}
