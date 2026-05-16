using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int damageAmount = 10;
    [SerializeField] bool targetPlayer;
    [SerializeField] float moveSpeed = 3f;

    IAttackStrategy attackStrategy;

    Transform currentTarget;

    void Start()
    {
        if (targetPlayer)
        {
            attackStrategy = new PlayerChaseStrategy();

            GameObject player =
                GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                currentTarget = player.transform;
            }
        }
        else
        {
            attackStrategy = new CoreAttackStrategy();

            GameObject core =
                GameObject.FindGameObjectWithTag("Core");

            if (core != null)
            {
                currentTarget = core.transform;
            }
        }
    }

    void Update()
    {
        attackStrategy?.Attack(transform, currentTarget);
    }

    void OnTriggerEnter(Collider other)
    {
        IDamageable damageable =
            other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(damageAmount);

            Destroy(gameObject);
        }
    }
}