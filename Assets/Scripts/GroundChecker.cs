using UnityEngine;

/// <summary>
/// Класс для проверки коллизии с землей
/// </summary>
/// <remarks>
/// Данный класс проверяет столкновение с землей при помощи сферы, но, вероятно, стоит сделать не сферу, а куб
/// </remarks>
public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Vector3 _posOffset;
    [SerializeField] private float _sphereRadius;
    [SerializeField] private float _checkDistance;
    [SerializeField] private float _skinWidth;
    [SerializeField] private Color _gizmosStartColor;
    [SerializeField] private Color _gizmosEndColor;
    [SerializeField] private Color _gizmosFinalColor;
    [SerializeField] private LayerMask _layerMask;

    private Vector3 _originPos => transform.position + _posOffset;
    private float _checkDistanceWithSkin => _checkDistance - _sphereRadius + _skinWidth;

    public bool CheckIsGrounded(out RaycastHit hitInfo)
    {
        return Physics.SphereCast(_originPos, _sphereRadius, Vector3.down, out hitInfo, _checkDistanceWithSkin, _layerMask.value);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmosStartColor;
        Gizmos.DrawWireSphere(transform.position + _posOffset, _sphereRadius);
        Gizmos.color = _gizmosEndColor;
        Gizmos.DrawWireSphere(transform.position + _posOffset + Vector3.down * (_checkDistanceWithSkin - _skinWidth), _sphereRadius);
        Gizmos.color = _gizmosFinalColor;
        Gizmos.DrawWireSphere(transform.position + _posOffset + Vector3.down * (_checkDistanceWithSkin), _sphereRadius);
    }
}