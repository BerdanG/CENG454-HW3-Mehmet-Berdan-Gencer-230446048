using UnityEngine;

public class PlayerChaseStrategy : IAttackStrategy
{
    public void Attack(Transform origin)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null) return;

        Vector3 direction =
            (player.transform.position - origin.position).normalized;

        origin.Translate(direction * 3f * Time.deltaTime, Space.World);
    }
}