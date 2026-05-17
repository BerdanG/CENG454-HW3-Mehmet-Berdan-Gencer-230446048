using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool Instance;

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] int poolSize = 20;

    Queue<GameObject> projectilePool = new Queue<GameObject>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab);

            projectile.SetActive(false);

            projectilePool.Enqueue(projectile);
        }
    }

    public GameObject GetProjectile()
    {
        if (projectilePool.Count > 0)
        {
            GameObject projectile = projectilePool.Dequeue();

            projectile.SetActive(true);

            return projectile;
        }

        GameObject newProjectile = Instantiate(projectilePrefab);

        return newProjectile;
    }

    public void ReturnProjectile(GameObject projectile)
    {
        projectile.SetActive(false);

        projectilePool.Enqueue(projectile);
    }
}