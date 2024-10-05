using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
	[SerializeField] private EnemyArmy _enemyArmy;
	[SerializeField] private TextMeshProUGUI _scoreText;

	private void OnEnable()
	{
		_enemyArmy.EnemyDied += OnShowDisplay;
	}

	private void OnDisable()
	{
		_enemyArmy.EnemyDied -= OnShowDisplay;
	}

	private void OnShowDisplay(int score)
	{
		_scoreText.text = score.ToString();
	}
}
