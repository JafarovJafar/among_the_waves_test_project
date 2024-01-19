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
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");

        _controllable.Input.MoveInput.SetValue(moveVector);
    }
}