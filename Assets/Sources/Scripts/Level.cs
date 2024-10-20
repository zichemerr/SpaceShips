using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private PlayerShip _playerShip;
    [SerializeField] private EnemyArmy _enemyArmy;
    [SerializeField] private LosingZone _losingZone;

    private void Start()
    {
        _playerShip.Init();
        _enemyArmy.Init();
		_losingZone.Init();
	}

    private void OnEnable()
    {
        _playerShip.Died += Finish;
        _enemyArmy.AllEnemyDied += Finish;
        _losingZone.Entered += Finish;
	}

    private void OnDisable()
    {
        _playerShip.Died -= Finish;
        _enemyArmy.AllEnemyDied -= Finish;
        _losingZone.Entered += Finish;
	}

    private void Finish()
    {
        SceneManager.LoadScene(0);
    }
}
