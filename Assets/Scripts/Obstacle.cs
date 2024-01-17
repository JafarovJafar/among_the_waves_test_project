using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _damage = 1000;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.TryGetComponent<IDamageable>(out var damageable)) return;

        damageable.TakeDamage(_damage);
    }
}