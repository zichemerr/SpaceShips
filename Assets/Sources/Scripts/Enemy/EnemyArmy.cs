using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmy : MonoBehaviour
{
    [SerializeField] private List<EnemyShip> _enemies;

    public event Action AllEnemyDied;

    public void Init()
    {
        foreach (var enemies in _enemies)
            enemies.Init();
    }

    private void OnEnable()
    {
        foreach (var enemies in _enemies)
            enemies.Destroyed += OnDied;
    }

    private void OnDisable()
    {
        foreach (var enemies in _enemies)
            enemies.Destroyed -= OnDied;
    }

    private void OnDied(EnemyShip enemyShip)
    {
        _enemies.Remove(enemyShip);
        Destroy(enemyShip.gameObject);

        if (_enemies.Count <= 0)
            AllEnemyDied?.Invoke();
    }
}
