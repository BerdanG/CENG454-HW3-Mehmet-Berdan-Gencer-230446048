using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float lifetime = 3f;
    [SerializeField] int damageAmount = 10;

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

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy"))
        {
            return;
        }

        IDamageable damageable =
            other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(damageAmount);

            ProjectilePool.Instance.ReturnProjectile(gameObject);
        }
    }
}