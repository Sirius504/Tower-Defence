using TowerDefence.Gameplay.Damage;
using TowerDefence.Gameplay.HealthSystem;
using TowerDefence.Gameplay.LootSystem;
using Zenject;

namespace TowerDefence.Gameplay.EnemySystem
{
    public class EnemyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Health>().FromNew().AsSingle().NonLazy();
            Container.Bind<Damager>().FromNew().AsSingle();
            Container.Bind<Targeter<Health>>().FromComponentInChildren();
            Container.Bind<Loot>().FromNew().AsSingle();
        }
    } 
}
