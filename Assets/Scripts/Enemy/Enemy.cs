using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] int damageAmount = 10;

    Transform coreTarget;

    void Start()
    {
        coreTarget = GameObject.FindGameObjectWithTag("Core").transform;
    }

    void Update()
    {
        if (coreTarget == null) return;

        Vector3 direction = (coreTarget.position - transform.position).normalized;

        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(damageAmount);

            Destroy(gameObject);
        }
    }
}