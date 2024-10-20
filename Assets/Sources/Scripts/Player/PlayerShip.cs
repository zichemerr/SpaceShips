using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerShip : Ship
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Sounds _sounds;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private Movement _movement;

    public void Init()
    {
        Init(_sounds);
        _weapon.Init(_sounds);
        _rigidbody = GetComponent<Rigidbody2D>();
        _movement = new Movement(_rigidbody, _speed);
	}

	private void OnEnable()
    {
        _playerInput.Shooted += OnShooted;;
	}

    private void OnDisable()
    {
        _playerInput.Shooted -= OnShooted;
	}

    private void FixedUpdate()
    {
        _movement.Move(_playerInput.Direction);
    }

    private void OnShooted()
    {
        _weapon.Shoot();
    }
}
