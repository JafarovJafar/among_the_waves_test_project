using UnityEngine;

public class SceneEntryPoint : MonoBehaviour
{
    [SerializeField] private Hero _hero;

    [SerializeField] private BaseInputController _controller;

    private void Start()
    {
        _hero.Init();
        _controller.SetTarget(_hero);
    }
}