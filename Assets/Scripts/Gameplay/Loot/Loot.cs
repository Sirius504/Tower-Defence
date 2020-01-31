using System;
using UnityEngine;

public class Loot
{
    private Parameters parameters;
    private readonly Gold playerGold;

    public Loot(Parameters parameters, Gold playerGold)
    {        
        this.playerGold = playerGold;
        SetParameters(parameters);
    }

    public void SetParameters(Parameters parameters)
    {
        parameters.Validate();
        this.parameters = parameters;
    }

    public void ApplyLoot()
    {
        playerGold.Add(parameters.Amount);
    }

    [Serializable]
    public class Parameters : ICloneable
    {
        [Min(0)]
        [SerializeField] private int amount;
        public int Amount => amount;

        public Parameters(int amount)
        {
            this.amount = amount;
        }

        public object Clone()
        {
            return new Parameters(amount);
        }

        public void Validate()
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount", "Loot amount is less than zero.");
        }
    }
}
