using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] float spawnRangeX = 20f;
    [SerializeField] float spawnRangeZ = 10f;


    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }


    void SpawnEnemy()
    {
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