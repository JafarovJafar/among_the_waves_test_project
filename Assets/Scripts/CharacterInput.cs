public class CharacterInput
{
    public Vector2InputField MoveInput;
    public BoolInputField JumpInput;

    public CharacterInput()
    {
        MoveInput = new Vector2InputField();
        JumpInput = new BoolInputField();
    }
}