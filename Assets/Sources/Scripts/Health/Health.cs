using System;

public class Health
{
    private int _value;

    public event Action<int> HealthChanged;

    public Health(int health)
    {
        _value = health;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentException("Damage must be greater zero");

        _value -= damage;
        HealthChanged?.Invoke(_value);
    }
}
