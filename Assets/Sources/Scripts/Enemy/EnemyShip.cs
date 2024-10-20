using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShip : Ship
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Sounds _sounds;
    [SerializeField] private float _maxShootDelay;
    [SerializeField] private float _minShootDelay;

	public event Action<EnemyShip> Destroyed;

    public void Init()
    {
        Init(_sounds);
        _weapon.Init(_sounds);
        StartCoroutine(StartShoot());
    }

    private void OnEnable()
    {
        Died += OnDied;
	}

    private void OnDisable()
    {
        Died -= OnDied;
	}

    private void OnDied()
    {
        Destroyed?.Invoke(this);
    }

	private IEnumerator StartShoot()
    {
        float randomDelay = Random.Range(_minShootDelay, _maxShootDelay);
		yield return new WaitForSeconds(randomDelay);
        _weapon.Shoot();
        StartCoroutine(StartShoot());
    }
}
