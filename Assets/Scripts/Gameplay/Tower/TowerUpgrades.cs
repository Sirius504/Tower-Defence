using System;
using UnityEngine;

public class TowerUpgrades
{
    private readonly Tower.Parameters defaultTowerParameters;
    private readonly Parameters parameters;
    private readonly DamagerUpgrades damagerUpgrades;

    public TowerUpgrades(Tower.Parameters defaultTowerParameters,
        Parameters parameters,
        DamagerUpgrades damagerUpgrades)
    {
        this.defaultTowerParameters = defaultTowerParameters;
        this.parameters = parameters;
        this.damagerUpgrades = damagerUpgrades;
    }

    public Tower.Parameters GetUpgraded(int level = 0)
    {
        var damagerParameters = damagerUpgrades.GetUpgraded(level);
        return new Tower.Parameters();
    }

    [Serializable]
    public class Parameters
    {
        [SerializeField] private DamagerUpgrades.Parameters damagerUpgradeParameters;
    }
}
