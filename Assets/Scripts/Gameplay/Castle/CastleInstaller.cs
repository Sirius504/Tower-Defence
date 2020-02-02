using TowerDefence.Gameplay.HealthSystem;
using Zenject;

namespace TowerDefence.Gameplay.CastleSystem
{
    public class CastleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Health>().FromNew().AsSingle();
        }
    }
}