using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    void Update()
    {
        if (GameStateManager.CurrentState == GameState.Lost
            || GameStateManager.CurrentState == GameState.Won)
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0f, v);

        transform.Translate(
            direction * moveSpeed * Time.deltaTime,
            Space.World
        );
    }
}