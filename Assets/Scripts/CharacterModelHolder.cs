using System.Collections.Generic;
using UnityEngine;

public enum RotationType
{
    Left,
    Right,
    Forward,
}

public class CharacterModelHolder : MonoBehaviour
{
    [SerializeField] private bool _isSmooth;
    [SerializeField] private float _maxRotDelta;

    private Transform _transform;

    private Dictionary<RotationType, Quaternion> _rotations;

    private Quaternion _currentRot;
    private Quaternion _goalRot;

    public void Init()
    {
        _transform = transform;

        _rotations = new Dictionary<RotationType, Quaternion>();
        _rotations.Add(RotationType.Left, Quaternion.LookRotation(Vector3.left, Vector3.up));
        _rotations.Add(RotationType.Right, Quaternion.LookRotation(Vector3.right, Vector3.up));
        _rotations.Add(RotationType.Forward, Quaternion.LookRotation(Vector3.forward, Vector3.up));
    }

    public void SetRotation(RotationType type)
    {
        _goalRot = _rotations[type];
    }

    private void Update()
    {
        if (_currentRot == _goalRot) return;

        if (_isSmooth)
        {
            _currentRot = Quaternion.RotateTowards(_currentRot, _goalRot, _maxRotDelta * Time.deltaTime);
        }
        else
        {
            _currentRot = _goalRot;
        }

        _transform.rotation = _currentRot;
    }
}