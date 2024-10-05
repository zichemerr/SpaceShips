using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _poolSize;

    private Queue<Bullet> _pool;

    private void Awake()
    {
        _pool = new Queue<Bullet>();

        for (int i = 0; i < _poolSize; i++)
            _pool.Enqueue(BulletSpawn());
    }

    private void OnDisable()
    {
        foreach (var pool in _pool)
            pool.Disabled -= OnDisabled;
    }

    private Bullet BulletSpawn()
    {
        Bullet bullet = Instantiate(_bulletPrefab);

        bullet.Disabled += OnDisabled;

        return bullet;
    }

    private void OnDisabled(Bullet bullet)
    {
        _pool.Enqueue(bullet);
    }

    public Bullet GetBullet()
    {
        if (_pool.Count > 0)
            return _pool.Dequeue();

        return BulletSpawn();
    }
}
