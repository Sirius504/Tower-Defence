using TowerDefence.Gameplay.Damage;
using Zenject;

namespace TowerDefence.Gameplay.TowerSystem
{
    public class TowerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Damager>().AsSingle();
        }
    }
}