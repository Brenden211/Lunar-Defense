using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Transform spawnPointTwo;
    public Transform spawnPointThree;
    public float timeBetweenWaves = 30f;
    public Text waveCountdownText;

    private float countdown = 60f;
    private int waveIndex = 0;

    void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave ()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1.0f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        Instantiate(enemyPrefab, spawnPointTwo.position, spawnPointTwo.rotation);
        Instantiate(enemyPrefab, spawnPointThree.position, spawnPointThree.rotation);
    }

}
