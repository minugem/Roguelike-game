using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 10f;
    public float spawnInterval = 10f;
    public int maxEnemies = 100;

    private Transform playerTransform;
    private float timer;
    private int enemyCount;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && enemyCount < maxEnemies)
        {
            SpawnEnemy();
            timer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPos = new Vector3(spawnPosition.x, 0, spawnPosition.y) + playerTransform.position;
        
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        enemyCount++;
    }

}