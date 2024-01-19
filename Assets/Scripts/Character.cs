using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected Collider _collider;
    [SerializeField] protected Animator _animator;

    protected StateMachine _stateMachine;

    private void Update() => _stateMachine.Tick();
}