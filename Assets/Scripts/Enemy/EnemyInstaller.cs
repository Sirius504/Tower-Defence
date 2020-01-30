using Zenject;

public class EnemyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Life>().FromNew().AsSingle().NonLazy();
    }
}
