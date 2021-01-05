using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // bacuse text


public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public Text waveCountdownText;

    // TODO: change on real game
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 0;
    // Update is called once per frame
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
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
        waveIndex++;
        // TODO maybe after wave is over
        PlayerStats.Rounds++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
