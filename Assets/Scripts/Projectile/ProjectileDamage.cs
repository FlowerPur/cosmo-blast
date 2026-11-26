using UnityEngine;

public sealed class ProjectileDamage : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out var health))
        {
            health.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
