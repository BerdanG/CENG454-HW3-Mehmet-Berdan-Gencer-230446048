using UnityEngine;

public class CoreAttackStrategy : IAttackStrategy
{
    public void Attack(Transform origin, Transform target)
    {
        if (target == null) return;

        Vector3 direction =
            (target.position - origin.position).normalized;

        origin.Translate(direction * 3f * Time.deltaTime, Space.World);
    }
}