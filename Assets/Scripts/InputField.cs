using System;

/// <summary>
/// Базовый класс для всех полей ввода (управления)
/// </summary>
/// <typeparam name="T">Тип значений у поля (bool, float, Vector3 и т.д.)</typeparam>
public abstract class InputField<T>
{
    /// <summary>
    /// Начато ли изменение
    /// </summary>
    /// /// <remarks>
    /// Вызывается, когда в инпут начали передаваться значения
    /// </remarks>
    public event Action Started;
    /// <summary>
    /// Отменено ли изменение
    /// </summary>
    /// <remarks>
    /// Вызывается, когда в инпут перестали передаваться значения
    /// </remarks>
    public event Action Canceled;

    /// <summary>
    /// Изменено ли значение
    /// </summary>
    public event Action<T> Changed;

    public T CurrentValue;

    private bool _wasPressedOnLastFrame;
    private bool _isPressedOnThisFrame;

    /// <summary>
    /// Это свойство переопределяет каждый наследник
    /// Данное свойство должно быть true, если поле имеет default значение
    /// </summary>
    protected abstract bool _isDefaultValue { get; }

    public void SetValue(T value)
    {
        CurrentValue = value;

        // если текущее значение не равно дефолтному, то значит, что инпут нажат в текущем кадре
        _isPressedOnThisFrame = !_isDefaultValue;

        // если инпут не был нажат в предыдущем кадре, но нажат в этом, то вызываем Started
        if (!_wasPressedOnLastFrame && _isPressedOnThisFrame)
        {
            Started?.Invoke();
        }
        // если инпут был нажат в предыдущем кадре, но не был нажат в этом, то вызываем Canceled
        else if (_wasPressedOnLastFrame && !_isPressedOnThisFrame)
        {
            Canceled?.Invoke();
        }
        // иначе сообщаем о том, что инпут поменялся
        else
        {
            Changed?.Invoke(value);
        }

        _wasPressedOnLastFrame = _isPressedOnThisFrame;
    }
}