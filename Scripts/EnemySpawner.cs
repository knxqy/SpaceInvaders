using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnOrder;

    int spawnIndex = 0;

    [SerializeField] float spawnInterval = 2f;
    float spawnCountdown;


    // Start is called before the first frame update
    void Start()
    {
        spawnCountdown = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCountdown -= Time.deltaTime;
        if (spawnCountdown <= 0)
        {
            Instantiate(spawnOrder[spawnIndex]);
            spawnIndex++;
            spawnCountdown = spawnInterval;
            if (spawnIndex >= spawnOrder.Length)
            {
                spawnIndex = 0;
            }
        }
    }
}
