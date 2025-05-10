using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject shieldPowerupPrefab; // Assign shield powerup prefab
    public float spawnInterval = 2f;
    public float xRange = 8f;
    public float shieldSpawnChance = 0.2f; // 20% chance

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-xRange, xRange);
        Vector3 spawnPos = new Vector3(randomX, 4f, 0);
        
        // Spawn enemies or shield powerups
        if (Random.value < shieldSpawnChance)
        {
            Instantiate(shieldPowerupPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}
