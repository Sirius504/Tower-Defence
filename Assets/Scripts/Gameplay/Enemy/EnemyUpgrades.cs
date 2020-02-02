using System;
using System.Collections.Generic;
using System.Linq;
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

        private Dictionary<UpgradeTypes, int> upgradeProbabilities;
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

            upgradeProbabilities = new Dictionary<UpgradeTypes, int>()
        {
            { UpgradeTypes.Damage, 5 },
            { UpgradeTypes.Health, 5 },
            { UpgradeTypes.Loot,   5 }
        };
        }

        public void Upgrade()
        {
            var upgrades = (UpgradeTypes[])Enum.GetValues(typeof(UpgradeTypes));
            int numberOfUpgrades = UnityEngine.Random.Range(1, upgrades.Length + 1);
            var upgradesPool = new Dictionary<UpgradeTypes, int>(upgradeProbabilities);
            for (int i = 0; i < numberOfUpgrades; i++)
            {
                int weightsSum = upgradesPool.Values.Sum();
                int currentWeight = 0;
                int randomValue = UnityEngine.Random.Range(0, weightsSum);
                UpgradeTypes resultUpgradeType = UpgradeTypes.Health;
                foreach (var upgradeProbability in upgradesPool)
                {
                    resultUpgradeType = upgradeProbability.Key;
                    currentWeight += upgradeProbability.Value;
                    if (currentWeight >= randomValue)
                        break;
                }
                UpgradeParameter(resultUpgradeType);
                upgradesPool.Remove(resultUpgradeType);
            }

            return;
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

