using Zenject;

public class EnemyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Life>().FromNew().AsSingle().NonLazy();
        Container.Bind<Damager>().FromNew().AsSingle();
        Container.Bind<Targeter<ILiving>>().FromComponentInChildren();
    }
}
