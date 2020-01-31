using System;
using UnityEngine;
using Zenject;

public class Damager
{
    public Parameters parameters;

    [Inject]
    public void Construct(Parameters parameters)
    {
        SetParameters(parameters);
    }

    public void SetParameters(Parameters parameters)
    {
        parameters.Validate();
        this.parameters = parameters;
    }

    public void DoDamage(Health health)
    {
        if (health == null)
            throw new NullReferenceException("Damaging null target");
        health.Change(-parameters.Damage);
    }

    [Serializable]
    public class Parameters : ICloneable
    {
        [Min(0)]
        [SerializeField] private int damage = 1;
        public int Damage => damage;

        public Parameters(int damage)
        {
            this.damage = damage;
        }

        public object Clone()
        {
            return new Parameters(damage);
        }

        public void Validate()
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException("damage", "Damage is less than zero");
        }
    }
}

