using System;
using UnityEngine;

public class EnemyUpgrades
{
    private readonly Enemy.Parameters defaultEnemyParameters;
    private readonly HealthUpgrades healthUpgrades;
    private readonly DamagerUpgrades damagerUpgrades;
    private readonly LootUpgrades lootUpgrades;

    public EnemyUpgrades(Enemy.Parameters defaultEnemyParameters,
        Parameters upgradeParameters,
        HealthUpgrades healthUpgrades,
        DamagerUpgrades damagerUpgrades,
        LootUpgrades lootUpgrades)
    {
        this.defaultEnemyParameters = defaultEnemyParameters;
        this.healthUpgrades = healthUpgrades;
        this.damagerUpgrades = damagerUpgrades;
        this.lootUpgrades = lootUpgrades;
    }
    
    public Enemy.Parameters GetUpgraded(int level = 0)
    {        
        var healthParameters = healthUpgrades.GetUpgraded(level);
        var movementParameters = defaultEnemyParameters.MovementParameters;
        var damageParameters = damagerUpgrades.GetUpgraded(level);
        var lootParameters = lootUpgrades.GetUpgraded(level);
        return new Enemy.Parameters(movementParameters, healthParameters, damageParameters, lootParameters);
    }

    [Serializable]
    public class Parameters
    {
        [SerializeField] private HealthUpgrades.Parameters healthUpgradeParameters;
        public HealthUpgrades.Parameters HealthUpgradeParameters => healthUpgradeParameters;
        [SerializeField] private DamagerUpgrades.Parameters damagerUpgradeParameters;
        public DamagerUpgrades.Parameters DamagerUpgradeParameters => damagerUpgradeParameters;
        [SerializeField] private LootUpgrades.Parameters lootUpgradeParameters;
        public LootUpgrades.Parameters LootUpgradeParameters => lootUpgradeParameters;
    }
}

