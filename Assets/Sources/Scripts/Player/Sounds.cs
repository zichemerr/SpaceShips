using UnityEngine;

public class Sounds : MonoBehaviour, IUnitSounds, IWeaponSounds
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _shoot;
    [SerializeField] private AudioClip _hit;

    public void PlayShoot()
    {
        _audioSource.PlayOneShot(_shoot);
    }

    public void PlayHit()
    {
        _audioSource.PlayOneShot(_hit);
    }
}

public interface IUnitSounds
{
    void PlayHit();
}

public interface IWeaponSounds
{
    void PlayShoot();
}