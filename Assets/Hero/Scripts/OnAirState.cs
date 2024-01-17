/// <summary>
/// Состояние полета героя
/// </summary>
/// <remarks>
/// Под полетом понимается как прыжок, так и падение с высоты
/// </remarks>
public class OnAirState : IState
{
    private HeroContext _context;

    public OnAirState(HeroContext context)
    {
        _context = context;
    }

    public void Enter()
    {

    }

    public void Tick()
    {

    }

    public void Exit()
    {

    }
}