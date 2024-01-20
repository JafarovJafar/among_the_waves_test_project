using System;
using UnityEngine;

/// <summary>
/// Состояние полета героя
/// </summary>
/// <remarks>
/// Под полетом понимается как прыжок, так и падение с высоты
/// </remarks>
public class OnAirState : IState
{
    /// <summary>
    /// Событие при окончании состояния (т.е. приземлении героя на землю)
    /// </summary>
    public event Action Finished;

    private HeroContext _context;

    public OnAirState(HeroContext context)
    {
        _context = context;
    }

    public void Enter()
    {
        _context.Animator.PlayInAir();
    }

    public void Tick()
    {
        // устанавливаем значение для дерева смешиваний в аниматоре
        _context.Animator.SetVerticalVelocity(_context.Rigidbody.velocity.y);

        // двигаем игрока вниз (гравитация)
        _context.Rigidbody.velocity += Time.deltaTime * Physics.gravity;

        // проверяем касание с землей только в том случае, если герой летит вниз
        if (_context.Rigidbody.velocity.y < 0f && _context.GroundChecker.CheckIsGrounded(out var hitInfo))
        {
            // если мы на земле, то надо выйти из состояния
            Finished?.Invoke();
        }
    }

    public void Exit()
    {
        var velocity = _context.Rigidbody.velocity;
        velocity.y = 0f;
        _context.Rigidbody.velocity = velocity;
        _context.Animator.SetVerticalVelocity(0f);
    }
}