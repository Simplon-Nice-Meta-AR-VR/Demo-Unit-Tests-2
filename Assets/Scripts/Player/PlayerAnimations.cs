using NaughtyAttributes;
using UnityEngine;

/// <summary>
/// Handles the player's animations.
/// </summary>
public class PlayerAnimations : MonoBehaviour, IMoveAnimation, IJumpAnimation
{
    [Header("Components")]
    [SerializeField] private Animator _animator;

    [Header("Parameters")]
    [SerializeField, AnimatorParam(nameof(_animator))] private string _speedParam = "Speed";
    [SerializeField, AnimatorParam(nameof(_animator))] private string _jumpParam = "Jump";

    /// <summary>
    /// Sets whether the character should have a jumping animation or not.
    /// </summary>
    /// <param name="isJumping"></param>
    public void JumpAnimation(bool isJumping)
    {
        _animator.SetBool(_jumpParam, isJumping);
    }

    /// <summary>
    /// Sets the speed of the character's movement animation.
    /// </summary>
    /// <param name="speed">unsigned float representing the speed of the character's movement.</param>
    public void MoveAnimation(float speed)
    {
        _animator.SetFloat(_speedParam, speed);
    }
}

