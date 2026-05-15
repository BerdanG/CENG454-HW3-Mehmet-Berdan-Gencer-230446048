using UnityEngine;

public class CoreHealth : MonoBehaviour, IDamageable
{
    [SerializeField] int maxHealth = 100;

    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        Debug.Log("Core took damage: " + amount);

        GameEvents.OnCoreDamaged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("CORE DESTROYED");

            GameEvents.OnCoreDestroyed?.Invoke();
        }
    }
}