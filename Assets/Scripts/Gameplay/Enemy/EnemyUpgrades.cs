using System;
using System.Collections.Generic;
using TowerDefence.Common;
using TowerDefence.Gameplay.Damage;
using TowerDefence.Gameplay.HealthSystem;
using TowerDefence.Gameplay.LootSystem;
using UnityEngine;

namespace TowerDefence.Gameplay.EnemySystem
{
    public class EnemyUpgrades
    {
        private readonly Enemy.Parameters defaultEnemyParameters;
        private int currentHealthLevel = 0;
        private readonly HealthUpgrades healthUpgrades;
        private int currentDamagerLevel = 0;
        private readonly DamagerUpgrades damagerUpgrades;
        private int currentLootLevel = 0;
        private readonly LootUpgrades lootUpgrades;

        private readonly WeightedRandom<UpgradeTypes> upgradeProbabilities;
        public Enemy.Parameters CurrentParameters { get; private set; }

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
            CurrentParameters = (Enemy.Parameters)defaultEnemyParameters.Clone();

            upgradeProbabilities = new WeightedRandom<UpgradeTypes>(new Dictionary<UpgradeTypes, int>()
            {
                { UpgradeTypes.Damage, 5 },
                { UpgradeTypes.Health, 5 },
                { UpgradeTypes.Loot,   5 }
            });
        }

        public void Upgrade()
        {
            int numberOfUpgrades = UnityEngine.Random.Range(1, upgradeProbabilities.Weights.Count + 1);
            foreach (var upgrade in upgradeProbabilities.DrawNRandom(numberOfUpgrades))
                UpgradeParameter(upgrade);
        }

        private void UpgradeParameter(UpgradeTypes resultUpgradeType)
        {
            switch (resultUpgradeType)
            {
                case UpgradeTypes.Health:
                    currentHealthLevel++;
                    CurrentParameters.HealthParameters = healthUpgrades.GetUpgraded(currentHealthLevel);
                    break;
                case UpgradeTypes.Damage:
                    currentDamagerLevel++;
                    CurrentParameters.DamagerParameters = damagerUpgrades.GetUpgraded(currentDamagerLevel);
                    break;
                case UpgradeTypes.Loot:
                    currentLootLevel++;
                    CurrentParameters.LootParameters = lootUpgrades.GetUpgraded(currentLootLevel);
                    break;
                default:
                    throw new ArgumentException("resultUpgradeType", "Unreachable code reached");
            }
        }

        public enum UpgradeTypes
        {
            Health,
            Damage,
            Loot
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
}

