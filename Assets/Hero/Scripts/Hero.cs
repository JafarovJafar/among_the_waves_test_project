using UnityEngine;

public class Hero : Character, IControllableCharacter
{
    [SerializeField] private ParticleSystem _deathParticle;

    [SerializeField] private MoveSettings _moveSettings;

    public CharacterInput Input => _input;
    private CharacterInput _input;

    private HeroAnimatorHelper _animatorHelper;

    private HeroContext _context;
    private MovementState _movementState;
    private DeathState _deathState;

    public void Init()
    {
        _input = new CharacterInput();

        _animatorHelper = new HeroAnimatorHelper(_animator);

        _context = new HeroContext();
        _context.Input = _input;
        _context.Rigidbody = _rigidbody;
        _context.MovementCollider = _collider;
        _context.Animator = _animatorHelper;
        _context.DeathParticle = _deathParticle;
        _context.MoveSettings = _moveSettings;

        _movementState = new MovementState(_context);
        _deathState = new DeathState(_context);
        
        _stateMachine = new StateMachine();
        _stateMachine.ChangeState(_movementState);
    }
}