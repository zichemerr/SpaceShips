using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementArmy : MonoBehaviour
{
	[Header("Horizontal movement")]
	[SerializeField] private Directions _direction;
	[SerializeField] private float _leftBorder;
	[SerializeField] private float _rightBorder;
	[SerializeField] private float _speed;

	[Header("Vertical movement")] [Space(3)]
	[SerializeField] private float _moveDelayY;
	[SerializeField] private float _addPositionY;

	private Rigidbody2D _rigidbody;
	private Movement _movement;
	private bool _isActive = true;
	private Vector2 CurrentDirection()
	{
		if (_direction == Directions.RightDirection)
			return Vector2.right;

		return Vector2.left;
	}

	public void Init()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_movement = new Movement(_rigidbody, _speed);
		StartCoroutine(StartMove());
	}

	private void SetDirectionAndPosition(Directions direction, float border)
	{
		transform.position = new Vector2(border, transform.position.y);
		_direction = direction;
	}

	private IEnumerator StartMove()
	{
		yield return new WaitForSeconds(_moveDelayY);
		transform.position += new Vector3(0, _addPositionY);
		StartCoroutine(StartMove());
	}

	public void Move()
	{
		if (_isActive == false)
			return;

		_movement.Move(CurrentDirection());
	}

	public bool CheckBorders()
	{
		if (transform.position.x < _leftBorder || transform.position.x > _rightBorder)
			return false;

		return true;
	}

	public void ChangeDirectionAndPosition()
	{
		if (CurrentDirection() == Vector2.right)
			SetDirectionAndPosition(Directions.LeftDirection, _rightBorder);
		else
			SetDirectionAndPosition(Directions.RightDirection, _leftBorder);
	}

	public void StopMove()
	{
		_isActive = false;
	}
}
