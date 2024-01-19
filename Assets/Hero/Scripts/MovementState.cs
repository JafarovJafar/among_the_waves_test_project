using UnityEngine;

/// <summary>
/// Состояние движения героя (когда герой находится на земле)
/// </summary>
public class MovementState : IState
{
    private HeroContext _context;

    private Vector2InputField _movementInputField;

    public MovementState(HeroContext context)
    {
        _context = context;
        _movementInputField = _context.Input.MoveInput;
    }

    public void Enter()
    {

    }

    public void Tick()
    {
        Debug.Log($"MoveInput: {_movementInputField.CurrentValue}");

        var moveVector = _movementInputField.CurrentValue;
        moveVector.y = 0f;

        _context.Rigidbody.velocity = _context.MoveSettings.MoveSpeed * moveVector;

        if (!Mathf.Approximately(moveVector.x, 0f))
        {
            var model = _context.ModelTransform;
            model.LookAt(model.position + (Vector3)moveVector, Vector3.up);
        }

        _context.Animator.SetMovementVelocity(Mathf.Abs(moveVector.x));
    }

    public void Exit()
    {

    }
}