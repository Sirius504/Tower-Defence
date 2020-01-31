using Zenject;

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
