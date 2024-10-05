using UnityEngine;
using System;

public abstract class Ship : MonoBehaviour, IDamagable
{
    [SerializeField] private int _healthValue;

    private Health _health;

    public event Action Died;

    public virtual void Init()
    {
        _health = new Health(_healthValue);
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        if (health <= 0)
            Died?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }
}
