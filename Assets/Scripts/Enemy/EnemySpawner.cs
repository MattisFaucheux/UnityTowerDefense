using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Vector3 enemyStartingDir;
    [Min(0)] [SerializeField] private float timeBetweenSpawnMin = 0.25f;
    [Min(0)] [SerializeField] private float timeBetweenSpawnMax = 0.5f;
    [Min(0)] [SerializeField] private float timeBetweenWavesMin = 1.0f;
    [Min(0)] [SerializeField] private float timeBetweenWavesMax = 2.0f;
    [Min(0)] [SerializeField] private int nbEnemiesToSpawnMin = 1;
    [Min(0)] [SerializeField] private int nbEnemiesToSpawnMax = 5;
    [SerializeField] private bool spawnAtStart = true;
    private float currentTimer;
    private bool canSpawn = true;

    void Start()
    {
        if(spawnAtStart)
        {
            StartCoroutine(SpawnEnemyWave());
        }
        else
        {
            currentTimer = Random.Range(timeBetweenWavesMin, timeBetweenWavesMax);
        }
    }

    void Update()
    {
        currentTimer -= Time.deltaTime;
        if(currentTimer < 0 && canSpawn)
        {
            StartCoroutine(SpawnEnemyWave());
        }
    }

    private IEnumerator SpawnEnemyWave()
    {
        canSpawn = false;

        for (int i=0; i < Random.Range(nbEnemiesToSpawnMin, nbEnemiesToSpawnMax + 1); i++)
        {
            GameObject Enemy = Instantiate(enemyPrefab, transform);
            Enemy.GetComponent<EnemyMovement>().SetDirection(enemyStartingDir);
            yield return new WaitForSeconds(Random.Range(timeBetweenSpawnMin, timeBetweenSpawnMax));
        }

        currentTimer = Random.Range(timeBetweenWavesMin, timeBetweenWavesMax);
        canSpawn = true;
    }
}
