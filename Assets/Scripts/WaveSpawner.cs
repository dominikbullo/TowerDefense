using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // bacuse text


public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public Text waveCountdownText;

    // TODO: change on real game
    public float timeBetweenWaves = 5.5f;
    private float countdown = 0f;

    private int waveIndex = 0;
    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity); //not will be less tha 0
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
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
    }
}
