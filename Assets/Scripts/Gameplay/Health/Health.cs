using System;
using UnityEngine;

public class Health
{
    public int MaxValue { get; private set; }
    public int Value { get; private set; }
    public event Action OnHealthZero;
    public event Action<float> OnHealthChanged;

    public Health(Parameters parameters)
    {
        SetParameters(parameters);
        Value = parameters.MaxValue;
    }

    public void SetParameters(Parameters parameters, HealthChangeMode healthChangeMode = HealthChangeMode.Restore)
    {
        parameters.Validate();
        int delta = parameters.MaxValue - MaxValue;
        MaxValue = parameters.MaxValue;
        switch (healthChangeMode)
        {
            case HealthChangeMode.DontChange:
                return;
            case HealthChangeMode.Restore:
                Value = MaxValue;
                break;
            case HealthChangeMode.Increase:
                Value += delta;
                break;
            default:
                throw new ArgumentException("healthChange", "Unreachable code reached");
        }
    }

    public void Change(int delta)
    {        
        Value = Mathf.Clamp(Value + delta, 0, MaxValue);
        OnHealthChanged?.Invoke(Value);
        if (Value == 0)
            OnHealthZero?.Invoke();
    }


    public enum HealthChangeMode
    {
        DontChange,
        Restore,
        Increase
    }

    [Serializable]
    public class Parameters : ICloneable
    {
        [Min(1)]
        [SerializeField] private int maxValue;
        public int MaxValue => maxValue;

        public Parameters(int maxValue)
        {
            this.maxValue = maxValue;
            Validate();
        }

        public object Clone()
        {
            return new Parameters(maxValue);
        }

        public void Validate()
        {
            if (maxValue <= 0)
                throw new ArgumentOutOfRangeException("parameters.maxValue", "Max health is less or eaquals zero.");
        }
    }
}
