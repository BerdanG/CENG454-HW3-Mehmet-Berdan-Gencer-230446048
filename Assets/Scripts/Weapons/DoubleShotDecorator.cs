using UnityEngine;

public class DoubleShotDecorator : WeaponDecorator
{
    public DoubleShotDecorator(IWeapon weapon)
        : base(weapon)
    {
    }

    public override void Shoot(Transform firePoint)
    {
        base.Shoot(firePoint);

        Vector3 offset = firePoint.right * 0.5f;

        SpawnProjectile(firePoint.position + offset, firePoint.rotation);
    }

    void SpawnProjectile(Vector3 position, Quaternion rotation)
    {
        GameObject projectile =
            ProjectilePool.Instance.GetProjectile();

        projectile.transform.position = position;

        projectile.transform.rotation = rotation;
    }
}