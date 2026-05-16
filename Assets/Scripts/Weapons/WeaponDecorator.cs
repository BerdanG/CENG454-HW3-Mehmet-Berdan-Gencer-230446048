using UnityEngine;

public abstract class WeaponDecorator : IWeapon
{
    protected IWeapon wrappedWeapon;

    public WeaponDecorator(IWeapon weapon)
    {
        wrappedWeapon = weapon;
    }

    public virtual void Shoot(Transform firePoint)
    {
        wrappedWeapon.Shoot(firePoint);
    }
}