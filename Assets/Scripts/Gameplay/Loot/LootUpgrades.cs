using System;
using UnityEngine;

public class LootUpgrades
{
    private readonly Parameters parameters;
    private readonly Loot.Parameters defaultLootParameters;

    public LootUpgrades(Parameters parameters, Loot.Parameters defaultLootParameters)
    {
        this.parameters = parameters;
        this.defaultLootParameters = defaultLootParameters;
    }

    public Loot.Parameters GetUpgraded(int level = 0)
    {
        return new Loot.Parameters(defaultLootParameters.Amount + level * parameters.UpgradeStep);
    }

    [Serializable]
    public class Parameters
    {
        [SerializeField] private int upgradeStep;
        public int UpgradeStep => upgradeStep;
    }
}

