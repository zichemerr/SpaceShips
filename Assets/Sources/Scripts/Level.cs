using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private PlayerShip _playerShip;
    [SerializeField] private EnemyArmy _enemyArmy;

    private void Start()
    {
        _playerShip.Init();
        _enemyArmy.Init();
    }

    private void OnEnable()
    {
        _playerShip.Died += Finish;
        _enemyArmy.AllEnemyDied += Finish;
    }

    private void OnDisable()
    {
        _playerShip.Died -= Finish;
        _enemyArmy.AllEnemyDied -= Finish;
    }

    private void Finish()
    {
        Debug.Log("FinishGame");
    }
}
