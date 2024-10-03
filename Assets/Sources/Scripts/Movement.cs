using UnityEngine;

public class Movement
{
    private readonly Rigidbody2D _rigidbody;
    private readonly float _speed;

    public Movement(Rigidbody2D rigidbody, float speed)
    {
        _rigidbody = rigidbody;
        _speed = speed;
    }

    public void Move(Vector2 direction)
    {
        _rigidbody.velocity = direction * _speed;
    }
}