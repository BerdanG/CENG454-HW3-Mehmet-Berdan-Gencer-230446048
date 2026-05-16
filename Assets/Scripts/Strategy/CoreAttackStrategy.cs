using UnityEngine;

public class CoreAttackStrategy : IAttackStrategy
{
    public void Attack(Transform origin)
    {
        GameObject core = GameObject.FindGameObjectWithTag("Core");

        if (core == null) return;

        Vector3 direction =
            (core.transform.position - origin.position).normalized;

        origin.Translate(direction * 3f * Time.deltaTime, Space.World);
    }
}