using UnityEngine;

public class BasicWeapon : IWeapon
{
    public void Shoot(Transform firePoint)
    {
        GameObject projectile =
            ProjectilePool.Instance.GetProjectile();

        projectile.transform.position = firePoint.position;

        projectile.transform.rotation = firePoint.rotation;
    }
}