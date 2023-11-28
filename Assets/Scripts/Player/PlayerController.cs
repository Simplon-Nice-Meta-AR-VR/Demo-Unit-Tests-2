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


    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw(_horizontalAxis);
        _movementMechanic.Move(horizontalInput);

        if (Input.GetButtonDown(_jumpAxis))
        {
            _jumpMechanic.Jump();
        }
    }
}
