using TowerDefence.Gameplay.Damage;
using TowerDefence.Gameplay.EnemySystem;
using TowerDefence.Gameplay.HealthSystem;
using TowerDefence.Gameplay.LootSystem;
using UnityEngine;
using Zenject;

namespace TowerDefence.Configuration
{
    [CreateAssetMenu(fileName = "EnemyUpgrades", menuName = "Presets/Upgrades")]
    public class EnemyUpgradesInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private EnemyUpgrades.Parameters upgradeParameters;

        public override void InstallBindings()
        {
            Container.BindInstance(upgradeParameters.HealthUpgradeParameters);
            Container.Bind<HealthUpgrades>().FromNew().AsSingle();
            Container.BindInstance(upgradeParameters.DamagerUpgradeParameters);
            Container.Bind<DamagerUpgrades>().FromNew().AsSingle();
            Container.BindInstance(upgradeParameters.LootUpgradeParameters);
            Container.Bind<LootUpgrades>().FromNew().AsSingle();
            Container.BindInstance(upgradeParameters);
            Container.Bind<EnemyUpgrades>().FromNew().AsSingle();
        }
    }
}
