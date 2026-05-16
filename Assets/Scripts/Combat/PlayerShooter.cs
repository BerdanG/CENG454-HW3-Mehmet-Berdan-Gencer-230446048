using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] Transform firePoint;

    IWeapon currentWeapon;

    void Start()
    {
        currentWeapon =
            new DoubleShotDecorator(
                new BasicWeapon()
            );
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentWeapon.Shoot(firePoint);
        }
    }
}