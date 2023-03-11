using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemieSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;

    private float timer = 1;
    private int amount = 1;

    private bool TimerFinished()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = 2;
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerFinished() && !GameManager.instance.gameOver)
        {
            for (int i = 0; i < amount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-30, 30), 18, 0);
                Instantiate(asteroidPrefab, spawnPosition, asteroidPrefab.transform.rotation);
            }
            amount += 1;
        }
    }
}
