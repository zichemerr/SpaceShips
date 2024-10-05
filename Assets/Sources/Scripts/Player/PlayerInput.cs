using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    public event Action Shooted;

    public Vector2 Direction
    {
        get
        {
            Vector2 direction = new(Input.GetAxis(Horizontal), 0);
            return direction;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shooted?.Invoke();
    }
}