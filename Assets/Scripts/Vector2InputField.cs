using UnityEngine;

public class Vector2InputField : InputField<Vector2>
{
    protected override bool _isDefaultValue => CurrentValue == Vector2.zero;
}