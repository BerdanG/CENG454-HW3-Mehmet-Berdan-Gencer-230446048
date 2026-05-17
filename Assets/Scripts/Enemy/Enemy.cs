using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int damageAmount = 10;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] GameObject explosionEffectPrefab;

    bool targetPlayer;

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
        attackStrategy?.Attack
        (
            transform,
            currentTarget,
            moveSpeed
        );
    }

    void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(damageAmount);
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void SetTargetPlayer(bool value)
    {
        targetPlayer = value;
    }
}