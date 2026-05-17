using UnityEngine;

public interface IAttackStrategy
{
    void Attack
    (
        Transform origin,
        Transform target,
        float moveSpeed
    );
}