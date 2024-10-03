using System;
using System.Collections;
using UnityEngine;

public class EnemyShip : Ship
{
    [SerializeField] private Weapon _weapon;

    public event Action<EnemyShip> Destroyed;

    public override void Init()
    {
        base.Init();
        _weapon.Init();
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
        yield return new WaitForSeconds(1f);
        _weapon.Shoot();
        StartCoroutine(StartShoot());
    }
}
