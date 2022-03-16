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
    public float timeBetweenWaves = 10f;
    public Text waveCountdownText;
    public float waveCounter = 1f;
    public float startCountdown = 30f;

    private int waveIndex = 0;

    void Start()
    {
        waveCounter = 1f;
    }

    void Update()
    {
        if (startCountdown <= 0)
        {
            StartCoroutine(SpawnWave());
            startCountdown = timeBetweenWaves;
        }

        startCountdown -= Time.deltaTime;

        startCountdown = Mathf.Clamp(startCountdown, 0f, Mathf.Infinity);

        waveCountdownText.text = " wave " + waveCounter + ": " + string.Format("{0:00}", startCountdown);
    }

    IEnumerator SpawnWave ()
    {
        waveIndex++;
        PlayerStats.Rounds++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1.0f);
        }

        waveCounter++;
    }

    void SpawnEnemy()
    {
        if (waveCounter < 5)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            Instantiate(enemyPrefab, spawnPointTwo.position, spawnPointTwo.rotation);
            Instantiate(enemyPrefab, spawnPointThree.position, spawnPointThree.rotation);
        }
        else if (waveCounter > 5 && waveCounter < 10)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        
    }

}
