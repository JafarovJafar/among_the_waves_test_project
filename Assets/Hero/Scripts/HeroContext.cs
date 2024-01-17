using UnityEngine;

/// <summary>
/// Контекст, передаваемый между состояниями героя
/// </summary>
/// <remarks>
/// Тут хранятся общие для всех состояний компоненты и значения. Например, collider, rigidbody
/// </remarks>
public class HeroContext
{
    public Rigidbody Rigidbody;
    public Animator Animator;
    public Collider MovementCollider;

    public float DeathDuration;
    public ParticleSystem DeathParticle;
}