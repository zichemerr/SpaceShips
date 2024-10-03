using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _damage;

    public void Init()
    {
        _bulletPool.Init();
    }

    public void Shoot()
    {
        Bullet bullet = _bulletPool.GetBullet();
        bullet.Init(_damage);
        bullet.Enable(_shootPoint);
    }
}
