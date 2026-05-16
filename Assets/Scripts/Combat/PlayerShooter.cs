using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform firePoint;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject projectile =
            ProjectilePool.Instance.GetProjectile();

        projectile.transform.position = firePoint.position;

        projectile.transform.rotation = firePoint.rotation;
    }
}