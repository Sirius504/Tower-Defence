using System;
using UnityEngine;

public class DamagerUpgrades
{
    private readonly Parameters parameters;
    private readonly Damager.Parameters defaultDamagerParameters;

    public DamagerUpgrades(Parameters parameters, Damager.Parameters defaultDamagerParameters)
    {
        this.parameters = parameters;
        this.defaultDamagerParameters = defaultDamagerParameters;
    }

    public Damager.Parameters GetUpgraded(int level = 0)
    {
        return new Damager.Parameters(defaultDamagerParameters.Damage + level);
    }

    [Serializable]
    public class Parameters
    {
        [SerializeField] private int upgradeStep;
        public int UpgradeStep => upgradeStep;
    }
}

