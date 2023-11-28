using UnityEngine;
using NaughtyAttributes;
using TNRD;

/// <summary>
/// This class is responsible for handling player input and passing it to the mechanics.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Input Settings")]
    [SerializeField, InputAxis] private string _horizontalAxis = "Horizontal";
    [SerializeField, InputAxis] private string _jumpAxis = "Jump";

    [Header("Mechanics")]
    [SerializeField, Label("Movement")] private SerializableInterface<IMove> _movementMechanicSerialized;
    [SerializeField, Label("Jump")] private SerializableInterface<IJump> _jumpMechanicSerialized;

    private IMove _movementMechanic => _movementMechanicSerialized.Value;
    private IJump _jumpMechanic => _jumpMechanicSerialized.Value;

    public void Initialize(IMove movementMechanic, IJump jumpMechanic)
    {
        _movementMechanicSerialized = new SerializableInterface<IMove>(movementMechanic);
        _jumpMechanicSerialized = new SerializableInterface<IJump>(jumpMechanic);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw(_horizontalAxis);
        Move(horizontalInput);

        if (Input.GetButtonDown(_jumpAxis))
        {
            Jump();
        }
    }

    public void Move(float direction)
    {
        _movementMechanic.Move(direction);
    }

    public void Jump()
    {
        _jumpMechanic.Jump();
    }
}
