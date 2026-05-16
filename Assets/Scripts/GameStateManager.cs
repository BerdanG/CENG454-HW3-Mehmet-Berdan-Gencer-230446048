using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    void OnEnable()
    {
        GameEvents.OnCoreDestroyed += HandleGameOver;
    }

    void OnDisable()
    {
        GameEvents.OnCoreDestroyed -= HandleGameOver;
    }

    void HandleGameOver()
    {
        Debug.Log("GAME OVER");
    }
}