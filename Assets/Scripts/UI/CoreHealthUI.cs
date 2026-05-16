using UnityEngine;

public class CoreHealthUI : MonoBehaviour
{
    void OnEnable()
    {
        GameEvents.OnCoreDamaged += HandleCoreDamaged;
    }

    void OnDisable()
    {
        GameEvents.OnCoreDamaged -= HandleCoreDamaged;
    }

    void HandleCoreDamaged(int currentHealth)
    {
        Debug.Log("UI Updated. Core Health: " + currentHealth);
    }
}