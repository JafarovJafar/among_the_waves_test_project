using UnityEngine;

public abstract class BaseInputController : MonoBehaviour
{
    protected IControllableCharacter _controllable;

    public void SetTarget(IControllableCharacter controllable)
    {
        _controllable = controllable;
    }

    public abstract void Update();
}