using UnityEngine;

public class CoreAttackStrategy : IAttackStrategy
{
    public void Attack(Transform origin, Transform target, float moveSpeed)
    {
        if (target == null) return;

        Vector3 direction =
            (target.position - origin.position).normalized;

        origin.Translate
        (
            direction * moveSpeed * Time.deltaTime,
            Space.World
        );
    }
}