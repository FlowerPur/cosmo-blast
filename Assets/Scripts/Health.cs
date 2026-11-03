using System;
using UnityEngine;

public sealed class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public event Action Died;

    private void Awake() => _currentHealth = _maxHealth;

    public void TakeDamage(int damage)
    {
        if (damage <= 0) return;

        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Died.Invoke();
        Destroy(gameObject);
    }
}
