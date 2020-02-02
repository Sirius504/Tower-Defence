using TowerDefence.Gameplay.EnemySystem;
using TowerDefence.Gameplay.LootSystem;
using TowerDefence.Gameplay.Movement;
using UnityEngine;
using Zenject;

namespace TowerDefence.Gameplay
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private MovementAlongPath enemyPrefab;

        public override void InstallBindings()
        {
            Container.BindFactory<Enemy, Enemy.Factory>()
                .FromComponentInNewPrefab(enemyPrefab)
                .UnderTransformGroup("Enemies");
            Container.Bind<Gold>().AsSingle();
            Container.Bind<Counter>().To<KilledEnemiesCounter>().AsSingle();
        }
    } 
}
