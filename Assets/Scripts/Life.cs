using System;
using UnityEngine;

public class Life
{
    public float MaxValue { get; private set; }
    public float Value { get; private set; }
    public event Action OnLifeZero;
    public event Action<float> OnLifeChanged;

    public Life(Settings setting)
    {
        MaxValue = setting.maxValue;
        Value = setting.maxValue;
    }

    public void Change(float delta)
    {
        Value = Mathf.Clamp(Value + delta, 0f, MaxValue);
        OnLifeChanged?.Invoke(Value);
        if (Value == 0f)
            OnLifeZero?.Invoke();
    }

    [Serializable]
    public class Settings
    {
        public float maxValue;
    }
}
