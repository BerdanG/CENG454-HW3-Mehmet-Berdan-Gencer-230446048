using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int damageAmount = 10;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] GameObject explosionEffectPrefab;
    [SerializeField] GameObject playerHitEffectPrefab;

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
        if (other.CompareTag("Projectile"))
        {
            return;
        }
        
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (other.CompareTag("Player"))
        {
            if (playerHitEffectPrefab != null)
            {
                GameObject hitEffect = Instantiate(
                    playerHitEffectPrefab,
                    transform.position,
                    Quaternion.identity
                );

                Destroy(hitEffect, 2f);
            }
        }

        if (damageable != null)
        {
            damageable.TakeDamage(damageAmount);
            GameObject explosion = Instantiate
            (
                explosionEffectPrefab,
                transform.position,
                Quaternion.identity
            );

            Destroy(explosion, 2f);
            Destroy(gameObject);
        }
    }

    public void SetTargetPlayer(bool value)
    {
        targetPlayer = value;
    }
}