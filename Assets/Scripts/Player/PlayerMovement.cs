using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Handles the player's movement.
/// </summary>
public class PlayerMovement : MonoBehaviour, IMove
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rb2d;

    [Header("Parameters")]
    [SerializeField] private float _moveSpeed = 10f;

    [Header("Event")]
    [SerializeField] private UnityEvent<float> _onMove;

    private float _direction;

    public void Initialize(Rigidbody2D rb2d)
    {
        _rb2d = rb2d;
    }

    /// <summary>
    /// Moves the player in a direction.
    /// </summary>
    /// <param name="direction">The direction to move the player in.</param>
    public void Move(float direction)
    {
        if (Math.Abs(direction) < 0.01f)
        {
            _direction = 0f;
            _rb2d.velocity = new Vector2(_direction, _rb2d.velocity.y);
        }
        else
        {
            _direction = direction;
        }

        _onMove?.Invoke(_direction);
    }

    private void FixedUpdate()
    {
        _rb2d.velocity = new Vector2(_direction * _moveSpeed, _rb2d.velocity.y);
    }
}
