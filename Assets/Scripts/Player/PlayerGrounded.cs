using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Handles whether the player is touching the ground or not.
/// </summary>
public class PlayerGrounded : MonoBehaviour, IGrounded
{
    [SerializeField, Tag] private string _groundTag = "Ground";

    /// <summary>
    /// Whether the player is touching the ground or not.
    /// </summary>
    public bool IsGrounded { get; private set; }

    [SerializeField] private UnityEvent<bool> _onUnGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_groundTag))
        {
            IsGrounded = true;
            _onUnGrounded?.Invoke(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(_groundTag))
        {
            IsGrounded = false;
            _onUnGrounded?.Invoke(true);
        }
    }
}
