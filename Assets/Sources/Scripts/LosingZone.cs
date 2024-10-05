using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LosingZone : MonoBehaviour
{
	private BoxCollider2D _boxCollider;

	public event Action Entered;

	public void Init()
	{
		_boxCollider = GetComponent<BoxCollider2D>();
		_boxCollider.isTrigger = true;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<EnemyShip>())
			Entered?.Invoke();
	}
}
