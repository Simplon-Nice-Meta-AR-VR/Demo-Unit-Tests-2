using NaughtyAttributes;
using UnityEngine;
using TNRD;

/// <summary>
/// Handles the player's jump.
/// </summary>
public class PlayerJump : MonoBehaviour, IJump
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField, Label("Grounded")] private SerializableInterface<IGrounded> _groundedMechanicSerialized;

    [Header("Parameters")]
    [SerializeField] private float _jumpForce = 10f;

    private IGrounded _groundedMechanic => _groundedMechanicSerialized.Value;

    /// <summary>
    /// Applies a force upwards to the player.
    /// </summary>
    public void Jump()
    {
        if (_groundedMechanic.IsGrounded)
        {
            _rb2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
