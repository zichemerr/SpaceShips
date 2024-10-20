using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _damage;

    private IWeaponSounds _sounds;

    public void Init(IWeaponSounds weaponSounds)
    {
        _sounds = weaponSounds;
    }

    public void Shoot()
    {
        Bullet bullet = _bulletPool.GetBullet();
		bullet.Init(_damage);
        bullet.Enable(_shootPoint);
        _sounds.PlayShoot();
    }
}
