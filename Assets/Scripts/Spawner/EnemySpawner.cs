using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] float spawnRangeX = 20f;
    [SerializeField] float spawnRangeZ = 10f;
    [SerializeField] int maxEnemyCount = 30;

    int currentEnemyCount;


    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }


    void OnDisable()
    {
        GameEvents.OnEnemyDestroyed -= HandleEnemyDestroyed;
    }


    void OnEnable()
    {
        GameEvents.OnEnemyDestroyed += HandleEnemyDestroyed;
    }


    void HandleEnemyDestroyed()
    {
        currentEnemyCount--;
    }


    void SpawnEnemy()
    {
        if (currentEnemyCount >= maxEnemyCount)
        {
            return;
        }

        Vector3 randomOffset = new Vector3
        (
            Random.Range(-spawnRangeX, spawnRangeX),
            0f,
            Random.Range(-spawnRangeZ, spawnRangeZ)
        );

        Vector3 spawnPosition = transform.position + randomOffset;

        GameObject enemy = Instantiate
        (
            enemyPrefab,
            spawnPosition,
            Quaternion.identity
        );

        currentEnemyCount++;

        Enemy enemyScript = enemy.GetComponent<Enemy>();

        if (enemyScript != null)
        {
            enemyScript.SetTargetPlayer
            (
                Random.value > 0.5f
            );
        }
    }
}