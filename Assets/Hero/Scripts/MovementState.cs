using System;
using UnityEngine;

/// <summary>
/// Состояние движения героя (когда герой находится на земле)
/// </summary>
public class MovementState : IState
{
    public event Action JumpRequested;
    public event Action OnAirRequested;

    private HeroContext _context;

    private Vector2InputField _movementInputField;

    public MovementState(HeroContext context)
    {
        _context = context;
        _movementInputField = _context.Input.MoveInput;
    }

    public void Enter()
    {
        _context.Input.JumpInput.Started += Jump_Started;
        _context.Animator.PlayMovement();
    }

    public void Tick()
    {
        Debug.Log($"MoveInput: {_movementInputField.CurrentValue}");

        var moveVector = _movementInputField.CurrentValue;
        moveVector.y = 0f;

        _context.Rigidbody.velocity = _context.MoveSettings.MoveSpeed * moveVector;

        if (!Mathf.Approximately(moveVector.x, 0f))
        {
            if (moveVector.x > 0f)
            {
                _context.ModelHolder.SetRotation(RotationType.Right);
            }
            else
            {
                _context.ModelHolder.SetRotation(RotationType.Left);
            }
        }

        _context.Animator.SetMovementVelocity(Mathf.Abs(moveVector.x));

        if (!_context.GroundChecker.CheckIsGrounded(out var hitInfo))
        {
            OnAirRequested?.Invoke();
        }
    }

    public void Exit()
    {
        _context.Input.JumpInput.Started -= Jump_Started;
    }

    private void Jump_Started()
    {
        JumpRequested?.Invoke();
    }
}