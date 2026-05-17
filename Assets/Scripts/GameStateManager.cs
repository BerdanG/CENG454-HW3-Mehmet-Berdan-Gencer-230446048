using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameState CurrentState
        = GameState.Playing;

    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject winText;
    [SerializeField] int enemiesToDefeat = 20;

    int defeatedEnemies;

    void OnEnable()
    {
        GameEvents.OnCoreDestroyed += HandleLose;

        GameEvents.OnEnemyDestroyed += HandleEnemyDestroyed;
    }

    void Start()
    {
        CurrentState = GameState.Playing;

        gameOverText.SetActive(false);
        winText.SetActive(false);
    }
    
    void OnDisable()
    {
        GameEvents.OnCoreDestroyed -= HandleLose;

        GameEvents.OnEnemyDestroyed -= HandleEnemyDestroyed;
    }

    void HandleLose()
    {
        if (CurrentState != GameState.Playing)
        {
            return;
        }

        CurrentState = GameState.Lost;

        gameOverText.SetActive(true);

        Debug.Log("GAME OVER");
    }

    void HandleEnemyDestroyed()
    {
        if (CurrentState != GameState.Playing)
        {
            return;
        }

        defeatedEnemies++;

        if (defeatedEnemies >= enemiesToDefeat)
        {
            CurrentState = GameState.Won;

            winText.SetActive(true);

            Debug.Log("YOU WIN");
        }
    }
}