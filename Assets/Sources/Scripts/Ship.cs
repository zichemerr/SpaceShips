using UnityEngine;
using System;

public abstract class Ship : MonoBehaviour, IDamagable
{
    [SerializeField] private int _healthValue;

    private Health _health;
    private IUnitSounds _unitSounds;

    public event Action Died;

    public void Init(Sounds sounds)
    {
        _health = new Health(_healthValue);
        _health.HealthChanged += OnHealthChanged;
        _unitSounds = sounds;
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
        _unitSounds.PlayHit();
    }
}
