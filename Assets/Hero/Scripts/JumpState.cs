using System;

/// <summary>
/// Состояние прыжка
/// </summary>
/// <remarks>
/// Это состояние просто переходное между движением и полетом.
/// В данном состоянии мы можем воспроизвести партикл прыжка, звук и т.д.
/// </remarks>
public class JumpState : IState
{
    public event Action Finished;

    private HeroContext _context;

    public JumpState(HeroContext context)
    {
        _context = context;
    }

    public void Enter()
    {
        var velocity = _context.Rigidbody.velocity;
        velocity.y = _context.MoveSettings.JumpStrength;
        _context.Rigidbody.velocity = velocity;
        Finished?.Invoke();
    }

    public void Tick()
    {

    }

    public void Exit()
    {

    }
}