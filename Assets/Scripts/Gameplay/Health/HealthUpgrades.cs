using System;
using UnityEngine;

public class HealthUpgrades
{
    private readonly Health.Parameters defaultParameters;
    private readonly Parameters upgradeParameters;

    public HealthUpgrades(Health.Parameters defaultParameters, Parameters upgradeParameters)
    {
        this.defaultParameters = defaultParameters;
        this.upgradeParameters = upgradeParameters;
    }

    public Health.Parameters GetUpgraded(int toLevel = 1)
    {
        return new Health.Parameters(defaultParameters.MaxValue + toLevel * upgradeParameters.UpgradeStep);
    }

    [Serializable]
    public class Parameters
    {
        [SerializeField] private int upgradeStep;
        public int UpgradeStep => upgradeStep;
    }
}

