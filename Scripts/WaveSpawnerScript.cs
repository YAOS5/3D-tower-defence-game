using System.Collections;
using UnityEngine;
using UnityEngine.UI; // required for referencing the text element

public class WaveSpawnerScript : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public float timeBetweenEnemySpawns = 0.5f;

    private float countdown = 2f;
    private int waveIndex = 0;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (countdown <= 0f) {
            // Starts the coroutine method
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
    }

    // Makes this method into a co-routine (i think that means it executes on a separate thread?)
    IEnumerator SpawnWave() {

        waveIndex++;

        for (int i = 0; i < waveIndex; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemySpawns); // waits 0.5 seconds before spawning the next enemy
        }
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
