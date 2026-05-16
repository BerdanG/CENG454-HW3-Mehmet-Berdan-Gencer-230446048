using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float lifetime = 3f;

    float timer;

    void OnEnable()
    {
        timer = lifetime;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            ProjectilePool.Instance.ReturnProjectile(gameObject);
        }
    }
}