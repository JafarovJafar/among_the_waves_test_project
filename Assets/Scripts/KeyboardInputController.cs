using UnityEngine;

public class KeyboardInputController : BaseInputController
{
    public override void Update()
    {
        SetMoveValue();
        SetJumpValue();
    }

    private void SetJumpValue()
    {
        _controllable.Input.JumpInput.SetValue(Input.GetKeyDown(KeyCode.Space));
    }

    private void SetMoveValue()
    {
        Vector2 moveVector = new Vector2();
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");

        _controllable.Input.MoveInput.SetValue(moveVector);
    }
}