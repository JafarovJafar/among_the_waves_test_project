using System;
using UnityEngine;

/// <summary>
/// Состояние смерти героя
/// </summary>
/// <remarks>
/// Данное состояние не подвязано на анимацию, потому что смерть может быть не анимацией, а ragdoll
/// В будущем, если понадобится вместо анимаций использовать ragdoll - можно будет спокойно это внедрить
/// </remarks>
public class DeathState : IState
{
    public event Action Finished;

    private HeroContext _context;

    private float _remainingTime;

    private bool _isGrounded;

    public DeathState(HeroContext context)
    {
        _context = context;
    }

    public void Enter()
    {
        // присваиваем длительность смерти
        _remainingTime = _context.DeathDuration;

        // выключаем коллайдер
        _context.MovementCollider.enabled = false;

        // включаем партикл смерти (геймобджект)
        //_context.DeathParticle.gameObject.SetActive(true);
        // воспроизводим партикл смерти
        //_context.DeathParticle.Play();

        _context.Animator.PlayDeath();
    }

    public void Tick()
    {
        // проверяем касание с землей
        if (!_isGrounded && _context.GroundChecker.CheckIsGrounded(out var hitInfo))
        {
            _isGrounded = true;
        }

        // если мы не на земле, то
        if (!_isGrounded)
        {
            // двигаем игрока вниз (гравитация)
            _context.Rigidbody.velocity = Physics.gravity;
        }
        else
        {
            // если мы на земле, то выключаем физику
            _context.Rigidbody.isKinematic = true;
        }

        // отсчитываем время, чтобы сообщить, что состояние смерти закончилось
        _remainingTime -= Time.deltaTime;

        if (_remainingTime > 0) return;
        Finished?.Invoke();
    }

    public void Exit()
    {
        // останавливаем партикл смерти
        //_context.DeathParticle.Stop();
        //_context.DeathParticle.gameObject.SetActive(false);
    }
}