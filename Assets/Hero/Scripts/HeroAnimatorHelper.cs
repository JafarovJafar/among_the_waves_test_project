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
public class HeroAnimatorHelper
{
    public HeroAnimatorHelper(Animator animator)
    {
        _animator = animator;
    }

    private Animator _animator;

    private string _moveVelocityParameterName = "move_speed";
    private string _vertVelocityParameterName = "y_direction";

    public void PlayDeath() { }

    public void PlayMovement() { }

    public void SetMovementVelocity(float velocity)
    {
        _animator.SetFloat(_moveVelocityParameterName, velocity);
    }

    public void PlayInAir()
    {

    }

    public void SetVerticalVelocity(float velocity)
    {
        _animator.SetFloat(_vertVelocityParameterName, velocity);
    }
}