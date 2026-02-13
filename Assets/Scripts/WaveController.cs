using UnityEngine;

public class WaveController : MonoBehaviour
{
    public Wave currentWave;
    public Transform[] spawnPoints;

    private int enemySpawned = 0;
    private float nextSpawnTime = 0;

    void Update()
    {
        var t = Time.time;
        if (t > nextSpawnTime && enemySpawned < currentWave.enemyCount)
        {
            Spawn();
            enemySpawned++;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
        }
    }


    void Spawn()
    {
        int enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(currentWave.enemyPrefabs[enemyIndex], spawnPoints[spawnPointIndex].position, currentWave.enemyPrefabs[enemyIndex].transform.rotation);
    }

   
}
