using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] int maxHealth = 100;

    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (currentHealth <= 0)
        {
            return;
        }

        currentHealth -= amount;

        Debug.Log("Player took damage: " + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("PLAYER DEAD");

            GameEvents.OnCoreDestroyed?.Invoke();
        }
    }
}