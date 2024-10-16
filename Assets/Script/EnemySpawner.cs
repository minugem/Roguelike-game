using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;               // The enemy prefab to spawn
    public Transform[] spawnPositions;           // Array of spawn positions
    public float spawnInterval = 6f;             // Time between spawns (in seconds) to reach 10 spawns per minute
    public int maxEnemies = 10;                  // Maximum number of enemies allowed in the scene

    public int currentEnemyCount = 0;

    private void Start()
    {
        if (spawnPositions.Length == 0)
        {
            Debug.LogError("No spawn positions set!");
            return;
        }

        // Start spawning enemies at regular intervals
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Only spawn if the current enemy count is less than the max
            if (currentEnemyCount < maxEnemies)
            {
                // Choose a random spawn position from the array
                Transform spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];

                // Spawn the enemy
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition.position, Quaternion.identity);

                // Increment the current enemy count
                currentEnemyCount++;
            }

            // Wait for the specified interval before the next spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
