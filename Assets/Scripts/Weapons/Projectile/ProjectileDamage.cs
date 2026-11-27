using UnityEngine;
using UnityEngine.Pool;

namespace CosmoBlast.Weapons.Projectile
{
    public sealed class ProjectileDamage : MonoBehaviour
    {
        [SerializeField] private int _damage;
        private ObjectPool<GameObject> _objectPool;

        public void Initialize(ObjectPool<GameObject> pool)
        {
            _objectPool = pool;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Health>(out var health))
            {
                health.TakeDamage(_damage);
                _objectPool.Release(gameObject);
            }
        }

        private void Update()
        {
            Vector3 viewport = Camera.main.WorldToViewportPoint(transform.position);

            if (viewport.z < 0f ||
                viewport.x < 0f || viewport.x > 1f ||
                viewport.y < 0f || viewport.y > 1f)
            {
                _objectPool.Release(gameObject);
            }
        }
    }
}
