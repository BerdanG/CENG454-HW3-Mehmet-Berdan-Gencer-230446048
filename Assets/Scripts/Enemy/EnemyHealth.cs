using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] int maxHealth = 30;
    [SerializeField] GameObject deathEffectPrefab;

    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            GameEvents.OnEnemyDestroyed?.Invoke();

            if (deathEffectPrefab != null)
            {
                GameObject effect = Instantiate(
                    deathEffectPrefab,
                    transform.position,
                    Quaternion.identity
                );

                Destroy(effect, 2f);
            }
            
            Destroy(gameObject);
        }
    }
}