public class BoolInputField : InputField<bool>
{
    protected override bool _isDefaultValue => CurrentValue == false;
}