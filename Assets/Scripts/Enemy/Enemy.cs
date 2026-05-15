using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int damageAmount = 10;
    [SerializeField] bool targetPlayer;

    IAttackStrategy attackStrategy;

    void Start()
    {
        if (targetPlayer)
        {
            attackStrategy = new PlayerChaseStrategy();
        }
        else
        {
            attackStrategy = new CoreAttackStrategy();
        }
    }

    void Update()
    {
        attackStrategy?.Attack(transform);
    }

    void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(damageAmount);

            Destroy(gameObject);
        }
    }
}