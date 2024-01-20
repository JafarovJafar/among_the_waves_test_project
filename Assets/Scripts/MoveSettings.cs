using UnityEngine;

[CreateAssetMenu(menuName = "MoveSettings")]
public class MoveSettings : ScriptableObject
{
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float OnAirAcceleration { get; private set; }
    [field: SerializeField] public float JumpStrength { get; private set; }
}