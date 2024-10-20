using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementArmy))]
public class EnemyArmy : MonoBehaviour
{
    [SerializeField] private List<EnemyShip> _enemies;

    private MovementArmy _movementArmy;
    private int _score;

    public event Action AllEnemyDied;
    public event Action<int> EnemyDied;

	private void Awake()
	{
		_movementArmy = GetComponent<MovementArmy>();
	}

	public void Init()
    {
        foreach (var enemies in _enemies)
            enemies.Init();

        _movementArmy.Init();
	}

    private void OnEnable()
    {
        foreach (var enemies in _enemies)
            enemies.Destroyed += OnEnemyDied;
    }

    private void OnDisable()
    {
        foreach (var enemies in _enemies)
            enemies.Destroyed -= OnEnemyDied;
    }

	private void Update()
	{
        if (_movementArmy.CheckBorders() == false)
            _movementArmy.ChangeDirectionAndPosition();
	}

	private void FixedUpdate()
	{
		_movementArmy.Move();
	}

	private void OnEnemyDied(EnemyShip enemyShip)
    {
        _enemies.Remove(enemyShip);
        Destroy(enemyShip.gameObject);
        _score++;
		EnemyDied?.Invoke(_score);

		if (_enemies.Count <= 0)
        {
            _movementArmy.StopMove();
			AllEnemyDied?.Invoke();
        }
    }
}
