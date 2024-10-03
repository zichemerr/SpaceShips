using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private Movement _movement;
    private int _damage;

    public event Action<Bullet> Disabled;

    public void Init(int damage)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _movement = new Movement(_rigidbody, _speed);
        _damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable damagable))
            damagable.TakeDamage(_damage);

        Disable();
    }

    public void Enable(Transform newTransform)
    {
        transform.SetPositionAndRotation(newTransform.position, newTransform.rotation);
        gameObject.SetActive(true);
        _movement.Move(transform.up);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
        Disabled?.Invoke(this);
    }
}
