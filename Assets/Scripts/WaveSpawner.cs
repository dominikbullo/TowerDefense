﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // bacuse text


public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public Text waveCountdownText;

    public GameManager gameManager;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 0;

    void Start()
    {
        EnemiesAlive = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex >= waves.Length)
        {
            if (!GameManager.GameIsOver)
            {
                gameManager.WinLevel();
            }
            this.enabled = false; // disable the whole script 
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity); //not will be less tha 0
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
        if (countdown <= 0)
        {
            waveCountdownText.text = string.Format("{0:00.00}", timeBetweenWaves);
        }
    }
    /* IEnumerator because pausing code
       Found in using System.Collections */
    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;
        Wave wave = waves[waveIndex];
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
