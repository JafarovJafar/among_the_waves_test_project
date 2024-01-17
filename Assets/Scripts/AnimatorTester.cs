using UnityEngine;
using EasyButtons;

public class AnimatorTester : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private string _animationName;
    [SerializeField] private float _crossFadeTransitionDuration;

    [SerializeField] private string _parameterName;
    [SerializeField] private bool _boolValue;
    [SerializeField] private float _floatValue;
    [SerializeField] private int _intValue;

    [Button]
    private void PlayAnimation()
    {
        _animator.Play(_animationName);
    }

    [Button]
    private void CrossFadeAnimation()
    {
        _animator.CrossFade(_animationName, _crossFadeTransitionDuration);
    }

    [Button]
    private void SetBoolValue()
    {
        _animator.SetBool(_parameterName, _boolValue);
    }

    [Button]
    private void SetFloatValue()
    {
        _animator.SetFloat(_parameterName, _floatValue);
    }

    [Button]
    private void SetIntValue()
    {
        _animator.SetInteger(_parameterName, _intValue);
    }
}