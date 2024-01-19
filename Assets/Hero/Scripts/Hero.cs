using UnityEngine;

public class Hero : Character, IControllableCharacter
{
    [SerializeField] private float _deathDuration;
    [SerializeField] private ParticleSystem _deathParticle;

    [SerializeField] private MoveSettings _moveSettings;

    [SerializeField] private HeroAnimatorHelper _animatorHelper;

    public CharacterInput Input => _input;
    private CharacterInput _input;

    private HeroContext _context;
    private MovementState _movementState;
    private DeathState _deathState;

    public void Init()
    {
        _input = new CharacterInput();

        _animatorHelper.Init(_animator);

        _context = new HeroContext
            (
            _input,
            _modelTransform,
            _rigidbody,
            _animatorHelper,
            _collider,
            _deathDuration,
            _deathParticle,
            _moveSettings
            );

        _movementState = new MovementState(_context);
        _deathState = new DeathState(_context);

        _stateMachine = new StateMachine();
        _stateMachine.ChangeState(_movementState);
    }
}