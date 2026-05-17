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
        if (GameStateManager.CurrentState == GameState.Lost
            || GameStateManager.CurrentState == GameState.Won)
        {
            return;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            currentWeapon.Shoot(firePoint);
        }
    }
}