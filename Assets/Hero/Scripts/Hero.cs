using System;
using UnityEngine;

public class Hero : Character, IControllableCharacter, IDamageable
{
    // можно, например, выключать UI со смертью персонажа, но показывать окно конца игры только после того, как проиграется анимация
    public event Action BeforeDeath;
    public event Action AfterDeath;

    // todo если в игре предполагаются баффы и прочие подификаторы здоровья, то лучше сделать отдельный класс для упправления здоровьем.
    // но в тестовом задании это не предполагается, поэтому этого тут нет
    [SerializeField] private float _health;

    [SerializeField] private float _deathDuration;
    [SerializeField] private ParticleSystem _deathParticle;

    [SerializeField] private MoveSettings _moveSettings;

    [SerializeField] private HeroAnimatorHelper _animatorHelper;

    [SerializeField] private GroundChecker _groundChecker;

    public CharacterInput Input => _input;
    private CharacterInput _input;

    private HeroContext _context;
    private MovementState _movementState;
    private JumpState _jumpState;
    private OnAirState _onAirState;
    private DeathState _deathState;

    public void Init()
    {
        _input = new CharacterInput();

        _modelHolder.Init();
        _modelHolder.SetRotation(RotationType.Right);

        _animatorHelper.Init(_animator);

        _context = new HeroContext
            (
            _input,
            _modelHolder,
            _rigidbody,
            _animatorHelper,
            _collider,
            _deathDuration,
            _deathParticle,
            _moveSettings,
            _groundChecker
            );

        _movementState = new MovementState(_context);
        _movementState.JumpRequested += MovementState_JumpRequested;
        _movementState.OnAirRequested += MovementState_OnAirRequested;

        _jumpState = new JumpState(_context);
        _jumpState.Finished += JumpState_Finished;

        _onAirState = new OnAirState(_context);
        _onAirState.Finished += OnAirState_Finished;

        _deathState = new DeathState(_context);
        _deathState.Finished += DeathState_Finished;

        _stateMachine = new StateMachine();
        _stateMachine.ChangeState(_movementState);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health < 0f)
        {
            BeforeDeath?.Invoke();
            _stateMachine.ChangeState(_deathState);
        }
    }

    private void MovementState_JumpRequested()
    {
        _stateMachine.ChangeState(_jumpState);
    }

    private void MovementState_OnAirRequested()
    {
        _stateMachine.ChangeState(_onAirState);
    }

    private void JumpState_Finished()
    {
        _stateMachine.ChangeState(_onAirState);
    }

    private void OnAirState_Finished()
    {
        _stateMachine.ChangeState(_movementState);
    }

    private void DeathState_Finished()
    {
        AfterDeath?.Invoke();
    }
}