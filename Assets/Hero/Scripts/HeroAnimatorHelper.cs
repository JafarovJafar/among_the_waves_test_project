using UnityEngine;

/// <summary>
/// Вспомогательный класс для управления анимациями героя
/// </summary>
/// <remarks>
/// Данный класс является прослойкой между Animator и поведенческими состояниями
/// Правильным решением является реализовать эту прослойку, потому что названия параметров и способы смены анимаций могут меняться
/// Если не сделать эту прослойку, то на каждое изменение придется бегать по состояниям и делать там правки
/// Еще эту прослойку можно использовать для прослушивания событий анимаций (Animator Events)
/// </remarks>
public class HeroAnimatorHelper : MonoBehaviour
{
    [SerializeField] private float _moveVelocityChangeDelta = 0.25f;
    [SerializeField] private float _vertVelocityChangeDelta = 0.25f;

    private Animator _animator;

    private string _moveVelocityParameterName = "move_speed";
    private string _vertVelocityParameterName = "y_direction";

    private float _currentMoveVelocity;
    private float _goalMoveVelocity;

    private float _currentVertVelocity;
    private float _goalVertVelocity;

    public void Init(Animator animator)
    {
        _animator = animator;
    }

    public void PlayDeath() { }

    public void PlayMovement() { }

    public void SetMovementVelocity(float velocity)
    {
        //_animator.SetFloat(_moveVelocityParameterName, velocity);
        _goalMoveVelocity = velocity;
    }

    public void PlayInAir()
    {

    }

    public void SetVerticalVelocity(float velocity)
    {
        //_animator.SetFloat(_vertVelocityParameterName, velocity);
        _goalVertVelocity = velocity;
    }

    private void Update()
    {
        UpdateMoveVelocity();
        UpdateVertVelocity();
    }

    private void UpdateMoveVelocity()
    {
        _currentMoveVelocity = Mathf.MoveTowards(_currentMoveVelocity, _goalMoveVelocity, _moveVelocityChangeDelta * Time.deltaTime);
        _animator.SetFloat(_moveVelocityParameterName, _currentMoveVelocity);
    }

    private void UpdateVertVelocity()
    {
        _currentVertVelocity = Mathf.MoveTowards(_currentVertVelocity, _goalVertVelocity, _vertVelocityChangeDelta * Time.deltaTime);
        _animator.SetFloat(_vertVelocityParameterName, _currentVertVelocity);
    }
}