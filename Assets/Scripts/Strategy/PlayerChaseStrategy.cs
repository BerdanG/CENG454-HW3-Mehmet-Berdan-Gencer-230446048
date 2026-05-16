using UnityEngine;

public class PlayerChaseStrategy : IAttackStrategy
{
    public void Attack(Transform origin, Transform target)
    {
        if (target == null) return;

        Vector3 direction =
            (target.position - origin.position).normalized;

        origin.Translate(direction * 3f * Time.deltaTime, Space.World);
    }
}