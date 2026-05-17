using UnityEngine;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    public static GameState CurrentState = GameState.Playing;

    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject winText;
    [SerializeField] int enemiesToDefeat = 20;
    [SerializeField] TMP_Text objectiveText;

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
        UpdateObjectiveText();
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
        objectiveText.gameObject.SetActive(false);

        Debug.Log("GAME OVER");
    }


    void UpdateObjectiveText()
    {
        objectiveText.text =
            "Survive " + enemiesToDefeat +
            " enemies\nEnemies defeated: " +
            defeatedEnemies + "/" + enemiesToDefeat;
    }


    void HandleEnemyDestroyed()
    {
        if (CurrentState != GameState.Playing)
        {
            return;
        }

        defeatedEnemies++;
        UpdateObjectiveText();

        if (defeatedEnemies >= enemiesToDefeat)
        {
            CurrentState = GameState.Won;

            winText.SetActive(true);
            objectiveText.gameObject.SetActive(false);

            Debug.Log("YOU WIN");
        }
    }
}